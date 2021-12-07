using System;

namespace WordDetector
{
    class Program
    {
        static void Main(string[] args)
        {
			var reader = new FileReader(path: @"C:\words\dict");
			LenghtFilter breaker = new LenghtFilter(words: reader.GetWords());

			while (true)
			{
				var normalizeWord = Console.ReadLine();

				if (string.IsNullOrEmpty(normalizeWord))
					break;

				var result = breaker.GetSubWords(normalizeWord);
				foreach (var item in result)
					Console.WriteLine($"\t{item}");
			}
		}
    }
}
