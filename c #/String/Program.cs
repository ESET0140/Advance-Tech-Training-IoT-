using System;
using System.Security.Cryptography.X509Certificates;

namespace String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            is_valid_credentials("9709373578", "12345678");
            int length = WordsLength("Buffalo");
            Console.WriteLine(length);
            int countspace = CountSpaces(" T A R A ");
            Console.WriteLine(countspace);
            string[] allword = List_all_words("My name is tarak");


            Console.WriteLine("Words in the array:");
            foreach (string word in allword)
            {
                Console.WriteLine(word);
            }

            first_occurence("Tarak");
            To_upper_case("iphone");




        }

        public static bool is_valid_credentials(string Mobile, string Password)
        {
            if (Mobile.Length == 10 && Password.Length == 8)
            {
                Console.WriteLine("Valid Credentials");
                return true;
            }
            else
            {
                Console.WriteLine("The credentials length must be 8 ");
                return false;
            }
        }

        public static int WordsLength(string words)
        {
            int length = words.Length;
            return length;
        }

        public static int CountSpaces(string text)
        {
            int count = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                {
                    count++;
                }
            }
            if (count > 0)
            {
                Console.WriteLine($"The number of spaces is {count}");
            }
            else
            {
                Console.WriteLine("There is no spaces");
            }
            return count;
        }

        public static string[] List_all_words(string text)
        {

            string[] split = text.Split(' ');
            return split;
        }
        public static void first_occurence(string text)
        {

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == 'a')
                {
                    Console.WriteLine($"First Occurence of a at index{i}");
                    break;
                }


            }
        }
        public static void To_upper_case(string text)
        {
            string Uc = text.ToUpper();
            Console.WriteLine(Uc);
        }
        static string ToCamelCase(string input)
        {
            string[] words = input.Split(' ');
            string result = "";

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == "") continue; 

                if (i == 0)
                {
                    result += words[i].ToLower();
                }
                else
                {
                    string firstChar = words[i].Substring(0, 1).ToUpper();
                    string rest = words[i].Substring(1).ToLower();
                    result += firstChar + rest;
                }
            }

            return result;
        }
    }
}