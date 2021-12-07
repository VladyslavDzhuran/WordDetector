using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace WordDetector
{
    public class FileReader
    {
        private readonly string _path;

        public FileReader(string path) 
        {
            if (!File.Exists(path))
            {
                throw new Exception();
            }
            _path = path;
        }

        public IEnumerable<string> GetWords() 
        {
            using (var fileStream = new FileStream(_path, FileMode.Open, FileAccess.Read))
            {
                using (var fileReader = new StreamReader(fileStream, Encoding.UTF8)) 
                {
                    return Regex.Split(fileReader.ReadToEnd(), @"([A-Z][a-zÄÖÜäöüẞß]*)").Select(word => word.Trim());
                }
            }
        
        }
    }
}
