using System;
using System.Collections.Generic;

namespace metering_system
{
    internal class Program
    {
        // Lists to store all objects
        private static List<customer> customers = new List<customer>();
        private static List<Smartmeter> meters = new List<Smartmeter>();
        private static List<Reading> readings = new List<Reading>();
        private static List<Mapping> mappings = new List<Mapping>();
        private static List<bill> bills = new List<bill>();

        static void Main(string[] args)
        {
            int choice;

            do
            {
                Console.WriteLine("\n------Welcome to Smart Meter System--------");
                Console.WriteLine("1. Add Customer");
                Console.WriteLine("2. Add Smart Meter");
                Console.WriteLine("3. Map Meter to Customer");
                Console.WriteLine("4. Add Reading");
                Console.WriteLine("5. Generate Bill");
                Console.WriteLine("6. Display All Data");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddCustomer();
                        break;
                    case 2:
                        AddSmartMeter();
                        break;
                    case 3:
                        MapMeterToCustomer();
                        break;
                    case 4:
                        AddReading();
                        break;
                    case 5:
                        GenerateBill();
                        break;
                    case 6:
                        DisplayAllData();
                        break;
                    case 7:
                        Console.WriteLine("Terminating......");
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }

                Console.WriteLine("------------------------------------------------");

            } while (choice != 7);
        }

        // 1. Add Customer - Object Instantiation
        public static void AddCustomer()
        {
            Console.Write("Enter customer id: ");
            string customerId = Console.ReadLine();

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Address: ");
            string address = Console.ReadLine();

            // Creating customer object
            customer newCustomer = new customer(customerId, name, address);
            customers.Add(newCustomer);
            Console.WriteLine("Customer added successfully.");
        }

        // 2. Add Smart Meter - Object Instantiation  
        public static void AddSmartMeter()
        {
            Console.Write("Enter meter serial no: ");
            string serialNo = Console.ReadLine();

            Console.Write("Enter model: ");
            string model = Console.ReadLine();

            Console.Write("Enter readings: ");
            string readingsInput = Console.ReadLine();

            // Creating Smartmeter object - fixed constructor call
            Smartmeter newMeter = new Smartmeter(serialNo, model, readingsInput);
            meters.Add(newMeter);
            Console.WriteLine("Smart Meter added successfully.");
        }

        // 3. Map Meter to Customer - Object Instantiation
        public static void MapMeterToCustomer()
        {
            Console.Write("Enter customer ID: ");
            string customerId = Console.ReadLine();

            Console.Write("Enter meter serial no: ");
            string meterSerial = Console.ReadLine();

            // Creating Mapping object
            Mapping newMapping = new Mapping(meterSerial, customerId);
            mappings.Add(newMapping);
            Console.WriteLine("Meter mapped to customer successfully.");
        }

        // 4. Add Reading - Object Instantiation
        public static void AddReading()
        {
            Console.Write("Enter meter serial no: ");
            string meterSerial = Console.ReadLine();

            Console.Write("Enter energy consumption: ");
            int consumption = int.Parse(Console.ReadLine());

            string timestamp = DateTime.Now.ToString();

            // Creating Reading object
            Reading newReading = new Reading(timestamp, consumption);
            readings.Add(newReading);
            Console.WriteLine("Reading added successfully.");
        }

        // 5. Generate Bill - Object Instantiation
        public static void GenerateBill()
        {
            Console.Write("Enter customer ID: ");
            string customerId = Console.ReadLine();

            // Creating bill object
            bill newBill = new bill(8.0); // 8.0 is the rate per unit
            bills.Add(newBill);
            Console.WriteLine("Bill generated successfully.");
        }

        // 6. Display All Data
        public static void DisplayAllData()
        {
            Console.WriteLine("\n--- CUSTOMERS ---");
            foreach (customer cust in customers)
            {
                cust.DisplayCustomerInfo();
            }

            Console.WriteLine("\n--- SMART METERS ---");
            foreach (Smartmeter meter in meters) 
            {
                meter.DisplayMeterInfo();
            }

            Console.WriteLine("\n--- MAPPINGS ---");
            foreach (Mapping mapping in mappings)
            {
                mapping.Display();
            }

            Console.WriteLine("\n--- READINGS ---");
            foreach (Reading reading in readings)
            {
                reading.DisplayReading();
            }

            Console.WriteLine("\n--- BILLS ---");
            foreach (bill b in bills)
            {
                b.display_bill();
            }
        }
    }
}