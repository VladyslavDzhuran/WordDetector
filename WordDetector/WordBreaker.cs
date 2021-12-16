using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordDetector
{
    public class WordBreaker
    {
        private readonly HashSet<string> _indexedWords;
        private readonly int _smallestWord;

        public WordBreaker(IEnumerable<string> words, int subWordMinLenght = 3)
        {
            _indexedWords = new HashSet<string>();
            _smallestWord = subWordMinLenght;

            SetVocabulary(words);
        }
        private void SetVocabulary(IEnumerable<string> words)
        {
            foreach (var item in words)
            {
                _indexedWords.Add(item.ToLower());
            }
        }
        public List<string> GetSubWords(string word)
        {
            if (word == null)
            {
                throw new NullReferenceException();
            }
            var result = new List<string>();
            var i = 0;
            while (true)
            {
                var subLenght = word.Length - i;
                if (subLenght < _smallestWord)
                {
                    break;
                }

                for (var j = subLenght; j >= _smallestWord; j--)
                {
                    var subWord = word.Substring(i, j);
                    if (_indexedWords.Contains(subWord.ToLower()))
                    {
                        result.Add(subWord);
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
