using System;
using System.Collections.Generic;

namespace VS4Mac.TextGenerator.Services
{
    public interface ITextGeneratorService
    {
        string[] GenerateCharacters(int numberOfChars);
        string[] GenerateWords(int numberOfWords);
        string[] GenerateSentences(int numberOfSentences);
    }
}
