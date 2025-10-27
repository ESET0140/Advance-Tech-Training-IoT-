using System;

namespace SimpleTryCatch
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = 0;
            int[] myarray = new int[10];
            Console.WriteLine("Enter first number:");
            int num1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter second number:");
            int num2 = int.Parse(Console.ReadLine());

            try
            {
                
                result = num1 / num2;
                Console.WriteLine($"Result: {result}");
                myarray[11] = 20;
            }
            catch (IndexOutOfRangeException ex)
            {

            }
            catch (Exception ex)
            {
               
            }
            finally
            {

            }


            Console.WriteLine(result);

            Console.WriteLine("Program ended successfully!");
        }
    }
}