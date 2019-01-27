using NUnit.Framework;
using VS4Mac.TextGenerator.Services;

namespace VS4Mac.TextGenerator.Tests
{
    [TestFixture]
    public class TextGeneratorServiceTests
    {
        [Test]
        public void GenerateWordsTest()
        {
            var textGeneratorService = new TextGeneratorService();
            var words = textGeneratorService.GenerateWords(5);

            Assert.AreEqual(5, words.Length);
        }

        [Test]
        public void GenerateSentencesTest()
        {
            var textGeneratorService = new TextGeneratorService();
            var words = textGeneratorService.GenerateSentences(2);

            Assert.AreEqual(2, words.Length);
        }

        [Test]
        public void GenerateCharactersTest()
        {
            var textGeneratorService = new TextGeneratorService();
            var words = textGeneratorService.GenerateCharacters(5);

            Assert.AreEqual(1, words.Length);
        }
    }
}