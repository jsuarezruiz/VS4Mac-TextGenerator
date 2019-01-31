using System;
using System.Linq;
using Jeffsum;

namespace VS4Mac.TextGenerator.Services
{
    public class JeffsumGeneratorService : ITextGeneratorService
    {
        public string[] GenerateCharacters(int numberOfChars)
        {
            var quotes = string.Join(" ", Goldblum.ReceiveTheJeff(numberOfChars, JeffsumType.Quotes));
            return new string[] { quotes.Substring(0, numberOfChars) };
        }

        public string[] GenerateSentences(int numberOfSentences)
        {
            return Goldblum.ReceiveTheJeff(numberOfSentences, JeffsumType.Quotes).ToArray();
        }

        public string[] GenerateWords(int numberOfWords)
        {
            return Goldblum.ReceiveTheJeff(numberOfWords, JeffsumType.Words).ToArray();
        }
    }
}
