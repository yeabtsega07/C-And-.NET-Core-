using System;

namespace WordFrequencyCount
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Word Frequency Counter! ");

            // prompt user for text
            Console.Write("Please text: ");
            string text = Console.ReadLine();

            Dictionary<string, int> wordFrequencies = GetFrequencies(text);
            int totalUniqueWords = wordFrequencies.Count;
            Console.WriteLine($"Total Unique Words: {totalUniqueWords}");

            Console.WriteLine("Word Frequencies: ");

            foreach (KeyValuePair<string, int> wordFrequency in wordFrequencies)
            {
                Console.WriteLine($"{wordFrequency.Key}: {wordFrequency.Value}");
            }

            
        }


        static Dictionary<string, int> GetFrequencies(string text)
        {   

            char[] ignoreChars = { '.',  '!', '?', '\'', '\"', ' ', ',' };

            Dictionary<string, int> wordFrequencies = new Dictionary<string, int>();

            string[] words = text.ToLower().Split(' ');

            Console.WriteLine(words);

            foreach (string word in words)
            {
                string newWord = new string(word.Where(c => !ignoreChars.Contains(c)).ToArray());

                if (string.IsNullOrWhiteSpace(newWord))
                {
                    continue; 
                }

                if (wordFrequencies.ContainsKey(newWord))
                {

                    wordFrequencies[newWord]++;
                }
                else
                {
                    wordFrequencies.Add(newWord, 1);
                }
            }

            return wordFrequencies;
        }

    }
    
}