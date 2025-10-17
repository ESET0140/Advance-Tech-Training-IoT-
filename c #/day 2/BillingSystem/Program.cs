using System;

namespace BillingSystem
{
    internal class Program
    {
        static String zone;
        static String Tariff;
        static int Units;

        static void Main(string[] args)
        {
            Console.WriteLine("----------- Billing System -----------");

            customer_info();

            Console.Write("Enter Total Units Consumed: ");
            Units = int.Parse(Console.ReadLine());

            double amount = CalculateBill(zone, Tariff, Units);

            DisplayBill(zone, Tariff, Units, amount);
        }

        public static void customer_info()
        {
            Console.Write("Enter your zone (Z1/Z2/Z3): ");
            zone = Console.ReadLine();

            Console.Write("Enter Tariff (LT1/LT2/LT3): ");
            Tariff = Console.ReadLine();
        }

        public static double CalculateBill(string zone, string tariff, int units)
        {
            switch (zone)
            {
                case "Z1":
                    return customer_bill_Z1(units);
                case "Z2":
                    return customer_bill_Z2(units);
                case "Z3":
                    return customer_bill_Z3(units);
                default:
                    return 0;
            }
        }

        public static double customer_bill_Z1(int units)
        {
            double rate = 0;

            if (Tariff == "LT1")
            {
                if (units <= 50) rate = 3.0;
                else if (units <= 100) rate = 4.0;
                else rate = 5.0;
            }
            else if (Tariff == "LT2")
            {
                if (units <= 50) rate = 4.5;
                else if (units <= 100) rate = 5.5;
                else rate = 6.5;
            }
            else if (Tariff == "LT3")
            {
                if (units <= 50) rate = 6.0;
                else if (units <= 100) rate = 7.0;
                else rate = 8.0;
            }

            return units * rate;
        }

        public static double customer_bill_Z2(int units)
        {
            double rate = 0;

            if (Tariff == "LT1")
            {
                if (units <= 50) rate = 3.5;
                else if (units <= 100) rate = 4.5;
                else rate = 5.5;
            }
            else if (Tariff == "LT2")
            {
                if (units <= 50) rate = 5.0;
                else if (units <= 100) rate = 6.0;
                else rate = 7.0;
            }
            else if (Tariff == "LT3")
            {
                if (units <= 50) rate = 6.5;
                else if (units <= 100) rate = 7.5;
                else rate = 8.5;
            }

            return units * rate;
        }

        public static double customer_bill_Z3(int units)
        {
            double rate = 0;

            if (Tariff == "LT1")
            {
                if (units <= 50) rate = 4.0;
                else if (units <= 100) rate = 5.0;
                else rate = 6.0;
            }
            else if (Tariff == "LT2")
            {
                if (units <= 50) rate = 5.5;
                else if (units <= 100) rate = 6.5;
                else rate = 7.5;
            }
            else if (Tariff == "LT3")
            {
                if (units <= 50) rate = 7.0;
                else if (units <= 100) rate = 8.0;
                else rate = 9.0;
            }

            return units * rate;
        }

        public static void DisplayBill(string zone, string tariff, int units, double amount)
        {
            Console.WriteLine("\n----------- ELECTRICITY BILL -----------");
            Console.WriteLine($"Zone: {zone}");
            Console.WriteLine($"Tariff: {tariff}");
            Console.WriteLine($"Units Consumed: {units}");
            Console.WriteLine($"Total Amount: Rs.{amount:F2}");
            Console.WriteLine("----------------------------------------");
        }
    }
}