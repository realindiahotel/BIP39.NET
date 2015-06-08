using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bitcoin.BitcoinUtilities;

namespace Bitcoin.BIP39
{
    /// <summary>
    /// A .NET implementation of the Bitcoin Improvement Proposal - 39 (BIP39)
    /// BIP39 specification used as reference located here: https://github.com/bitcoin/bips/blob/master/bip-0039.mediawiki
    /// Made by thashiznets@yahoo.com.au
    /// v1.0.1.1
    /// I ♥ Bitcoin :)
    /// Bitcoin:1ETQjMkR1NNh4jwLuN5LxY7bMsHC9PUPSV
    /// </summary>
    public class BIP39
    {
        #region Private Attributes

        private byte[] _entropyBytes;        
        private byte[] _passphraseBytes;
        private Language _language;
        private List<int> _wordIndexList; //I made this a property because then we can keep the same index and swap between languages for experimenting
        private string _mnemonicSentence;

        #endregion

        #region Public Constants and Enums

        public const int cMinimumEntropyBits = 128;
        public const int cMaximumEntropyBits = 8192;
        public const int cEntropyMultiple = 32;
        public const int cBitsInByte = 8;
        public const int cBitGroupSize = 11;
        public const string cEmptyString = "";
        public const string cSaltHeader = "mnemonic"; //this is the first part of the salt as described in the BIP39 spec
        public enum Language {English,Japanese,Spanish,ChineseSimplified,ChineseTraditional,French,Unknown};
        public const string cJPSpaceString = "\u3000"; //ideographic space used by japanese language

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor to build a BIP39 object from scratch given an entropy size and an optional passphrase. Language is optional and will default to English
        /// </summary>
        /// <param name="entropySize">The size in bits of the entropy to be created</param>
        /// <param name="passphrase">The optional passphrase. Please ensure NFKD Normalized, Empty string will be used if not provided as per spec</param>
        /// <param name="language">The optional language. If no language is provided English will be used</param>
        public BIP39(int entropySize=cMinimumEntropyBits, string passphrase=cEmptyString, Language language=Language.English)
        {
            //check that ENT size is a multiple of 32 and at least minimun entropy size to stop silly people using tiny entropy, oh also making sure entropy size doesn't exceed our checksum bits available
            if (entropySize % cEntropyMultiple != 0 || entropySize < cMinimumEntropyBits || entropySize > cMaximumEntropyBits)
            {
                throw (new Exception("entropy size must be a multiple of "+cEntropyMultiple+" (divisible by "+cEntropyMultiple+" with no remainder) and must be greater than " + (cMinimumEntropyBits-1) + " and less than "+(cMaximumEntropyBits+1)));
            }

            _entropyBytes = Utilities.GetRandomBytes(entropySize / cBitsInByte); //crypto random entropy of the specified size
            pInit(passphrase, language);
        }

        /// <summary>
        /// Constructor to build a BIP39 object using supplied entropy bytes eighter from a previously created BIP39 object or another method of entropy generation.
        /// </summary>
        /// <param name="entropyBytes">The entropy bytes which will determine the mnemonic sentence</param>
        /// <param name="passphrase">The optional passphrase. Please ensure NFKD Normalized, Empty string will be used if not supplied as per spec</param>
        /// <param name="language">The optional language. If no language is provided English will be used</param>
        public BIP39(byte[] entropyBytes, string passphrase=cEmptyString, Language language=Language.English)
        {
            //check to ensure at least 16 bytes no more than 1024 bytes and byte array is in 4 byte groups
            if ((entropyBytes.Length * cBitsInByte) % cEntropyMultiple != 0 || (entropyBytes.Length * cBitsInByte) < cMinimumEntropyBits)
            {
                throw (new Exception("entropy bytes must be a multiple of " + (cEntropyMultiple / cBitsInByte) + " (divisible by " + (cEntropyMultiple / cBitsInByte) + " with no remainder) and must be greater than " + ((cMinimumEntropyBits / cBitsInByte) - 1) + " bytes and less than " + ((cMaximumEntropyBits / cBitsInByte) + 1) + " bytes"));
            }

            _entropyBytes = entropyBytes;          
            pInit(passphrase,language);
        }
       
