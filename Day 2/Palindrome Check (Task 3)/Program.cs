using System;

namespace CheckPalindrom
{
    class Program
    {
        static void Main (string[] args)
        {
            Console.WriteLine("Welcome to the Palindrome Checker! ");

            // prompt user for text
            Console.Write("Please enter text: ");
            string text = Console.ReadLine();

            if (IsPalindrome(text))
            {
                Console.WriteLine("The text is a palindrome.");
            }
            else
            {
                Console.WriteLine("The text is not a palindrome.");
            }

        }

        static bool IsPalindrome(string text)
        {
            char[] ignoreChars = { '.',  '!', '?', '\'', '\"', ' ', ',' };

            string[] words = text.ToLower().Split(' ');

            string newWord = new string(text.Where(c => !ignoreChars.Contains(c)).ToArray());

            char[] charArray = newWord.ToCharArray();
            int left = 0;
            int right = charArray.Length - 1;

            while (left < right)
            {
                if (charArray[left] != charArray[right])
                {
                    return false;
                }
                left++;
                right--;
            }

            return true;
            
        }

    }
}