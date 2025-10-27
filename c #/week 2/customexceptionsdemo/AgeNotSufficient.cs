using System;

namespace customexceptionsdemo
{
    internal class AgeNotSufficient : Exception
    {
        public int ErrorCode { get; }
        public int Age { get; }
        public int YearsRemaining { get; }

        public AgeNotSufficient(int age, int errorCode) : base("Age not sufficient.")
        {
            Age = age;
            ErrorCode = errorCode;
            YearsRemaining = 18 - age;
        }

        public void ErrorDisplay()
        {
            string timestamp = DateTime.Now.ToString("dd:MM:yyyy:HH:mm");
            Console.WriteLine(timestamp + " Exception Code: " + ErrorCode + ". " + Message + " Your age is not sufficient to cast vote. Please try after " + YearsRemaining + " years.");
        }
    }
}