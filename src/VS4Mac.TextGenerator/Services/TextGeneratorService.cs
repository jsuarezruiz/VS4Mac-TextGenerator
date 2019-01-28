using System.Linq;
using NLipsum.Core;

namespace VS4Mac.TextGenerator.Services
{
    public class TextGeneratorService : ITextGeneratorService
    {
        LipsumGenerator _generator;

        public TextGeneratorService()
        {
            _generator = new LipsumGenerator();
        }

        public string[] GenerateWords(int numberOfWords)
        {
            string[] words = _generator.GenerateWords(numberOfWords);

            return words;
        }

        public string[] GenerateCharacters(int numberOfChars)
        {
            //First three characters are \n or \r
            var words = _generator.GenerateCharacters(numberOfChars + 3);
            words[0] = words[0].Remove(0, 3);
            
            return words;
        }

        public string[] GenerateSentences(int numberOfSentences)
        {
            string[] words = _generator.GenerateSentences(numberOfSentences);

            return words;
        }

        public string GenerateLipsumHtml(int count)
        {
            string html = _generator.GenerateLipsumHtml(count);

            return html;
        }
    }
}