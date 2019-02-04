using NUnit.Framework;
using System;
using VS4Mac.TextGenerator.Services;

namespace VS4Mac.TextGenerator.Tests
{
    [TestFixture]
    public class JeffsumGeneratorServiceTest
    {
        [Test]
        public void GenerateWordsTest()
        {
            var jeffsumGeneratorService = new JeffsumGeneratorService();
            var words = jeffsumGeneratorService.GenerateWords(5);

            Assert.AreEqual(5, words.Length);
        }

        [Test]
        public void GenerateSentencesTest()
        {
            var jeffsumGeneratorService = new JeffsumGeneratorService();
            var words = jeffsumGeneratorService.GenerateSentences(2);

            Assert.AreEqual(2, words.Length);
        }

        [Test]
        public void GenerateCharactersTest()
        {
            var jeffsumGeneratorService = new JeffsumGeneratorService();
            var words = jeffsumGeneratorService.GenerateCharacters(5);

            Assert.AreEqual(1, words.Length);
            Assert.AreEqual(5, words[0].Length);
        }

    }
}