        /// <summary>
        /// Constructor to build a BIP39 object using a supplied Mnemonic sentence and passphrase. If you are not worried about saving the entropy bytes, or using custom words not in a wordlist, you should consider the static method to do this instead.
        /// </summary>
        /// <param name="mnemonicSentence">The mnemonic sentencs used to derive seed bytes, Please ensure NFKD Normalized</param>
        /// <param name="passphrase">Optional passphrase used to protect seed bytes, defaults to empty</param>
        /// <param name="language">Optional language to use for wordlist, if not specified it will auto detect language and if it can't detect it will default to English</param>
        public BIP39(string mnemonicSentence, string passphrase = cEmptyString, Language language=Language.Unknown)
        {
            _mnemonicSentence = Utilities.NormaliseStringNfkd(mnemonicSentence.Trim()); //just making sure we don't have any leading or trailing spaces
            _passphraseBytes = UTF8Encoding.UTF8.GetBytes(Utilities.NormaliseStringNfkd(passphrase));
            string[] words = _mnemonicSentence.Split(new char[] { ' ' });

            //no language specified try auto detect it
            if(language.Equals(Language.Unknown))
            {
                _language = AutoDetectLanguageOfWords(words);

                if(_language.Equals(Language.Unknown))
                {
                    //yeah.....have a bias to use English as default....
                    _language = Language.English;
                }
            }

            //if the sentence is not at least 12 characters or cleanly divisible by 3, it is bad!
            if (words.Length < 12 || words.Length % 3 != 0)
            {
                throw new Exception("Mnemonic sentence must be at least 12 words and it will increase by 3 words for each increment in entropy. Please ensure your sentence is at leas 12 words and has no remainder when word count is divided by 3");
            }

            _language = language;
            _wordIndexList = pRebuildWordIndexes(words);
            _entropyBytes = pProcessIntToBitsThenBytes(_wordIndexList);   
        }

        #endregion

        #region Public Static Methods

        /// <summary>
        /// An asynchronous static method to create a new BIP39 from random entropy. The random entropy creation is CPU intensive so is run in its own Task and we await as per async pattern.
        /// </summary>
        /// <param name="entropySize">The size in bits of the entropy to be created</param>
        /// <param name="passphrase">The optional passphrase. Please ensure NFKD Normalized, Empty string will be used if not provided as per spec</param>
        /// <param name="language">The optional language. If no language is provided English will be used</param>
        /// <returns>A BIP39 object</returns>
        public static async Task<BIP39> GetBIP39Async(int entropySize = cMinimumEntropyBits, string passphrase = cEmptyString, Language language = Language.English)
        {
            byte[] entropyBytes = await Utilities.GetRandomBytesAsync(entropySize / cBitsInByte);
            return new BIP39(entropyBytes, passphrase, language);
        }

        /// <summary>
        /// Takes in a string[] of words and detects the language that has the highest number of matching words.
        /// </summary>
        /// <param name="words">The words of which you wish to derive a language</param>
        /// <returns>The best attempt at a guessed Language</returns>
        public static Language AutoDetectLanguageOfWords(string[] words)
        {
            Wordlists.English eng = new Wordlists.English();
            Wordlists.Japanese jp = new Wordlists.Japanese();
            Wordlists.Spanish es = new Wordlists.Spanish();
            Wordlists.French fr = new Wordlists.French();
            Wordlists.ChineseSimplified cnS = new Wordlists.ChineseSimplified();
            Wordlists.ChineseTraditional cnT = new Wordlists.ChineseTraditional();
            
            List<int> languageCount = new List<int>(new int[] {0,0,0,0,0,0});
            int index;

            foreach(string s in words)
            {               
                if(eng.WordExists(s,out index))
                {
                    //english is at 0
                    languageCount[0]++;
                }

                if (jp.WordExists(s, out index))
                {
                    //japanese is at 1
                    languageCount[1]++;
                }

                if (es.WordExists(s, out index))
                {
                    //spanish is at 2
                    languageCount[2]++;
                }

                if (cnS.WordExists(s, out index))
                {
                    //chinese simplified is at 3
                    languageCount[3]++;
                }

                if (cnT.WordExists(s, out index) && ! cnS.WordExists(s, out index))
                {
                    //chinese traditional is at 4
                    languageCount[4]++;
                }

                if (fr.WordExists(s, out index))
                {
                    //french is at 5
                    languageCount[5]++;
                }
            }

            //no hits found for any language unknown
            if(languageCount.Max()==0)
            {
                return Language.Unknown;
            }

            if(languageCount.IndexOf(languageCount.Max()) == 0)
            {
                return Language.English;
            }
            else if (languageCount.IndexOf(languageCount.Max()) == 1)
            {
                return Language.Japanese;
            }
            else if (languageCount.IndexOf(languageCount.Max()) == 2)
            {
                return Language.Spanish;
            }
            else if (languageCount.IndexOf(languageCount.Max()) == 3)
            {
                if (languageCount[4]>0)
                {
                    //has traditional characters so not simplified but instead traditional
                    return Language.ChineseTraditional;
                }

                return Language.ChineseSimplified;
            }
            else if (languageCount.IndexOf(languageCount.Max()) == 4)
            {
                return Language.ChineseTraditional;
            }
            else if (languageCount.IndexOf(languageCount.Max()) == 5)
            {
                return Language.French;
            }

            return Language.Unknown;
        }

