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
    }
}
