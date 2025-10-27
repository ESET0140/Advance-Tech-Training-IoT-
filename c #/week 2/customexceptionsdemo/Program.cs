using System;

namespace customexceptionsdemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Voting Eligibility Checker");
                Console.Write("Enter your age: ");
                int age = int.Parse(Console.ReadLine());

                CheckVotingEligibility(age);
                Console.WriteLine("Congratulations! You are eligible to vote.");
            }
            catch (AgeNotSufficient ex)
            {
                ex.ErrorDisplay();
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter a valid number for age!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
            finally
            {
                Console.WriteLine(" !! Verification completed !!");
            }
        }

        static void CheckVotingEligibility(int age)
        {
            if (age < 0)
            {
                throw new AgeNotSufficient(age, 100);
            }

            if (age > 100)
            {
                throw new AgeNotSufficient(age, 100);
            }

            if (age < 18)
            {
                throw new AgeNotSufficient(age, 100);
            }
        }
    }
}