using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bitcoin.BIP39;

namespace Tests
{
    [TestClass]
    public class TestAutoLanguageDetect
    {
        [TestMethod]
        public void TestKnownEnglish()
        {
            Assert.AreEqual(BIP39.Language.English, BIP39.AutoDetectLanguageOfWords(new string[] { "abandon", "abandon", "abandon", "abandon", "abandon", "abandon", "abandon", "abandon", "abandon", "abandon", "abandon", "about" }));
        }

        [TestMethod]
        public void TestKnownJapenese()
        {
            Assert.AreEqual(BIP39.Language.Japanese, BIP39.AutoDetectLanguageOfWords(new string[] { "あいこくしん", "あいさつ", "あいだ", "あおぞら", "あかちゃん", "あきる", "あけがた", "あける", "あこがれる", "あさい", "あさひ", "あしあと", "あじわう", "あずかる", "あずき", "あそぶ", "あたえる", "あたためる", "あたりまえ", "あたる", "あつい", "あつかう", "あっしゅく", "あつまり", "あつめる", "あてな", "あてはまる", "あひる", "あぶら", "あぶる", "あふれる", "あまい", "あまど", "あまやかす", "あまり", "あみもの", "あめりか" }));
        }

        [TestMethod]
        public void TestKnownSpanish()
        {
            Assert.AreEqual(BIP39.Language.Spanish, BIP39.AutoDetectLanguageOfWords(new string[] { "yoga", "yogur", "zafiro", "zanja", "zapato", "zarza", "zona", "zorro", "zumo", "zurdo" }));
        }

        [TestMethod]
        public void TestKnownChineseSimplified()
        {
            Assert.AreEqual(BIP39.Language.ChineseSimplified, BIP39.AutoDetectLanguageOfWords(new string[] { "的", "一", "是", "在", "不", "了", "有", "和", "人", "这" }));
        }

        [TestMethod]
        public void TestKnownChineseTraditional()
        {
            Assert.AreEqual(BIP39.Language.ChineseTraditional, BIP39.AutoDetectLanguageOfWords(new string[] { "的", "一", "是", "在", "不", "了", "有", "和", "載" }));
        }

        [TestMethod]
        public void TestKnownFrench()
        {
            Assert.AreEqual(BIP39.Language.French, BIP39.AutoDetectLanguageOfWords(new string[] { "abaisser", "brutal", "bulletin", "circuler", "citoyen", "impact", "joyeux", "massif", "nébuleux" }));
        }

        [TestMethod]
        public void TestKnownUnknown()
        {
            Assert.AreEqual(BIP39.Language.Unknown, BIP39.AutoDetectLanguageOfWords(new string[] { "gffgfg", "khjkjk", "kjkkj" }));
        }
    }
}
