using System;

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Enter first number: ");
            int a = int.Parse(Console.ReadLine());

            try
            {
                Console.Write("Enter second number: ");
                int b = int.Parse(Console.ReadLine());

                try
                {
                    Console.Write("Enter third number: ");
                    int c = int.Parse(Console.ReadLine());

                    Console.WriteLine("Checking for Zero Values ");

                    try
                    {
                        int test = a/0;
                        Console.WriteLine($" First number ({a}) is NOT zero");
                    }
                    catch (DivideByZeroException)
                    {
                        Console.WriteLine($" First number is ZERO!");
                    }

                    try
                    {
                        int test = b/0;
                        Console.WriteLine($" Second number ({b}) is NOT zero");
                    }
                    catch (DivideByZeroException)
                    {
                        Console.WriteLine($" Second number is ZERO!");
                    }

                    try
                    {
                        int test = 1 / c;
                        Console.WriteLine($" Third number ({c}) is NOT zero");
                    }
                    catch (DivideByZeroException)
                    {
                        Console.WriteLine($" Third number is ZERO!");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Third number format error!");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Second number format error!");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("First number format error!");
        }

        Console.WriteLine("Program finished!");
    }
}