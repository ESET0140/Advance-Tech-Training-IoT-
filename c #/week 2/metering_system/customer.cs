using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metering_system
{
    internal class customer
    {
            public string CustomerId { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }

            public customer(string customerId, string name, string address)
            {
                CustomerId = customerId;
                Name = name;
                Address = address;
            }

            public void DisplayCustomerInfo()
            {
                Console.WriteLine($"Customer ID: {CustomerId}");
                Console.WriteLine($"Name: {Name}");
                Console.WriteLine($"Address: {Address}");
            }

        }
}
