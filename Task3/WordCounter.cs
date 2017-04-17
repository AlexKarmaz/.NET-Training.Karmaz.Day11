using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Task3
{
    /// <summary>
    /// Contains a method for counting words in the text
    /// </summary>
    public static class WordCounter
    {
        /// <summary>
        /// Calculates frequency of all words located in the file
        /// </summary>
        /// <param name="path">Path to the file</param>
        /// <returns>Dictionary of words sorted in ascending order of word frequency</returns>
        /// <exception cref="ArgumentNullException">One of argument is null referenced</exception>
        /// <exception cref="ArgumentException">One of argument or file is blank</exception>
        /// <exception cref="FileNotFoundException">One of argument or file is blank</exception>
        public static Dictionary<string, int> FindFrequency(string path)
        {
            string baseFolder = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = baseFolder + path;
            if (ReferenceEquals(filePath, null))
                throw new ArgumentNullException();
            if (filePath.Equals(string.Empty))
                throw new ArgumentException();
            if (!File.Exists(filePath))
               throw new FileNotFoundException();

            Dictionary<string, int> dictionaryCounter = new Dictionary<string, int>();
            char[] separators = { '.', ',', ';', '-', ' ', '(', ')', '?', '!', '\r', '\n', '\t' };
            string[] words = File.ReadAllText(filePath).ToUpperInvariant().Split(separators, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i++)
            {
                if (dictionaryCounter.ContainsKey(words[i]))
                    dictionaryCounter[words[i]]++;
                else
                    dictionaryCounter.Add(words[i], 1);
            }

            return dictionaryCounter;
        }   
    }
}
