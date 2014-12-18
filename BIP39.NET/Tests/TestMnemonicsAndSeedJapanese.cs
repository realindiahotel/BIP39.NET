using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bitcoin.BIP39;
using Bitcoin.BitcoinUtilities;

namespace Tests
{
    [TestClass]
    public class TestMnemonicsAndSeedJapanese
    {
        BIP39 bip39;
        BIP39 bip39frommnemonic;

        [TestMethod]
        public void JapTest1()
        {
            byte[] entropyBytes = Utilities.HexStringToBytes("00000000000000000000000000000000");
            bip39 = new BIP39(entropyBytes, ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD), BIP39.Language.Japanese);
            //check correct mnemonic sentence
            Assert.AreEqual(("あいこくしん あいこくしん あいこくしん あいこくしん あいこくしん あいこくしん あいこくしん あいこくしん あいこくしん あいこくしん あいこくしん あおぞら").Normalize(NormalizationForm.FormKD), bip39.MnemonicSentence);
            //check correct seed
            Assert.AreEqual("a262d6fb6122ecf45be09c50492b31f92e9beb7d9a845987a02cefda57a15f9c467a17872029a9e92299b5cbdf306e3a0ee620245cbd508959b6cb7ca637bd55", bip39.SeedBytesHexString);
            //check that we can rebuild the BIP39 object using the mnemonic and passphrase and that it gives the same result 
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD),BIP39.Language.Japanese);
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
        }

        [TestMethod]
        public void JapTest2()
        {
            byte[] entropyBytes = Utilities.HexStringToBytes("7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f");
            bip39 = new BIP39(entropyBytes, ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD), BIP39.Language.Japanese);
            //check correct mnemonic sentence
            Assert.AreEqual(("そつう れきだい ほんやく わかす りくつ ばいか ろせん やちん そつう れきだい ほんやく わかめ").Normalize(NormalizationForm.FormKD), bip39.MnemonicSentence);
            //check correct seed
            Assert.AreEqual("aee025cbe6ca256862f889e48110a6a382365142f7d16f2b9545285b3af64e542143a577e9c144e101a6bdca18f8d97ec3366ebf5b088b1c1af9bc31346e60d9", bip39.SeedBytesHexString);
            //check that we can rebuild the BIP39 object using the mnemonic and passphrase and that it gives the same result 
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD), BIP39.Language.Japanese);
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
        }

        [TestMethod]
        public void JapTest3()
        {
            byte[] entropyBytes = Utilities.HexStringToBytes("80808080808080808080808080808080");
            bip39 = new BIP39(entropyBytes, ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD), BIP39.Language.Japanese);
            //check correct mnemonic sentence
            Assert.AreEqual(("そとづら あまど おおう あこがれる いくぶん けいけん あたえる いよく そとづら あまど おおう あかちゃん").Normalize(NormalizationForm.FormKD), bip39.MnemonicSentence);
            //check correct seed
            Assert.AreEqual("e51736736ebdf77eda23fa17e31475fa1d9509c78f1deb6b4aacfbd760a7e2ad769c714352c95143b5c1241985bcb407df36d64e75dd5a2b78ca5d2ba82a3544", bip39.SeedBytesHexString);
            //check that we can rebuild the BIP39 object using the mnemonic and passphrase and that it gives the same result 
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD), BIP39.Language.Japanese);
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
        }

        [TestMethod]
        public void JapTest4()
        {
            byte[] entropyBytes = Utilities.HexStringToBytes("ffffffffffffffffffffffffffffffff");
            bip39 = new BIP39(entropyBytes, ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD), BIP39.Language.Japanese);
            //check correct mnemonic sentence
            Assert.AreEqual(("われる われる われる われる われる われる われる われる われる われる われる ろんぶん").Normalize(NormalizationForm.FormKD), bip39.MnemonicSentence);
            //check correct seed
            Assert.AreEqual("4cd2ef49b479af5e1efbbd1e0bdc117f6a29b1010211df4f78e2ed40082865793e57949236c43b9fe591ec70e5bb4298b8b71dc4b267bb96ed4ed282c8f7761c", bip39.SeedBytesHexString);
            //check that we can rebuild the BIP39 object using the mnemonic and passphrase and that it gives the same result 
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD), BIP39.Language.Japanese);
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
        }

        [TestMethod]
        public void JapTest5()
        {
            byte[] entropyBytes = Utilities.HexStringToBytes("000000000000000000000000000000000000000000000000");
            bip39 = new BIP39(entropyBytes, ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD), BIP39.Language.Japanese);
            //check correct mnemonic sentence
            Assert.AreEqual(("あいこくしん あいこくしん あいこくしん あいこくしん あいこくしん あいこくしん あいこくしん あいこくしん あいこくしん あいこくしん あいこくしん あいこくしん あいこくしん あいこくしん あいこくしん あいこくしん あいこくしん あらいぐま").Normalize(NormalizationForm.FormKD), bip39.MnemonicSentence);
            //check correct seed
            Assert.AreEqual("d99e8f1ce2d4288d30b9c815ae981edd923c01aa4ffdc5dee1ab5fe0d4a3e13966023324d119105aff266dac32e5cd11431eeca23bbd7202ff423f30d6776d69", bip39.SeedBytesHexString);
            //check that we can rebuild the BIP39 object using the mnemonic and passphrase and that it gives the same result 
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD), BIP39.Language.Japanese);
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
        }

        [TestMethod]
        public void JapTest6()
        {
            byte[] entropyBytes = Utilities.HexStringToBytes("7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f");
            bip39 = new BIP39(entropyBytes, ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD), BIP39.Language.Japanese);
            //check correct mnemonic sentence
            Assert.AreEqual(("そつう れきだい ほんやく わかす りくつ ばいか ろせん やちん そつう れきだい ほんやく わかす りくつ ばいか ろせん やちん そつう れいぎ").Normalize(NormalizationForm.FormKD), bip39.MnemonicSentence);
            //check correct seed
            Assert.AreEqual("eaaf171efa5de4838c758a93d6c86d2677d4ccda4a064a7136344e975f91fe61340ec8a615464b461d67baaf12b62ab5e742f944c7bd4ab6c341fbafba435716", bip39.SeedBytesHexString);
            //check that we can rebuild the BIP39 object using the mnemonic and passphrase and that it gives the same result 
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD), BIP39.Language.Japanese);
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
        }

        [TestMethod]
        public void JapTest7()
        {
            byte[] entropyBytes = Utilities.HexStringToBytes("808080808080808080808080808080808080808080808080");
            bip39 = new BIP39(entropyBytes, ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD), BIP39.Language.Japanese);
            //check correct mnemonic sentence
            Assert.AreEqual(("そとづら あまど おおう あこがれる いくぶん けいけん あたえる いよく そとづら あまど おおう あこがれる いくぶん けいけん あたえる いよく そとづら いきなり").Normalize(NormalizationForm.FormKD), bip39.MnemonicSentence);
            //check correct seed
            Assert.AreEqual("aec0f8d3167a10683374c222e6e632f2940c0826587ea0a73ac5d0493b6a632590179a6538287641a9fc9df8e6f24e01bf1be548e1f74fd7407ccd72ecebe425", bip39.SeedBytesHexString);
            //check that we can rebuild the BIP39 object using the mnemonic and passphrase and that it gives the same result 
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD), BIP39.Language.Japanese);
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
        }

        [TestMethod]
        public void JapTest8()
        {
            byte[] entropyBytes = Utilities.HexStringToBytes("ffffffffffffffffffffffffffffffffffffffffffffffff");
            bip39 = new BIP39(entropyBytes, ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD), BIP39.Language.Japanese);
            //check correct mnemonic sentence
            Assert.AreEqual(("われる われる われる われる われる われる われる われる われる われる われる われる われる われる われる われる われる りんご").Normalize(NormalizationForm.FormKD), bip39.MnemonicSentence);
            //check correct seed
            Assert.AreEqual("f0f738128a65b8d1854d68de50ed97ac1831fc3a978c569e415bbcb431a6a671d4377e3b56abd518daa861676c4da75a19ccb41e00c37d086941e471a4374b95", bip39.SeedBytesHexString);
            //check that we can rebuild the BIP39 object using the mnemonic and passphrase and that it gives the same result 
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD), BIP39.Language.Japanese);
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
        }

        [TestMethod]
        public void JapTest9()
        {
            byte[] entropyBytes = Utilities.HexStringToBytes("0000000000000000000000000000000000000000000000000000000000000000");
            bip39 = new BIP39(entropyBytes, ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD), BIP39.Language.Japanese);
            //check correct mnemonic sentence
            Assert.AreEqual(("あいこくしん あいこくしん あいこくしん あいこくしん あいこくしん あいこくしん あいこくしん あいこくしん あいこくしん あいこくしん あいこくしん あいこくしん あいこくしん あいこくしん あいこくしん あいこくしん あいこくしん あいこくしん　あいこくしん あいこくしん あいこくしん あいこくしん あいこくしん いってい").Normalize(NormalizationForm.FormKD), bip39.MnemonicSentence);
            //check correct seed
            Assert.AreEqual("23f500eec4a563bf90cfda87b3e590b211b959985c555d17e88f46f7183590cd5793458b094a4dccc8f05807ec7bd2d19ce269e20568936a751f6f1ec7c14ddd", bip39.SeedBytesHexString);
            //check that we can rebuild the BIP39 object using the mnemonic and passphrase and that it gives the same result 
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD), BIP39.Language.Japanese);
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
        }

        [TestMethod]
        public void JapTest10()
        {
            byte[] entropyBytes = Utilities.HexStringToBytes("7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f");
            bip39 = new BIP39(entropyBytes, ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD), BIP39.Language.Japanese);
            //check correct mnemonic sentence
            Assert.AreEqual(("そつう れきだい ほんやく わかす りくつ ばいか ろせん やちん そつう れきだい ほんやく わかす りくつ ばいか ろせん やちん そつう れきだい ほんやく わかす りくつ ばいか ろせん まんきつ").Normalize(NormalizationForm.FormKD), bip39.MnemonicSentence);
            //check correct seed
            Assert.AreEqual("cd354a40aa2e241e8f306b3b752781b70dfd1c69190e510bc1297a9c5738e833bcdc179e81707d57263fb7564466f73d30bf979725ff783fb3eb4baa86560b05", bip39.SeedBytesHexString);
            //check that we can rebuild the BIP39 object using the mnemonic and passphrase and that it gives the same result 
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD), BIP39.Language.Japanese);
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
        }

        [TestMethod]
        public void JapTest11()
        {
            byte[] entropyBytes = Utilities.HexStringToBytes("8080808080808080808080808080808080808080808080808080808080808080");
            bip39 = new BIP39(entropyBytes, ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD), BIP39.Language.Japanese);
            //check correct mnemonic sentence
            Assert.AreEqual(("そとづら あまど おおう あこがれる いくぶん けいけん あたえる いよく そとづら あまど おおう あこがれる いくぶん けいけん あたえる いよく そとづら あまど おおう あこがれる いくぶん けいけん あたえる うめる").Normalize(NormalizationForm.FormKD), bip39.MnemonicSentence);
            //check correct seed
            Assert.AreEqual("6b7cd1b2cdfeeef8615077cadd6a0625f417f287652991c80206dbd82db17bf317d5c50a80bd9edd836b39daa1b6973359944c46d3fcc0129198dc7dc5cd0e68", bip39.SeedBytesHexString);
            //check that we can rebuild the BIP39 object using the mnemonic and passphrase and that it gives the same result 
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD), BIP39.Language.Japanese);
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
        }

        [TestMethod]
        public void JapTest12()
        {
            byte[] entropyBytes = Utilities.HexStringToBytes("ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff");
            bip39 = new BIP39(entropyBytes, ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD), BIP39.Language.Japanese);
            //check correct mnemonic sentence
            Assert.AreEqual(("われる われる われる われる われる われる われる われる われる われる われる われる われる われる われる われる われる われる われる われる われる われる われる らいう").Normalize(NormalizationForm.FormKD), bip39.MnemonicSentence);
            //check correct seed
            Assert.AreEqual("a44ba7054ac2f9226929d56505a51e13acdaa8a9097923ca07ea465c4c7e294c038f3f4e7e4b373726ba0057191aced6e48ac8d183f3a11569c426f0de414623", bip39.SeedBytesHexString);
            //check that we can rebuild the BIP39 object using the mnemonic and passphrase and that it gives the same result 
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD), BIP39.Language.Japanese);
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
        }

        [TestMethod]
        public void JapTest13()
        {
            byte[] entropyBytes = Utilities.HexStringToBytes("77c2b00716cec7213839159e404db50d");
            bip39 = new BIP39(entropyBytes, ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD), BIP39.Language.Japanese);
            //check correct mnemonic sentence
            Assert.AreEqual(("せまい うちがわ あずき かろう めずらしい だんち ますく おさめる ていぼう あたる すあな えしゃく").Normalize(NormalizationForm.FormKD), bip39.MnemonicSentence);
            //check correct seed
            Assert.AreEqual("344cef9efc37d0cb36d89def03d09144dd51167923487eec42c487f7428908546fa31a3c26b7391a2b3afe7db81b9f8c5007336b58e269ea0bd10749a87e0193", bip39.SeedBytesHexString);
            //check that we can rebuild the BIP39 object using the mnemonic and passphrase and that it gives the same result 
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD), BIP39.Language.Japanese);
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
        }

        [TestMethod]
        public void JapTest14()
        {
            byte[] entropyBytes = Utilities.HexStringToBytes("b63a9c59a6e641f288ebc103017f1da9f8290b3da6bdef7b");
            bip39 = new BIP39(entropyBytes, ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD), BIP39.Language.Japanese);
            //check correct mnemonic sentence
            Assert.AreEqual(("ぬすむ ふっかつ うどん こうりつ しつじ りょうり おたがい せもたれ あつめる いちりゅう はんしゃ ごますり そんけい たいちょう らしんばん ぶんせき やすみ ほいく").Normalize(NormalizationForm.FormKD), bip39.MnemonicSentence);
            //check correct seed
            Assert.AreEqual("b14e7d35904cb8569af0d6a016cee7066335a21c1c67891b01b83033cadb3e8a034a726e3909139ecd8b2eb9e9b05245684558f329b38480e262c1d6bc20ecc4", bip39.SeedBytesHexString);
            //check that we can rebuild the BIP39 object using the mnemonic and passphrase and that it gives the same result 
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD), BIP39.Language.Japanese);
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
        }

        [TestMethod]
        public void JapTest15()
        {
            byte[] entropyBytes = Utilities.HexStringToBytes("3e141609b97933b66a060dcddc71fad1d91677db872031e85f4c015c5e7e8982");
            bip39 = new BIP39(entropyBytes, ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD), BIP39.Language.Japanese);
            //check correct mnemonic sentence
            Assert.AreEqual(("くのう てぬぐい そんかい すろっと ちきゅう ほあん とさか はくしゅ ひびく みえる そざい てんすう たんぴん くしょう すいようび みけん きさらぎ げざん ふくざつ あつかう はやい くろう おやゆび こすう").Normalize(NormalizationForm.FormKD), bip39.MnemonicSentence);
            //check correct seed
            Assert.AreEqual("32e78dce2aff5db25aa7a4a32b493b5d10b4089923f3320c8b287a77e512455443298351beb3f7eb2390c4662a2e566eec5217e1a37467af43b46668d515e41b", bip39.SeedBytesHexString);
            //check that we can rebuild the BIP39 object using the mnemonic and passphrase and that it gives the same result 
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD), BIP39.Language.Japanese);
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
        }

        [TestMethod]
        public void JapTest16()
        {
            byte[] entropyBytes = Utilities.HexStringToBytes("0460ef47585604c5660618db2e6a7e7f");
            bip39 = new BIP39(entropyBytes, ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD), BIP39.Language.Japanese);
            //check correct mnemonic sentence
            Assert.AreEqual(("あみもの いきおい ふいうち にげる ざんしょ じかん ついか はたん ほあん すんぽう てちがい わかめ").Normalize(NormalizationForm.FormKD), bip39.MnemonicSentence);
            //check correct seed
            Assert.AreEqual("0acf902cd391e30f3f5cb0605d72a4c849342f62bd6a360298c7013d714d7e58ddf9c7fdf141d0949f17a2c9c37ced1d8cb2edabab97c4199b142c829850154b", bip39.SeedBytesHexString);
            //check that we can rebuild the BIP39 object using the mnemonic and passphrase and that it gives the same result 
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD), BIP39.Language.Japanese);
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
        }

        [TestMethod]
        public void JapTest17()
        {
            byte[] entropyBytes = Utilities.HexStringToBytes("72f60ebac5dd8add8d2a25a797102c3ce21bc029c200076f");
            bip39 = new BIP39(entropyBytes, ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD), BIP39.Language.Japanese);
            //check correct mnemonic sentence
            Assert.AreEqual(("すろっと にくしみ なやむ たとえる へいこう すくう きない けってい とくべつ ねっしん いたみ せんせい おくりがな まかい とくい けあな いきおい そそぐ").Normalize(NormalizationForm.FormKD), bip39.MnemonicSentence);
            //check correct seed
            Assert.AreEqual("9869e220bec09b6f0c0011f46e1f9032b269f096344028f5006a6e69ea5b0b8afabbb6944a23e11ebd021f182dd056d96e4e3657df241ca40babda532d364f73", bip39.SeedBytesHexString);
            //check that we can rebuild the BIP39 object using the mnemonic and passphrase and that it gives the same result 
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD), BIP39.Language.Japanese);
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
        }

        [TestMethod]
        public void JapTest18()
        {
            byte[] entropyBytes = Utilities.HexStringToBytes("2c85efc7f24ee4573d2b81a6ec66cee209b2dcbd09d8eddc51e0215b0b68e416");
            bip39 = new BIP39(entropyBytes, ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD), BIP39.Language.Japanese);
            //check correct mnemonic sentence
            Assert.AreEqual(("かほご きうい ゆたか みすえる もらう がっこう よそう ずっと ときどき したうけ にんか はっこう つみき すうじつ よけい くげん もくてき まわり せめる げざい にげる にんたい たんそく ほそく").Normalize(NormalizationForm.FormKD), bip39.MnemonicSentence);
            //check correct seed
            Assert.AreEqual("713b7e70c9fbc18c831bfd1f03302422822c3727a93a5efb9659bec6ad8d6f2c1b5c8ed8b0b77775feaf606e9d1cc0a84ac416a85514ad59f5541ff5e0382481", bip39.SeedBytesHexString);
            //check that we can rebuild the BIP39 object using the mnemonic and passphrase and that it gives the same result 
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD), BIP39.Language.Japanese);
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
        }

        [TestMethod]
        public void JapTest19()
        {
            byte[] entropyBytes = Utilities.HexStringToBytes("eaebabb2383351fd31d703840b32e9e2");
            bip39 = new BIP39(entropyBytes, ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD), BIP39.Language.Japanese);
            //check correct mnemonic sentence
            Assert.AreEqual(("めいえん さのう めだつ すてる きぬごし ろんぱ はんこ まける たいおう さかいし ねんいり はぶらし").Normalize(NormalizationForm.FormKD), bip39.MnemonicSentence);
            //check correct seed
            Assert.AreEqual("06e1d5289a97bcc95cb4a6360719131a786aba057d8efd603a547bd254261c2a97fcd3e8a4e766d5416437e956b388336d36c7ad2dba4ee6796f0249b10ee961", bip39.SeedBytesHexString);
            //check that we can rebuild the BIP39 object using the mnemonic and passphrase and that it gives the same result 
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD), BIP39.Language.Japanese);
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
        }

        [TestMethod]
        public void JapTest20()
        {
            byte[] entropyBytes = Utilities.HexStringToBytes("7ac45cfe7722ee6c7ba84fbc2d5bd61b45cb2fe5eb65aa78");
            bip39 = new BIP39(entropyBytes, ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD), BIP39.Language.Japanese);
            //check correct mnemonic sentence
            Assert.AreEqual(("せんぱい おしえる ぐんかん もらう きあい きぼう やおや いせえび のいず じゅしん よゆう きみつ さといも ちんもく ちわわ しんせいじ とめる はちみつ").Normalize(NormalizationForm.FormKD), bip39.MnemonicSentence);
            //check correct seed
            Assert.AreEqual("1fef28785d08cbf41d7a20a3a6891043395779ed74503a5652760ee8c24dfe60972105ee71d5168071a35ab7b5bd2f8831f75488078a90f0926c8e9171b2bc4a", bip39.SeedBytesHexString);
            //check that we can rebuild the BIP39 object using the mnemonic and passphrase and that it gives the same result 
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD), BIP39.Language.Japanese);
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
        }

        [TestMethod]
        public void JapTest21()
        {
            byte[] entropyBytes = Utilities.HexStringToBytes("4fa1a8bc3e6d80ee1316050e862c1812031493212b7ec3f3bb1b08f168cabeef");
            bip39 = new BIP39(entropyBytes, ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD), BIP39.Language.Japanese);
            //check correct mnemonic sentence
            Assert.AreEqual(("こころ　いどう　きあつ　そうがんきょう　へいあん　せつりつ　ごうせい　はいち　いびき　きこく　あんい　おちつく　きこえる　けんとう　たいこ　すすめる　はっけん　ていど　はんおん　いんさつ　うなぎ　しねま　れいぼう　みつかる").Normalize(NormalizationForm.FormKD), bip39.MnemonicSentence);
            //check correct seed
            Assert.AreEqual("43de99b502e152d4c198542624511db3007c8f8f126a30818e856b2d8a20400d29e7a7e3fdd21f909e23be5e3c8d9aee3a739b0b65041ff0b8637276703f65c2", bip39.SeedBytesHexString);
            //check that we can rebuild the BIP39 object using the mnemonic and passphrase and that it gives the same result 
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD), BIP39.Language.Japanese);
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
        }

        [TestMethod]
        public void JapTest22()
        {
            byte[] entropyBytes = Utilities.HexStringToBytes("18ab19a9f54a9274f03e5209a2ac8a91");
            bip39 = new BIP39(entropyBytes, ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD), BIP39.Language.Japanese);
            //check correct mnemonic sentence
            Assert.AreEqual(("うりきれ さいせい じゆう むろん とどける ぐうたら はいれつ ひけつ いずれ うちあわせ おさめる おたく").Normalize(NormalizationForm.FormKD), bip39.MnemonicSentence);
            //check correct seed
            Assert.AreEqual("3d711f075ee44d8b535bb4561ad76d7d5350ea0b1f5d2eac054e869ff7963cdce9581097a477d697a2a9433a0c6884bea10a2193647677977c9820dd0921cbde", bip39.SeedBytesHexString);
            //check that we can rebuild the BIP39 object using the mnemonic and passphrase and that it gives the same result 
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD), BIP39.Language.Japanese);
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
        }

        [TestMethod]
        public void JapTest23()
        {
            byte[] entropyBytes = Utilities.HexStringToBytes("18a2e1d81b8ecfb2a333adcb0c17a5b9eb76cc5d05db91a4");
            bip39 = new BIP39(entropyBytes, ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD), BIP39.Language.Japanese);
            //check correct mnemonic sentence
            Assert.AreEqual(("うりきれ うねる せっさたくま きもち めんきょ へいたく たまご ぜっく びじゅつかん さんそ むせる せいじ ねくたい しはらい せおう ねんど たんまつ がいけん").Normalize(NormalizationForm.FormKD), bip39.MnemonicSentence);
            //check correct seed
            Assert.AreEqual("753ec9e333e616e9471482b4b70a18d413241f1e335c65cd7996f32b66cf95546612c51dcf12ead6f805f9ee3d965846b894ae99b24204954be80810d292fcdd", bip39.SeedBytesHexString);
            //check that we can rebuild the BIP39 object using the mnemonic and passphrase and that it gives the same result 
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD), BIP39.Language.Japanese);
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
        }

        [TestMethod]
        public void JapTest24()
        {
            byte[] entropyBytes = Utilities.HexStringToBytes("15da872c95a13dd738fbf50e427583ad61f18fd99f628c417a61cf8343c90419");
            bip39 = new BIP39(entropyBytes, ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD), BIP39.Language.Japanese);
            //check correct mnemonic sentence
            Assert.AreEqual(("うちゅう ふそく ひしょ がちょう うけもつ めいそう みかん そざい いばる うけとる さんま さこつ おうさま ぱんつ しひょう めした たはつ いちぶ つうじょう てさぎょう きつね みすえる いりぐち かめれおん").Normalize(NormalizationForm.FormKD), bip39.MnemonicSentence);
            //check correct seed
            Assert.AreEqual("346b7321d8c04f6f37b49fdf062a2fddc8e1bf8f1d33171b65074531ec546d1d3469974beccb1a09263440fc92e1042580a557fdce314e27ee4eabb25fa5e5fe", bip39.SeedBytesHexString);
            //check that we can rebuild the BIP39 object using the mnemonic and passphrase and that it gives the same result 
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD), BIP39.Language.Japanese);
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
        }

        [TestMethod]
        public void JapTest25()
        {
            //these single line tests are just confirming that my static GetSeedBytesHexString method is correctly rebuilding the seed using just the supplied mnemonic sentence and the passphrase
            Assert.AreEqual("a262d6fb6122ecf45be09c50492b31f92e9beb7d9a845987a02cefda57a15f9c467a17872029a9e92299b5cbdf306e3a0ee620245cbd508959b6cb7ca637bd55", BIP39.GetSeedBytesHexString(("あいこくしん あいこくしん あいこくしん あいこくしん あいこくしん あいこくしん あいこくしん あいこくしん あいこくしん あいこくしん あいこくしん あおぞら").Normalize(NormalizationForm.FormKD), ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD)));
        }

        [TestMethod]
        public void JapTest26()
        {
            Assert.AreEqual("346b7321d8c04f6f37b49fdf062a2fddc8e1bf8f1d33171b65074531ec546d1d3469974beccb1a09263440fc92e1042580a557fdce314e27ee4eabb25fa5e5fe", BIP39.GetSeedBytesHexString(("うちゅう ふそく ひしょ がちょう うけもつ めいそう みかん そざい いばる うけとる さんま さこつ おうさま ぱんつ しひょう めした たはつ いちぶ つうじょう てさぎょう きつね みすえる いりぐち かめれおん").Normalize(NormalizationForm.FormKD), ("㍍ガバヴァぱばぐゞちぢ十人十色").Normalize(NormalizationForm.FormKD)));
        }
    }
}
