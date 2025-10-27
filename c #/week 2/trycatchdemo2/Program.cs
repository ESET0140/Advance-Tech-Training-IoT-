using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Hello");

        try
        {
            Console.Write("Enter number: ");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter number: ");
            double num2 = Convert.ToDouble(Console.ReadLine());

            if (num2 < 5 )
            {
                throw new DivideByZeroException("Number cannot be less than 5!");
            }

            Console.WriteLine($"Numbers entered: {num1} and {num2}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Please enter valid numbers only!");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Thank you !!");
        }
    }
}