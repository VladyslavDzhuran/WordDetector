using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordDetector
{
    public class LenghtFilter
    {
        private readonly Dictionary<int, List<string>> _indexedWords;
        private readonly int _smallestWord;

        public LenghtFilter(IEnumerable<string> words, int subWordMinLenght = 3) 
        {
            _indexedWords = new Dictionary<int, List<string>>();
            _smallestWord = subWordMinLenght;

            SetVocabulary(words);
        }
        private void SetVocabulary(IEnumerable<string> words)
        {
            foreach (var word in words) 
            {
                if (word.Length<_smallestWord)
                {
                    continue;
                }

                if (!_indexedWords.TryGetValue(word.Length, out var wordIndex))
                {
                    wordIndex = new List<string>();
                    _indexedWords.Add(word.Length, wordIndex);
                }
                wordIndex.Add(word);
            }
        }
        public List<string> GetSubWords(string word) 
        {
            if (word==null)
            {
                throw new NullReferenceException();
            }
            var result = new List<string>();
            var i = 0;
            while (true)
            {
                var subLenght = word.Length - i;
                if (subLenght<_smallestWord)
                {
                    break;
                }

                for (var j = subLenght; j >= _smallestWord; j--)
                {
                    var subWord = word.Substring(i, j);
                    if (_indexedWords.TryGetValue(j, out var wordIndex))
                    {
                        if (!wordIndex.Any(x=> x.ToLower()==subWord.ToLower()))
                        {
                            continue;
                        }
                        result.Add(subWord.ToLower());
                        i += j - 1;
                        break;
                    }
                }
                i++;
            }
            return result;
        }

    }
}
