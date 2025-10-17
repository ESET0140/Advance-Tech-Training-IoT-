using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metering_system
{
    internal class Mapping
    {
        string Meter_serial {  get; set; }
        string Customer_id { get; set; }

        public Mapping (string meter_serial, string customer_id)
        {
            meter_serial = meter_serial;
            Customer_id = customer_id;
        }
       public void Display()
        {
            Console.WriteLine(Meter_serial);
            Console.WriteLine(Customer_id);
        }
    }
    
}
