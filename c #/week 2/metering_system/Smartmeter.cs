using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace metering_system
{
    internal class Smartmeter
    {
       
            public string MeterSerialNo { get; set; }
            public string Model { get; set; }
            public string Readings { get; set; }


            public Smartmeter(string meterSerialNo, string model, string readings)
            {


                MeterSerialNo = meterSerialNo;
                Model = model;
                Readings = readings;
            }
            
            public void DisplayMeterInfo()
            {
                Console.WriteLine($"Meter Serial No: {MeterSerialNo}");
                Console.WriteLine($"Model: {Model}");
               
            }


        
    }
}
