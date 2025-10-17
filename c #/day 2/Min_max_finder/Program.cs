using System;

namespace Min_max_finder
{
    internal class Program
    {
        static int num1, num2, num3;
        static void Main(string[] args)
        {
            Console.WriteLine("Enter three digit number");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter three digit number");
            num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter three digit number");
            num3 = Convert.ToInt32(Console.ReadLine());

            if (checkNumberRange(num1) && checkNumberRange(num2) && checkNumberRange(num3))
            {
                check_largest_value(num1, num2, num3);
            }
            else
            {
                Console.WriteLine("Please enter valid three-digit numbers (100-999)");
                check_valid_number(num1, num2, num3);  
        }

        public static bool checkNumberRange(int num)
        {
            if (num >= 100 && num <= 999)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void check_largest_value(int num1, int num2, int num3)
        {
            if (num1 > num2 && num1 > num3)
            {
                Console.WriteLine($"{num1} is the largest value");
            }
            else if (num2 > num1 && num2 > num3)
            {
                Console.WriteLine($"{num2} is the largest value");
            }
            else
            {
                Console.WriteLine($"{num3} is the largest value");
            }
        }

        static void check_valid_number(int num1, int num2, int num3)  
        {
            if (!checkNumberRange(num1))
            {
                Console.WriteLine($"{num1} is not a valid three-digit number");
            }

            if (!checkNumberRange(num2))
            {
                Console.WriteLine($"{num2} is not a valid three-digit number");
            }

            if (!checkNumberRange(num3))
            {
                Console.WriteLine($"{num3} is not a valid three-digit number");
            }
        }
    }
}