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
            rate = rate;
        }
        
        public double CalculateBill()
        {
            
            totalenergyconsumption = totalUnits * ratePerUnit;
            return totalenergyconsumption;
        }
       public void display_bill()
        {
            Console.WriteLine(billno);
            Console.WriteLine(customerid);
            Console.WriteLine(serialnumber);
            Console.WriteLine(totalenergyconsumption);
           
        }
    }

}

