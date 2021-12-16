using System;
using System.Linq;

namespace WordDetector
{
    class Program
    {
        static void Main()
        {
            var reader = new FileReader(path: @"..\..\..\Vocabulary\de-dictionary.tsv");
            WordBreaker breaker = new WordBreaker(words: reader.GetWords());

            while (true)
            {
                var normalizeWord = Console.ReadLine();

                if (string.IsNullOrEmpty(normalizeWord))
                    break;

                var result = breaker.GetSubWords(normalizeWord);
                if (!result.Any())
                {
                    Console.WriteLine("no match found");
                }
                else
                {
                    foreach (var item in result)
                        Console.WriteLine($"\t{item}");
                }
            }
        }
    }
}
