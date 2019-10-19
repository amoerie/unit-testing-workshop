using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestingWorkshop.Core.Exercise01WordCombinationsFinder
{
    /// <summary>
    /// Finds words that are a combination of two other words in the same list.
    /// 
    /// Example:
    /// 
    ///     When a list of words = [ "al", "albums", "bums", "disk" ] and requested length = 6
    ///     then "albums" is a valid combination because it has 6 characters and consists of "al" and "bums"
    ///     which also appear in the list
    ///     
    /// </summary>
    public interface IWordCombinationsFinder
    {
        IEnumerable<WordCombination> FindCombinations(IEnumerable<string> words, int requestedLength);
    }

    public class WordCombinationsFinder : IWordCombinationsFinder
    {
        public IEnumerable<WordCombination> FindCombinations(IEnumerable<string> words, int requestedLength)
        {
            var wordsArray = words.ToArray();
            // Requested length = 8? We'll only keep words of length 2-6 
            var wordGraphsPerLength = new WordGraph[requestedLength - 3];
            for (int i = 0; i < wordGraphsPerLength.Length; i++)
            {
                var length = i + 2;
                wordGraphsPerLength[i] = new WordGraph(length, ' ');
            }

            WordGraph GetWordGraph(int length)
            {
                return wordGraphsPerLength[length - 2];
            }

            var wordsWithRequestedLength = new List<string>();

            for (int wordIndex = 0; wordIndex < wordsArray.Length; wordIndex++)
            {
                string word = wordsArray[wordIndex].ToLower();
                var wordLength = word.Length;
                if (wordLength == requestedLength)
                {
                    wordsWithRequestedLength.Add(word);
                    continue;
                }

                if (wordLength < 2 || wordLength > requestedLength - 2)
                {
                    continue;
                }

                var wordGraph = GetWordGraph(wordLength);
                for (var characterIndex = 0; characterIndex < wordLength; characterIndex++)
                {
                    var character = word[characterIndex];
                    wordGraph = wordGraph.GetOrCreateNode(character);
                }
            }


            var paths = new List<WordGraphPath>(8);
            for (int lengthOfFirstWord = 2; lengthOfFirstWord < requestedLength - 1; lengthOfFirstWord++)
            {
                var lengthOfSecondWord = requestedLength - lengthOfFirstWord;
                var firstWordGraph = GetWordGraph(lengthOfFirstWord);
                var secondWordGraph = GetWordGraph(lengthOfSecondWord);
                var path = new WordGraphPath(firstWordGraph, secondWordGraph);
                paths.Add(path);
            }

            var combinations = new List<WordCombination>(512);
            for (var w = 0; w < wordsWithRequestedLength.Count; w++)
            {
                var word = wordsWithRequestedLength[w];
                for (var p = 0; p < paths.Count; p++)
                {
                    var path = paths[p];
                    var wordCombination = path.Walk(word, requestedLength);
                    if (wordCombination != null)
                        combinations.Add(wordCombination);
                }
            }

            return combinations;
        }
    }

    public class WordGraph
    {
        public char Char { get; }
        public int Length { get; set; }
        public IDictionary<char, WordGraph> Nodes;

        public WordGraph(int length, char character)
        {
            Length = length;
            Char = character;
            Nodes = new Dictionary<char, WordGraph>();
        }

        public WordGraph GetOrCreateNode(char character)
        {
            if (!Nodes.TryGetValue(character, out WordGraph wordGraph))
            {
                Nodes[character] = wordGraph = new WordGraph(Length - 1, character);
            }

            return wordGraph;
        }

        public override string ToString() => Char.ToString();
    }

    public class WordGraphPath
    {
        private readonly WordGraph _firstWordGraph;
        private readonly WordGraph _secondWordGraph;

        public WordGraphPath(WordGraph firstWordGraph, WordGraph secondWordGraph)
        {
            _firstWordGraph = firstWordGraph;
            _secondWordGraph = secondWordGraph;
        }

        public WordCombination Walk(string word, int requestedLength)
        {
            var firstWordEnd = _firstWordGraph;
            var secondWordEnd = _secondWordGraph;
            var firstWordLength = _firstWordGraph.Length;
            var secondWordLength = _secondWordGraph.Length;
            var characterIndex = 0;
            while (characterIndex < word.Length
                   && characterIndex < firstWordLength
                   && firstWordEnd.Nodes.TryGetValue(word[characterIndex], out firstWordEnd))
            {
                characterIndex++;
            }

            if (characterIndex < firstWordLength)
                return null;

            while (characterIndex < word.Length
                   && (characterIndex - firstWordLength) < secondWordLength
                   && secondWordEnd.Nodes.TryGetValue(word[characterIndex], out secondWordEnd))
            {
                characterIndex++;
            }

            if (characterIndex < requestedLength)
                return null;

            return new WordCombination
            {
                Word1 = word.Substring(0, firstWordLength),
                Word2 = word.Substring(firstWordLength, secondWordLength),
                Combination = word
            };
        }
    }
}
