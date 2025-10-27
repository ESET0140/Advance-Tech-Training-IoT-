using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metering_system
{
    internal class Reading
    {
            public string Timestamp { get; set; }
            public int EnergyConsumption { get; set; }

            public Reading(string timestamp, int energyConsumption)
            {
                Timestamp = timestamp;
                EnergyConsumption = energyConsumption;
            }
        public void DisplayReading()
        {
            Console.WriteLine($"Timestamp: {Timestamp}");
            Console.WriteLine($"Energy Consumption: {EnergyConsumption} kWh");
        }

    }
    
}
