using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bitcoin.BIP39;
using Bitcoin.BitcoinUtilities;

namespace Tests
{
    /// <summary>
    /// Reproduced the BIP39 test vectors listed here: https://github.com/trezor/python-mnemonic/blob/master/vectors.json and all these unit tests are testing the BIP39 project
    /// thashiznets@yahoo.com.au
    /// v1.0.0.0
    /// Bitcoin:1ETQjMkR1NNh4jwLuN5LxY7bbip39HC9PUPSV
    /// </summary>
    [TestClass]
    public class TestMnemonicsAndSeedEnglish
    {
        BIP39 bip39;
        BIP39 bip39frommnemonic;

       [TestMethod]
        public void EngTest1()
        {
            byte[] entropyBytes = Utilities.HexStringToBytes("00000000000000000000000000000000");
            bip39 = new BIP39(entropyBytes, ("TREZOR").Normalize(NormalizationForm.FormKD));
            //check correct mnemonic sentence
            Assert.AreEqual(("abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon about").Normalize(NormalizationForm.FormKD),bip39.MnemonicSentence);
            //check correct seed
            Assert.AreEqual("c55257c360c07c72029aebc1b53c05ed0362ada38ead3e3e9efa3708e53495531f09a6987599d18264c1e1c92f2cf141630c7a3c4ab7c81b2f001698e7463b04", bip39.SeedBytesHexString);
            //check that we can rebuild the BIP39 object using the mnemonic and passphrase and that it gives the same result 
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
       }

