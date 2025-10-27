using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metering_system
{
    internal class bill
    {
        double ratePerUnit;
        string customerid;
        string serialnumber;
        double totalenergyconsumption;
        string billno;
        double totalUnits;

        public bill(double rate)
        {
            ratePerUnit = rate;
        }

        // Method to set customer details and units
        public void SetBillDetails(string custId, string serialNo, double units, string billNumber)
        {
            customerid = custId;
            serialnumber = serialNo;
            totalUnits = units;
            billno = billNumber;
        }

        public double CalculateBill()
        {
            totalenergyconsumption = totalUnits * ratePerUnit;
            return totalenergyconsumption;
            if (totalenergyconsumption > 0)
            {
            }
            
        }
        private void ValidateUnits(double totalenergyconsumption)
        {
            try
            {
                if (totalenergyconsumption < 0)
                {
                    throw new ArgumentException("Units cannot be negative! Please enter a positive value.");
                }
                else if (totalenergyconsumption == 0)
                {
                    throw new InvalidOperationException("Units cannot be zero! No energy consumption recorded.");
                }
                else if (totalenergyconsumption > 700)
                {
                    throw new ArgumentOutOfRangeException("Units exceed maximum limit! Consumption too high. Maximum allowed: 700 units.");
                }

                Console.WriteLine("Unit validation successful!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Argument Error: {ex.Message}");
                throw; 
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Operation Error: {ex.Message}");
                throw; // Re-throw to let caller handle it
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Range Error: {ex.Message}");
                throw; // Re-throw to let caller handle it
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected validation error: {ex.Message}");
                throw; // Re-throw to let caller handle it
            }
        }
    }


        public void display_bill()
        {
            Console.WriteLine($"Bill No: {billno}");
            Console.WriteLine($"Customer ID: {customerid}");
            Console.WriteLine($"Meter Serial: {serialnumber}");
            Console.WriteLine($"Total Units: {totalUnits}");
            Console.WriteLine($"Rate Per Unit: {ratePerUnit}");
            Console.WriteLine($"Total Energy Consumption: {totalenergyconsumption}");
        }
    }
}