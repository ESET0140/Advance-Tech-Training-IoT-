using System.Diagnostics.CodeAnalysis;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace additionusingmethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first number");
            double first_num = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter second number");
            int second_num = Convert.ToInt32(Console.ReadLine());
            int result = addition(100, 200);

            double result2 = addition1(first_num, second_num);

            Console.WriteLine($"The sum of {first_num} and {second_num} is {result2}");
        }
        static public int addition(int first, int second)
        {
            int sum = first + second;
            return sum;
        }
        static public double addition1(double first, int second)
        {
            double sum = first + second;
            return sum;
        }
    }
}