        [TestMethod]
        public void EngTest2()
        {
            byte[] entropyBytes = Utilities.HexStringToBytes("7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f");
            bip39 = new BIP39(entropyBytes, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(("legal winner thank year wave sausage worth useful legal winner thank yellow").Normalize(NormalizationForm.FormKD), bip39.MnemonicSentence);
            Assert.AreEqual("2e8905819b8723fe2c1d161860e5ee1830318dbf49a83bd451cfb8440c28bd6fa457fe1296106559a3c80937a1c1069be3a3a5bd381ee6260e8d9739fce1f607", bip39.SeedBytesHexString);
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
        }

        [TestMethod]
        public void EngTest3()
        {
            byte[] entropyBytes = Utilities.HexStringToBytes("80808080808080808080808080808080");
            bip39 = new BIP39(entropyBytes, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(("letter advice cage absurd amount doctor acoustic avoid letter advice cage above").Normalize(NormalizationForm.FormKD), bip39.MnemonicSentence);
            Assert.AreEqual("d71de856f81a8acc65e6fc851a38d4d7ec216fd0796d0a6827a3ad6ed5511a30fa280f12eb2e47ed2ac03b5c462a0358d18d69fe4f985ec81778c1b370b652a8", bip39.SeedBytesHexString);
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
        }

        [TestMethod]
        public void EngTest4()
        {
            byte[] entropyBytes = Utilities.HexStringToBytes("ffffffffffffffffffffffffffffffff");
            bip39 = new BIP39(entropyBytes, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(("zoo zoo zoo zoo zoo zoo zoo zoo zoo zoo zoo wrong").Normalize(NormalizationForm.FormKD), bip39.MnemonicSentence);
            Assert.AreEqual("ac27495480225222079d7be181583751e86f571027b0497b5b5d11218e0a8a13332572917f0f8e5a589620c6f15b11c61dee327651a14c34e18231052e48c069", bip39.SeedBytesHexString);
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
        }

        [TestMethod]
        public void EngTest5()
        {
            byte[] entropyBytes = Utilities.HexStringToBytes("000000000000000000000000000000000000000000000000");
            bip39 = new BIP39(entropyBytes, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(("abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon agent").Normalize(NormalizationForm.FormKD), bip39.MnemonicSentence);
            Assert.AreEqual("035895f2f481b1b0f01fcf8c289c794660b289981a78f8106447707fdd9666ca06da5a9a565181599b79f53b844d8a71dd9f439c52a3d7b3e8a79c906ac845fa", bip39.SeedBytesHexString);
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
        }

        [TestMethod]
        public void EngTest6()
        {
            byte[] entropyBytes = Utilities.HexStringToBytes("7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f");
            bip39 = new BIP39(entropyBytes, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(("legal winner thank year wave sausage worth useful legal winner thank year wave sausage worth useful legal will").Normalize(NormalizationForm.FormKD), bip39.MnemonicSentence);
            Assert.AreEqual("f2b94508732bcbacbcc020faefecfc89feafa6649a5491b8c952cede496c214a0c7b3c392d168748f2d4a612bada0753b52a1c7ac53c1e93abd5c6320b9e95dd", bip39.SeedBytesHexString);
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
        }

        [TestMethod]
        public void EngTest7()
        {
            byte[] entropyBytes = Utilities.HexStringToBytes("808080808080808080808080808080808080808080808080");
            bip39 = new BIP39(entropyBytes, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(("letter advice cage absurd amount doctor acoustic avoid letter advice cage absurd amount doctor acoustic avoid letter always").Normalize(NormalizationForm.FormKD), bip39.MnemonicSentence);
            Assert.AreEqual("107d7c02a5aa6f38c58083ff74f04c607c2d2c0ecc55501dadd72d025b751bc27fe913ffb796f841c49b1d33b610cf0e91d3aa239027f5e99fe4ce9e5088cd65", bip39.SeedBytesHexString);
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
        }

        [TestMethod]
        public void EngTest8()
        {
            byte[] entropyBytes = Utilities.HexStringToBytes("ffffffffffffffffffffffffffffffffffffffffffffffff");
            bip39 = new BIP39(entropyBytes, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(("zoo zoo zoo zoo zoo zoo zoo zoo zoo zoo zoo zoo zoo zoo zoo zoo zoo when").Normalize(NormalizationForm.FormKD), bip39.MnemonicSentence);
            Assert.AreEqual("0cd6e5d827bb62eb8fc1e262254223817fd068a74b5b449cc2f667c3f1f985a76379b43348d952e2265b4cd129090758b3e3c2c49103b5051aac2eaeb890a528", bip39.SeedBytesHexString);
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
        }

        [TestMethod]
        public void EngTest9()
        {
            byte[] entropyBytes = Utilities.HexStringToBytes("0000000000000000000000000000000000000000000000000000000000000000");
            bip39 = new BIP39(entropyBytes, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(("abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon art").Normalize(NormalizationForm.FormKD), bip39.MnemonicSentence);
            Assert.AreEqual("bda85446c68413707090a52022edd26a1c9462295029f2e60cd7c4f2bbd3097170af7a4d73245cafa9c3cca8d561a7c3de6f5d4a10be8ed2a5e608d68f92fcc8", bip39.SeedBytesHexString);
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
        }

        [TestMethod]
        public void EngTest10()
        {
            byte[] entropyBytes = Utilities.HexStringToBytes("7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f7f");
            bip39 = new BIP39(entropyBytes, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(("legal winner thank year wave sausage worth useful legal winner thank year wave sausage worth useful legal winner thank year wave sausage worth title").Normalize(NormalizationForm.FormKD), bip39.MnemonicSentence);
            Assert.AreEqual("bc09fca1804f7e69da93c2f2028eb238c227f2e9dda30cd63699232578480a4021b146ad717fbb7e451ce9eb835f43620bf5c514db0f8add49f5d121449d3e87", bip39.SeedBytesHexString);
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
        }

        [TestMethod]
        public void EngTest11()
        {
            byte[] entropyBytes = Utilities.HexStringToBytes("8080808080808080808080808080808080808080808080808080808080808080");
            bip39 = new BIP39(entropyBytes, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(("letter advice cage absurd amount doctor acoustic avoid letter advice cage absurd amount doctor acoustic avoid letter advice cage absurd amount doctor acoustic bless").Normalize(NormalizationForm.FormKD), bip39.MnemonicSentence);
            Assert.AreEqual("c0c519bd0e91a2ed54357d9d1ebef6f5af218a153624cf4f2da911a0ed8f7a09e2ef61af0aca007096df430022f7a2b6fb91661a9589097069720d015e4e982f", bip39.SeedBytesHexString);
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
        }

        [TestMethod]
        public void EngTest12()
        {
            byte[] entropyBytes = Utilities.HexStringToBytes("ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff");
            bip39 = new BIP39(entropyBytes, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(("zoo zoo zoo zoo zoo zoo zoo zoo zoo zoo zoo zoo zoo zoo zoo zoo zoo zoo zoo zoo zoo zoo zoo vote").Normalize(NormalizationForm.FormKD), bip39.MnemonicSentence);
            Assert.AreEqual("dd48c104698c30cfe2b6142103248622fb7bb0ff692eebb00089b32d22484e1613912f0a5b694407be899ffd31ed3992c456cdf60f5d4564b8ba3f05a69890ad", bip39.SeedBytesHexString);
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
        }

        [TestMethod]
        public void EngTest13()
        {
            byte[] entropyBytes = Utilities.HexStringToBytes("77c2b00716cec7213839159e404db50d");
            bip39 = new BIP39(entropyBytes, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(("jelly better achieve collect unaware mountain thought cargo oxygen act hood bridge").Normalize(NormalizationForm.FormKD), bip39.MnemonicSentence);
            Assert.AreEqual("b5b6d0127db1a9d2226af0c3346031d77af31e918dba64287a1b44b8ebf63cdd52676f672a290aae502472cf2d602c051f3e6f18055e84e4c43897fc4e51a6ff", bip39.SeedBytesHexString);
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
        }

        [TestMethod]
        public void EngTest14()
        {
            byte[] entropyBytes = Utilities.HexStringToBytes("b63a9c59a6e641f288ebc103017f1da9f8290b3da6bdef7b");
            bip39 = new BIP39(entropyBytes, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(("renew stay biology evidence goat welcome casual join adapt armor shuffle fault little machine walk stumble urge swap").Normalize(NormalizationForm.FormKD), bip39.MnemonicSentence);
            Assert.AreEqual("9248d83e06f4cd98debf5b6f010542760df925ce46cf38a1bdb4e4de7d21f5c39366941c69e1bdbf2966e0f6e6dbece898a0e2f0a4c2b3e640953dfe8b7bbdc5", bip39.SeedBytesHexString);
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
        }

        [TestMethod]
        public void EngTest15()
        {
            byte[] entropyBytes = Utilities.HexStringToBytes("3e141609b97933b66a060dcddc71fad1d91677db872031e85f4c015c5e7e8982");
            bip39 = new BIP39(entropyBytes, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(("dignity pass list indicate nasty swamp pool script soccer toe leaf photo multiply desk host tomato cradle drill spread actor shine dismiss champion exotic").Normalize(NormalizationForm.FormKD), bip39.MnemonicSentence);
            Assert.AreEqual("ff7f3184df8696d8bef94b6c03114dbee0ef89ff938712301d27ed8336ca89ef9635da20af07d4175f2bf5f3de130f39c9d9e8dd0472489c19b1a020a940da67", bip39.SeedBytesHexString);
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
        }

        [TestMethod]
        public void EngTest16()
        {
            byte[] entropyBytes = Utilities.HexStringToBytes("0460ef47585604c5660618db2e6a7e7f");
            bip39 = new BIP39(entropyBytes, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(("afford alter spike radar gate glance object seek swamp infant panel yellow").Normalize(NormalizationForm.FormKD), bip39.MnemonicSentence);
            Assert.AreEqual("65f93a9f36b6c85cbe634ffc1f99f2b82cbb10b31edc7f087b4f6cb9e976e9faf76ff41f8f27c99afdf38f7a303ba1136ee48a4c1e7fcd3dba7aa876113a36e4", bip39.SeedBytesHexString);
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
        }

        [TestMethod]
        public void EngTest17()
        {
            byte[] entropyBytes = Utilities.HexStringToBytes("72f60ebac5dd8add8d2a25a797102c3ce21bc029c200076f");
            bip39 = new BIP39(entropyBytes, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(("indicate race push merry suffer human cruise dwarf pole review arch keep canvas theme poem divorce alter left").Normalize(NormalizationForm.FormKD), bip39.MnemonicSentence);
            Assert.AreEqual("3bbf9daa0dfad8229786ace5ddb4e00fa98a044ae4c4975ffd5e094dba9e0bb289349dbe2091761f30f382d4e35c4a670ee8ab50758d2c55881be69e327117ba", bip39.SeedBytesHexString);
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
        }

        [TestMethod]
        public void EngTest18()
        {
            byte[] entropyBytes = Utilities.HexStringToBytes("2c85efc7f24ee4573d2b81a6ec66cee209b2dcbd09d8eddc51e0215b0b68e416");
            bip39 = new BIP39(entropyBytes, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(("clutch control vehicle tonight unusual clog visa ice plunge glimpse recipe series open hour vintage deposit universe tip job dress radar refuse motion taste").Normalize(NormalizationForm.FormKD), bip39.MnemonicSentence);
            Assert.AreEqual("fe908f96f46668b2d5b37d82f558c77ed0d69dd0e7e043a5b0511c48c2f1064694a956f86360c93dd04052a8899497ce9e985ebe0c8c52b955e6ae86d4ff4449", bip39.SeedBytesHexString);
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
        }

        [TestMethod]
        public void EngTest19()
        {
            byte[] entropyBytes = Utilities.HexStringToBytes("eaebabb2383351fd31d703840b32e9e2");
            bip39 = new BIP39(entropyBytes, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(("turtle front uncle idea crush write shrug there lottery flower risk shell").Normalize(NormalizationForm.FormKD), bip39.MnemonicSentence);
            Assert.AreEqual("bdfb76a0759f301b0b899a1e3985227e53b3f51e67e3f2a65363caedf3e32fde42a66c404f18d7b05818c95ef3ca1e5146646856c461c073169467511680876c", bip39.SeedBytesHexString);
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
        }

        [TestMethod]
        public void EngTest20()
        {
            byte[] entropyBytes = Utilities.HexStringToBytes("7ac45cfe7722ee6c7ba84fbc2d5bd61b45cb2fe5eb65aa78");
            bip39 = new BIP39(entropyBytes, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(("kiss carry display unusual confirm curtain upgrade antique rotate hello void custom frequent obey nut hole price segment").Normalize(NormalizationForm.FormKD), bip39.MnemonicSentence);
            Assert.AreEqual("ed56ff6c833c07982eb7119a8f48fd363c4a9b1601cd2de736b01045c5eb8ab4f57b079403485d1c4924f0790dc10a971763337cb9f9c62226f64fff26397c79", bip39.SeedBytesHexString);
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
        }

        [TestMethod]
        public void EngTest21()
        {
            byte[] entropyBytes = Utilities.HexStringToBytes("4fa1a8bc3e6d80ee1316050e862c1812031493212b7ec3f3bb1b08f168cabeef");
            bip39 = new BIP39(entropyBytes, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(("exile ask congress lamp submit jacket era scheme attend cousin alcohol catch course end lucky hurt sentence oven short ball bird grab wing top").Normalize(NormalizationForm.FormKD), bip39.MnemonicSentence);
            Assert.AreEqual("095ee6f817b4c2cb30a5a797360a81a40ab0f9a4e25ecd672a3f58a0b5ba0687c096a6b14d2c0deb3bdefce4f61d01ae07417d502429352e27695163f7447a8c", bip39.SeedBytesHexString);
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
        }

        [TestMethod]
        public void EngTest22()
        {
            byte[] entropyBytes = Utilities.HexStringToBytes("18ab19a9f54a9274f03e5209a2ac8a91");
            bip39 = new BIP39(entropyBytes, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(("board flee heavy tunnel powder denial science ski answer betray cargo cat").Normalize(NormalizationForm.FormKD), bip39.MnemonicSentence);
            Assert.AreEqual("6eff1bb21562918509c73cb990260db07c0ce34ff0e3cc4a8cb3276129fbcb300bddfe005831350efd633909f476c45c88253276d9fd0df6ef48609e8bb7dca8", bip39.SeedBytesHexString);
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
        }

        [TestMethod]
        public void EngTest23()
        {
            byte[] entropyBytes = Utilities.HexStringToBytes("18a2e1d81b8ecfb2a333adcb0c17a5b9eb76cc5d05db91a4");
            bip39 = new BIP39(entropyBytes, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(("board blade invite damage undo sun mimic interest slam gaze truly inherit resist great inject rocket museum chief").Normalize(NormalizationForm.FormKD), bip39.MnemonicSentence);
            Assert.AreEqual("f84521c777a13b61564234bf8f8b62b3afce27fc4062b51bb5e62bdfecb23864ee6ecf07c1d5a97c0834307c5c852d8ceb88e7c97923c0a3b496bedd4e5f88a9", bip39.SeedBytesHexString);
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
        }

        [TestMethod]
        public void EngTest24()
        {
            byte[] entropyBytes = Utilities.HexStringToBytes("15da872c95a13dd738fbf50e427583ad61f18fd99f628c417a61cf8343c90419");
            bip39 = new BIP39(entropyBytes, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(("beyond stage sleep clip because twist token leaf atom beauty genius food business side grid unable middle armed observe pair crouch tonight away coconut").Normalize(NormalizationForm.FormKD), bip39.MnemonicSentence);
            Assert.AreEqual("b15509eaa2d09d3efd3e006ef42151b30367dc6e3aa5e44caba3fe4d3e352e65101fbdb86a96776b91946ff06f8eac594dc6ee1d3e82a42dfe1b40fef6bcc3fd", bip39.SeedBytesHexString);
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
        }

        [TestMethod]
        public void EngTest25()
        {
            //undocumented test vector........maximum 8192 entropy bits.....you love it :)
            byte[] entropyBytes = Utilities.HexStringToBytes("00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000");
            bip39 = new BIP39(entropyBytes, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(("abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon able wine cool course anchor ability scare tag emerge liquid robust jacket canal brown sustain stand blanket pumpkin recall satisfy valve filter monitor target").Normalize(NormalizationForm.FormKD), bip39.MnemonicSentence);
            Assert.AreEqual("4ef11996949550b4414276288179ebac31c0b716ec8e57da4b8f24277603e6db8ea8871aaaa2708d8d37b3031091a80544fef238c6e0bf90a65f9d476ffd2214", bip39.SeedBytesHexString);
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
        }

        [TestMethod]
        public void EngTest26()
        {
            //undocumented test vector........maximum 8192 entropy bits.....you love it :)
            byte[] entropyBytes = Utilities.HexStringToBytes("15da872c95a13dd738fbf50e427583ad61f18fd99f628c417a61cf8343c9041915da872c95a13dd738fbf50e427583ad61f18fd99f628c417a61cf8343c9041915da872c95a13dd738fbf50e427583ad61f18fd99f628c417a61cf8343c9041915da872c95a13dd738fbf50e427583ad61f18fd99f628c417a61cf8343c9041915da872c95a13dd738fbf50e427583ad61f18fd99f628c417a61cf8343c9041915da872c95a13dd738fbf50e427583ad61f18fd99f628c417a61cf8343c9041915da872c95a13dd738fbf50e427583ad61f18fd99f628c417a61cf8343c9041915da872c95a13dd738fbf50e427583ad61f18fd99f628c417a61cf8343c9041915da872c95a13dd738fbf50e427583ad61f18fd99f628c417a61cf8343c9041915da872c95a13dd738fbf50e427583ad61f18fd99f628c417a61cf8343c9041915da872c95a13dd738fbf50e427583ad61f18fd99f628c417a61cf8343c9041915da872c95a13dd738fbf50e427583ad61f18fd99f628c417a61cf8343c9041915da872c95a13dd738fbf50e427583ad61f18fd99f628c417a61cf8343c9041915da872c95a13dd738fbf50e427583ad61f18fd99f628c417a61cf8343c9041915da872c95a13dd738fbf50e427583ad61f18fd99f628c417a61cf8343c9041915da872c95a13dd738fbf50e427583ad61f18fd99f628c417a61cf8343c9041915da872c95a13dd738fbf50e427583ad61f18fd99f628c417a61cf8343c9041915da872c95a13dd738fbf50e427583ad61f18fd99f628c417a61cf8343c9041915da872c95a13dd738fbf50e427583ad61f18fd99f628c417a61cf8343c9041915da872c95a13dd738fbf50e427583ad61f18fd99f628c417a61cf8343c9041915da872c95a13dd738fbf50e427583ad61f18fd99f628c417a61cf8343c9041915da872c95a13dd738fbf50e427583ad61f18fd99f628c417a61cf8343c9041915da872c95a13dd738fbf50e427583ad61f18fd99f628c417a61cf8343c9041915da872c95a13dd738fbf50e427583ad61f18fd99f628c417a61cf8343c9041915da872c95a13dd738fbf50e427583ad61f18fd99f628c417a61cf8343c9041915da872c95a13dd738fbf50e427583ad61f18fd99f628c417a61cf8343c9041915da872c95a13dd738fbf50e427583ad61f18fd99f628c417a61cf8343c9041915da872c95a13dd738fbf50e427583ad61f18fd99f628c417a61cf8343c9041915da872c95a13dd738fbf50e427583ad61f18fd99f628c417a61cf8343c9041915da872c95a13dd738fbf50e427583ad61f18fd99f628c417a61cf8343c9041915da872c95a13dd738fbf50e427583ad61f18fd99f628c417a61cf8343c9041915da872c95a13dd738fbf50e427583ad61f18fd99f628c417a61cf8343c90419");
            bip39 = new BIP39(entropyBytes, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(("beyond stage sleep clip because twist token leaf atom beauty genius food business side grid unable middle armed observe pair crouch tonight away cargo surround defense century draw talent organ used peace draw project twice sentence body under laugh face door spread initial alley develop link gold robust mango gorilla hair knife inform law stage sign intact buddy flash toast work soul mechanic market kidney attack this maple motion arrive first extend clutch public exhaust purpose moral whisper decorate exchange lonely help ladder cabbage okay rally country consider gift lab special must dose memory head tortoise noble antique into impose satisfy mango antenna race pulp auto glue rebel wage economy album equip sort borrow venture amused mule unhappy bronze naive patrol upgrade soda wave extend cancel stock interest giggle midnight wait disagree churn camera trumpet delay local bundle donate cram frozen drum rather reflect differ right discover tube tomorrow depart attitude promote various learn guitar shallow series rule mango vacant duck else alien close position north final chicken strong sick wool broken chef scrub remain dilemma more smooth suffer blush bless couch dignity half simple camp earth relax index enlist lumber road decline text drum lumber flag stove march cradle sunset wild perfect load plastic treat artist junior advice silly issue atom sing spatial warrior train winner position mountain twelve depart rail shiver will panda behave aware visit brother script august calm boil put peace float foam page friend buyer vital improve output also stock web disorder crop glad ginger future seminar wealth peanut catch lobster beyond stage sleep clip because twist token leaf atom beauty genius food business side grid unable middle armed observe pair crouch tonight away cargo surround defense century draw talent organ used peace draw project twice sentence body under laugh face door spread initial alley develop link gold robust mango gorilla hair knife inform law stage sign intact buddy flash toast work soul mechanic market kidney attack this maple motion arrive first extend clutch public exhaust purpose moral whisper decorate exchange lonely help ladder cabbage okay rally country consider gift lab special must dose memory head tortoise noble antique into impose satisfy mango antenna race pulp auto glue rebel wage economy album equip sort borrow venture amused mule unhappy bronze naive patrol upgrade soda wave extend cancel stock interest giggle midnight wait disagree churn camera trumpet delay local bundle donate cram frozen drum rather reflect differ right discover tube tomorrow depart attitude promote various learn guitar shallow series rule mango vacant duck else alien close position north final chicken strong sick wool broken chef scrub remain dilemma more smooth suffer blush bless couch dignity half simple camp earth relax index enlist lumber road decline text drum lumber flag stove march cradle sunset wild perfect load plastic treat artist junior advice silly issue atom sing spatial warrior train winner position mountain twelve depart rail shiver will panda behave aware visit brother script august calm boil put peace float foam page friend buyer vital improve output also stock web disorder crop glad ginger future seminar wealth peanut catch lobster beyond stage sleep clip because twist token leaf atom beauty genius food business side grid unable middle armed observe pair crouch tonight away cargo surround defense century draw talent organ used peace draw project twice sentence body under laugh face door spread initial alley develop link gold robust mango gorilla hair knife inform law stage sign intact buddy flash toast work soul mechanic market kidney attack this maple motion arrive first extend clutch public exhaust purpose moral whisper decorate exchange lonely help ladder cabbage okay rally country consider gift lab special must dose memory head tortoise noble antique into impose satisfy mango antenna race pulp auto glue rebel wage economy album equip sort borrow venture amused mule unhappy bronze naive patrol upgrade soda wave extend cancel stock interest giggle midnight wait disagree churn camera trumpet delay local bundle donate cram frozen drum rather reflect differ right discover tube tomorrow depart attitude promote various learn guitar shallow series rule mango vacant duck else alien close position north final chicken strong sick wool broken chef scrub remain dilemma more smooth suffer blush bless couch dignity half simple camp earth relax index enlist lumber road decline text drum lumber flag stove march cradle sunset wild perfect load plastic treat artist junior advice silly issue atom sing spatial warrior train winner position mountain twelve depart rail shiver will panda behave aware visit brother script august calm boring job hurt future grunt crash express rapid chaos believe very gloom hospital legal whip mule jazz refuse noble tilt artefact mad antique suggest").Normalize(NormalizationForm.FormKD), bip39.MnemonicSentence);
            Assert.AreEqual("37f0dfa9e39ec453ca5fe695ea786d399aa9d607e552b3fb9479935bed9d70b7c14524393450174ffcb3518692548b4cb1ead41231dab966f35bcee8e7b18763", bip39.SeedBytesHexString);
            bip39frommnemonic = new BIP39(bip39.MnemonicSentence, ("TREZOR").Normalize(NormalizationForm.FormKD));
            Assert.AreEqual(Utilities.BytesToHexString(bip39.EntropyBytes), Utilities.BytesToHexString(bip39frommnemonic.EntropyBytes));
            Assert.AreEqual(bip39.SeedBytesHexString, bip39frommnemonic.SeedBytesHexString);
        }

        [TestMethod]
        public void EngTest27()
        {
            //these single line tests are just confirming that my static GetSeedBytesHexString method is correctly rebuilding the seed using just the supplied mnemonic sentence and the passphrase
            Assert.AreEqual("c55257c360c07c72029aebc1b53c05ed0362ada38ead3e3e9efa3708e53495531f09a6987599d18264c1e1c92f2cf141630c7a3c4ab7c81b2f001698e7463b04", BIP39.GetSeedBytesHexString(("abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon about").Normalize(NormalizationForm.FormKD), ("TREZOR").Normalize(NormalizationForm.FormKD))); 
        }

        [TestMethod]
        public void EngTest28()
        {
            Assert.AreEqual("65f93a9f36b6c85cbe634ffc1f99f2b82cbb10b31edc7f087b4f6cb9e976e9faf76ff41f8f27c99afdf38f7a303ba1136ee48a4c1e7fcd3dba7aa876113a36e4", BIP39.GetSeedBytesHexString(("afford alter spike radar gate glance object seek swamp infant panel yellow").Normalize(NormalizationForm.FormKD), ("TREZOR").Normalize(NormalizationForm.FormKD)));
        }

        [TestMethod]
        public void EngTest29()
        {
            //undocumented test vector using mnemonic sentence supplied independent from any of our wordlists
            Assert.AreEqual("88997f2b8047064d207555c21ea5e970a82e726b412077d9f24393beb535baa8b35437319b5e62b419c0be73c6ba216dc8db11896938881cb298542b41c7f5a5", BIP39.GetSeedBytesHexString(("carcenogenic spiderpig sheep batman digger manly scooter about abandon tree footpath necter").Normalize(NormalizationForm.FormKD), ("TREZOR").Normalize(NormalizationForm.FormKD)));
        }

         [TestMethod]
        public void EngTest30()
        {
            Assert.AreEqual("2e8905819b8723fe2c1d161860e5ee1830318dbf49a83bd451cfb8440c28bd6fa457fe1296106559a3c80937a1c1069be3a3a5bd381ee6260e8d9739fce1f607", BIP39.GetSeedBytesHexString(("legal winner thank year wave sausage worth useful legal winner thank yellow").Normalize(NormalizationForm.FormKD), ("TREZOR").Normalize(NormalizationForm.FormKD)));
        }

         [TestMethod]
         public void EngTest31()
         {
             Assert.AreEqual("b15509eaa2d09d3efd3e006ef42151b30367dc6e3aa5e44caba3fe4d3e352e65101fbdb86a96776b91946ff06f8eac594dc6ee1d3e82a42dfe1b40fef6bcc3fd", BIP39.GetSeedBytesHexString(("beyond stage sleep clip because twist token leaf atom beauty genius food business side grid unable middle armed observe pair crouch tonight away coconut").Normalize(NormalizationForm.FormKD), ("TREZOR").Normalize(NormalizationForm.FormKD)));
         }
         
    }
}