        /// <summary>
        /// Supply a mnemonic sentence with any words of your choosing not restricted to wordlists and be given seed bytes in return
        /// </summary>
        /// <param name="mnemonicSentence">The mnemonic sentence we will use to derive seed bytes, Please ensure NFKD Normalized</param>
        /// <param name="passphrase">Optional passphrase to protect the seed bytes, Please ensure NFKD Normalized, defaults to empty string</param>
        /// <returns>Seed bytes that can be used to create a root in BIP32</returns>
        public static byte[] GetSeedBytes(string mnemonicSentence, string passphrase=cEmptyString)
        {
            mnemonicSentence = Utilities.NormaliseStringNfkd(mnemonicSentence);
            byte[] salt = Utilities.MergeByteArrays(UTF8Encoding.UTF8.GetBytes(cSaltHeader), UTF8Encoding.UTF8.GetBytes(Utilities.NormaliseStringNfkd(passphrase)));
            return Rfc2898_pbkdf2_hmacsha512.PBKDF2(UTF8Encoding.UTF8.GetBytes(mnemonicSentence), salt);
        }

        /// <summary>
        /// Supply a mnemonic sentence with any words of your choosing not restricted to wordlists and be given seed bytes hex encoded as a string in return
        /// </summary>
        /// <param name="mnemonicSentence">The mnemonic sentence we will use to derive seed bytes</param>
        /// <param name="passphrase">Optional passphrase to protect the seed bytes, defaults to empty string</param>
        /// <returns>Hex string encoded seed bytes that can be used to create a root in BIP32</returns>
        public static string GetSeedBytesHexString(string mnemonicSentence, string passphrase = cEmptyString)
        {
            mnemonicSentence = Utilities.NormaliseStringNfkd(mnemonicSentence);
            byte[] salt = Utilities.MergeByteArrays(UTF8Encoding.UTF8.GetBytes(cSaltHeader), UTF8Encoding.UTF8.GetBytes(Utilities.NormaliseStringNfkd(passphrase)));
            return Utilities.BytesToHexString(Rfc2898_pbkdf2_hmacsha512.PBKDF2(UTF8Encoding.UTF8.GetBytes(mnemonicSentence), salt));
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Common initialisation code utilised by all the constructors. It gets all the bits and does a checksum etc. This is the main code to create a BIP39 object.
        /// </summary>
        private void pInit(String passphrase, Language language)
        {
            _passphraseBytes = UTF8Encoding.UTF8.GetBytes(Utilities.NormaliseStringNfkd(passphrase));
            _language = language;
            byte[] allChecksumBytes = Utilities.Sha256Digest(_entropyBytes,0,_entropyBytes.Length); //sha256 the entropy bytes to get all the checksum bits
            
            _entropyBytes = Utilities.SwapEndianBytes(_entropyBytes); //seems I had to change the endianess of the bytes here to match the test vectors.....

            int numberOfChecksumBits = (_entropyBytes.Length * cBitsInByte) / cEntropyMultiple; //number of bits to take from the checksum bits, varies on entropy size as per spec
            BitArray entropyConcatChecksumBits = new BitArray((_entropyBytes.Length * cBitsInByte) + numberOfChecksumBits);

            allChecksumBytes = Utilities.SwapEndianBytes(allChecksumBytes); //yet another endianess change of some different bytes to match the test vectors.....             
            
            int index=0;

            foreach(bool b in new BitArray(_entropyBytes))
            {
                entropyConcatChecksumBits.Set(index, b);
                index++;
            }

            /*sooooo I'm doing below for future proofing....I know right now we are using up to 256 bits entropy in real world implementation and therefore max 8 bits (1 byte) of checksum....buuuut I figgure it's easy enough
            to accomodate more entropy by chaining more checksum bytes so maximum 256 * 32 = 8192 theoretical maximum entropy (plus CS).*/
            List<byte> checksumBytesToUse = new List<byte>();

            double byteCount = Math.Ceiling((double)numberOfChecksumBits / cBitsInByte);

            for (int i = 0; i < byteCount ;i++)
            {
                checksumBytesToUse.Add(allChecksumBytes[i]);
            }

            BitArray ba = new BitArray(checksumBytesToUse.ToArray());

            //add checksum bits
            for(int i = 0;i<numberOfChecksumBits;i++)
            {
                entropyConcatChecksumBits.Set(index,ba.Get(i));
                index++;
            }

            _wordIndexList = pGetWordIndeces(entropyConcatChecksumBits);
            _mnemonicSentence = pGetMnemonicSentence();
   
        }

        /// <summary>
        /// Uses the Wordlist Index to create a scentence ow words provided by the wordlist of this objects language attribute
        /// </summary>
        /// <returns>A scentence of words</returns>
        private string pGetMnemonicSentence()
        {
            //trap for words that were not in the word list when built. If custom words were used, we will not support the rebuild as we don't have the words
            if (_wordIndexList.Contains(-1))
            {
                throw new Exception("the wordlist index contains -1 which means words were used in the mnemonic sentence that cannot be found in the wordlist and the index to sentence feature cannot be used. Perhaps a different language wordlist is needed?");
            }

            string mSentence = cEmptyString;
            Wordlists.Wordlist wordlist;            

            switch(_language)
            {
                case Language.English:
                    wordlist = new Wordlists.English();
                    break;

                case Language.Japanese:
                    wordlist = new Wordlists.Japanese();
                    break;

                case Language.Spanish:
                    wordlist = new Wordlists.Spanish();
                    break;

                case Language.ChineseSimplified:
                    wordlist = new Wordlists.ChineseSimplified();
                    break;

                case Language.ChineseTraditional:
                    wordlist = new Wordlists.ChineseTraditional();
                    break;

                case Language.French:
                    wordlist = new Wordlists.French();
                    break;

                default:
                    wordlist = new Wordlists.English();
                    break;
            }

            for(int i =0; i<_wordIndexList.Count;i++)
            {
                mSentence += wordlist.GetWordAtIndex(_wordIndexList[i]);
                if(i+1 < _wordIndexList.Count)
                {
                    mSentence += " ";
                }
            }           

            return mSentence;
        }

        /// <summary>
        /// Process entropy + CS into an index list of words to get from wordlist
        /// </summary>
        /// <returns>An index, each int is a line in the wiordlist for the language of choice</returns>
        private List<int> pGetWordIndeces(BitArray entropyConcatChecksumBits)
        {
            List<int> wordIndexList = new List<int>();

            //yea....loop in a loop....what of it!!! Outer loop is segregating bits into 11 bit groups and the inner loop is processing the 11 bits before sending them to be encoded as an int.
            for(int i = 0; i< entropyConcatChecksumBits.Length; i=i+cBitGroupSize)
            {
                BitArray toInt = new BitArray(cBitGroupSize);
                for (int i2 = 0; i2 < cBitGroupSize && i<entropyConcatChecksumBits.Length; i2++)
                {
                    toInt.Set(i2, entropyConcatChecksumBits.Get(i+i2));
                }

                wordIndexList.Add(pProcessBitsToInt(toInt)); //adding encoded int to word index               
            }

            return wordIndexList;
        }

        /// <summary>
        /// Takes in the words of a mnemonic sentence and it rebuilds the word index, having the valid index allows us to hot swap between languages/word lists :)
        /// </summary>
        /// <param name="wordsInMnemonicSentence"> a string array containing each word in the mnemonic sentence</param>
        /// <returns>The word index that can be used to build the mnemonic sentence</returns>
        private List<int> pRebuildWordIndexes(string[] wordsInMnemonicSentence)
        {
            List<int> wordIndexList = new List<int>();
            string langName = cEmptyString;

            Wordlists.Wordlist wordlist;

            switch (_language)
            {
                case Language.English:
                    wordlist = new Wordlists.English();
                    langName = "English";
                    break;

                case Language.Japanese:
                    wordlist = new Wordlists.Japanese();
                    langName = "Japanese";
                    break;

                case Language.Spanish:
                    wordlist = new Wordlists.Spanish();
                    langName = "Spanish";
                    break;

                case Language.ChineseSimplified:
                    wordlist = new Wordlists.ChineseSimplified();
                    langName = "Chinese Simplified";
                    break;

                case Language.ChineseTraditional:
                    wordlist = new Wordlists.ChineseTraditional();
                    langName = "Chinese Traditional";
                    break;

                case Language.French:
                    wordlist = new Wordlists.French();
                    langName = "French";
                    break;

                default:
                    wordlist = new Wordlists.English();
                    langName = "English";
                    break;
            }

            foreach(string s in wordsInMnemonicSentence)
            {
                int idx=-1;                

                if(!wordlist.WordExists(s, out idx))
                {
                    throw new Exception("Word "+s+" is not in the wordlist for language " + langName + " cannot continue to rebuild entropy from wordlist");
                }

                wordIndexList.Add(idx);            
            }

            return wordIndexList;
        }

        /// <summary>
        /// Me encoding an integer between 0 and 2047 from 11 bits...
        /// </summary>
        /// <param name="bits">The bits to encode into an integer</param>
        /// <returns>integer between 0 and 2047</returns>
        private int pProcessBitsToInt(BitArray bits)
        {

            if(bits.Length != cBitGroupSize)
            {
                //to do throw not 11 bits exception
            }

            int number = 0;
            int base2Divide = 1024; //it's all downhill from here...literally we halve this for each bit we move to.

            //literally picture this loop as going from the most significant bit across to the least in the 11 bits, dividing by 2 for each bit as per binary/base 2
            foreach(bool b in bits)
            {
                if(b)
                {
                    number = number + base2Divide;
                }

                base2Divide = base2Divide / 2;
            }            

            return number;
        }

        /// <summary>
        /// Takes the word index and decodes it from our 11 bit integer encoding back into raw bits including CS. Then it removes CS bits and turns back into entropy bytes
        /// </summary>
        /// <param name="wordIndex">The word index to convert back to bits then bytes</param>
        /// <returns>entropy bytes excluding CS</returns>
        private byte[] pProcessIntToBitsThenBytes(List<int> wordIndex)
        {
            //trap for words that were not in the word list when built. If custom words were used, we will not support the rebuild as we don't have the words
            if (wordIndex.Contains(-1))
            {
                throw new Exception("the wordlist index contains -1 which means words were used in the mnemonic sentence that cannot be found in the wordlist and so the -1 will stuff up our entropy bits and we cannot rebuild the entropy from index containing -1. Perhaps a different language wordlist is needed?");
            }
            BitArray bits = new BitArray(wordIndex.Count * cBitGroupSize);
            
            int bitIndex = 0;            

            //hey look it's another loop in a loop w00t! I'm sure my old uni lecturer is fizzin' at the bumhole with rage somewhere right now.....it works tho :)
            for(int i=0; i< wordIndex.Count;i++)
            {
                double wordindex = (double)wordIndex[i];

                //slide down our 11 bits doin mod 2 to determin true or false for each bit
                for (int biti = 0; biti < 11;biti++)
                {
                    bits[bitIndex] = false;

                    if (wordindex % 2 == 1)
                    {
                        bits[bitIndex] = true;
                    }

                    wordindex = Math.Floor(wordindex / (double)2);

                    bitIndex++;
                }

                //below swaps the endianess of our 11 bit group.....crude but working
                bool temp = bits.Get(bitIndex-(cBitGroupSize));
                bits.Set(bitIndex - (cBitGroupSize),bits.Get(bitIndex-1));
                bits.Set(bitIndex - 1, temp);
                temp = bits.Get(bitIndex-(cBitGroupSize-1));
                bits.Set(bitIndex - (cBitGroupSize-1),bits.Get(bitIndex-2));
                bits.Set(bitIndex - 2, temp);
                temp = bits.Get(bitIndex - (cBitGroupSize - 2));
                bits.Set(bitIndex - (cBitGroupSize - 2), bits.Get(bitIndex - 3));
                bits.Set(bitIndex - 3, temp);
                temp = bits.Get(bitIndex - (cBitGroupSize - 3));
                bits.Set(bitIndex - (cBitGroupSize - 3), bits.Get(bitIndex - 4));
                bits.Set(bitIndex - 4, temp);
                temp = bits.Get(bitIndex - (cBitGroupSize - 4));
                bits.Set(bitIndex - (cBitGroupSize - 4), bits.Get(bitIndex - 5));
                bits.Set(bitIndex - 5, temp);
                //end bit swappy, rubber fanny haha
                
            }

            //now we need to strip the checksum and return entropy bytes

            int length = bits.Length - (bits.Length / (cEntropyMultiple + 1));

            if (length % 8 != 0)
            {
                throw new Exception("Entropy bits less checksum need to be cleanly divisible by " + cBitsInByte);
            }

            byte[] entropy = new byte[length / cBitsInByte];
            BitArray checksum = new BitArray(bits.Length / (cEntropyMultiple + 1));
            BitArray checksumActual = new BitArray(bits.Length / (cEntropyMultiple + 1));

            int index = 0;

            //get entropy bytes
            for (int byteIndex = 0; byteIndex < entropy.Length; byteIndex++)
            {
                for(int i = 0; i < cBitsInByte; i++)
                {
                    int bitIdx = index % cBitsInByte;
                    byte mask = (byte)(1 << bitIdx);
                    entropy[byteIndex] = (byte)(bits.Get(index) ? (entropy[byteIndex] | mask) : (entropy[byteIndex] & ~mask));
                    index++;
                }
            }

            //get remaining bits as checksum bits
            int csindex = 0;

            while(index < bits.Length)
            {
                checksum.Set(csindex, bits.Get(index));
                csindex++;
                index++;
            }

            //now we get actual checksum of our entropy bytes
            BitArray allChecksumBits = new BitArray(Utilities.SwapEndianBytes(Utilities.Sha256Digest(Utilities.SwapEndianBytes(entropy), 0, entropy.Length))); //sha256 the entropy bytes to get all the checksum bits

            for(int i=0; i<checksumActual.Length;i++)
            {
                checksumActual.Set(i, allChecksumBits.Get(i));
            }

            //now we check that our checksum derived from the word index mantches the checksum of our entropy bytes, if so happy days

            foreach(bool b in checksumActual.Xor(checksum))
            {
                if (b)
                {
                    throw new Exception("woah! the checksum I derived from the word index DOES NOT match the checksum I computed from the entropy bytes! We have a problem!");
                }
            }

            return entropy;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the entropy bytes, they can be used to reconstruct this object, providing these bytes and passphrase is all that is needed
        /// </summary>
        public byte[] EntropyBytes
        {
            get
            {
                return Utilities.SwapEndianBytes(_entropyBytes);
            }
        }

        /// <summary>
        /// Sets the pasphrase, this lets us use the same entropy bits to derive many seeds based on different passphrases
        /// </summary>
        public string Passphrase
        {
            set
            {
                _passphraseBytes = UTF8Encoding.UTF8.GetBytes(Utilities.NormaliseStringNfkd(value));
            }
        }
        
        /// <summary>
        /// Gets the mnemonic sentence built from ent+cs
        /// </summary>
        public string MnemonicSentence
        {
            get
            {
                String outputMnemonic = _mnemonicSentence;

                if(_language.Equals(Language.Japanese))
                {
                    char japSpace;
                    Char.TryParse(cJPSpaceString, out japSpace);
                    outputMnemonic = outputMnemonic.Replace(' ', japSpace);
                }
                
                return outputMnemonic;
            }
        }

        /// <summary>
        /// Gets or Sets the language that will be used to provide the mnemonic sentence, WARNING ensure you get new seed bytes after setting language
        /// </summary>
        public Language WordlistLanguage
        {
            get
            {
                return _language;
            }

            set
            {
                _language = value;
                //new language means we need a mnemonic sentence in that language
                _mnemonicSentence = pGetMnemonicSentence();
            }
        }

        /// <summary>
        /// Gets the bytes of the seed created from the mnemonic sentence. This could become your root in BIP32
        /// </summary>
        public byte[] SeedBytes
        {
            get
            {
                //literally this is the bulk of the decoupled seed generation code, easy.
                byte[] salt = Utilities.MergeByteArrays(UTF8Encoding.UTF8.GetBytes(cSaltHeader),_passphraseBytes);
                return Rfc2898_pbkdf2_hmacsha512.PBKDF2(UTF8Encoding.UTF8.GetBytes(Utilities.NormaliseStringNfkd(MnemonicSentence)), salt);
            }
        }

        /// <summary>
        /// Gets a hex encoded string of the seed bytes
        /// </summary>
        public string SeedBytesHexString
        {
            get
            {
                return Utilities.BytesToHexString(SeedBytes);
            }
        }

        
        /// <summary>
        /// Gets a count of the words that the entropy will produce
        /// </summary>
        public int WordCountFromEntropy
        {
            get
            {
                int entropyBits = _entropyBytes.Length * cBitsInByte;
                return (entropyBits + (entropyBits / cEntropyMultiple)) / cBitGroupSize;

            }
        }

        #endregion
    }
}
