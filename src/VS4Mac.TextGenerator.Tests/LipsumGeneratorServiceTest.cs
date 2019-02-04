using NUnit.Framework;
using VS4Mac.TextGenerator.Services;

namespace VS4Mac.TextGenerator.Tests
{
    [TestFixture]
    public class LipsumGeneratorServiceTest
    {
        [Test]
        public void GenerateWordsTest()
        {
            var textGeneratorService = new LipsumGeneratorService();
            var words = textGeneratorService.GenerateWords(5);

            Assert.AreEqual(5, words.Length);
        }

        [Test]
        public void GenerateSentencesTest()
        {
            var textGeneratorService = new LipsumGeneratorService();
            var words = textGeneratorService.GenerateSentences(2);

            Assert.AreEqual(2, words.Length);
        }

        [Test]
        public void GenerateCharactersTest()
        {
            var textGeneratorService = new LipsumGeneratorService();
            var words = textGeneratorService.GenerateCharacters(5);

            Assert.AreEqual(1, words.Length);
            Assert.AreEqual(5, words[0].Length);
        }

        [Test]
        public void FirstGenerateCharactersAreNotNewLineOrReturnTest()
        {
            var textGeneratorService = new LipsumGeneratorService();
            var words = textGeneratorService.GenerateCharacters(3);
            var characters = words[0];

            Assert.That(characters[0], Is.Not.EqualTo('\n').And.Not.EqualTo('\r'));
            Assert.That(characters[1], Is.Not.EqualTo('\n').And.Not.EqualTo('\r'));
            Assert.That(characters[2], Is.Not.EqualTo('\n').And.Not.EqualTo('\r'));
        }
    }
}