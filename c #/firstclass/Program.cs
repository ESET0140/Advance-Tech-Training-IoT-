namespace firstclass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte variable_byte = 6;
            sbyte var_sbyte = -9;
            short var_short = -8560;
            ushort var_ushort = 9876;

            int meter_count = 100;
            uint meter_counter = 400U;
            long var_long = 45000l;
            ulong var_ulong = 5500ul;
            var customer_name = "Tarak Nath Mahato";
            float meter_current = 19.0f;
            double meter_voltage = 220.34;
            char bill = 'Y';

            Console.WriteLine("Hello, World!");
            Console.WriteLine(variable_byte);
            Console.WriteLine(var_sbyte);
            Console.WriteLine(var_short);
            Console.WriteLine(var_ushort);
            Console.WriteLine(var_long);
            Console.WriteLine(var_ulong);
            Console.WriteLine(customer_name);
            Console.WriteLine(meter_current);
            Console.WriteLine(meter_voltage);
            Console.WriteLine(meter_counter);
            Console.WriteLine(var_long);
            Console.WriteLine(bill);


        }
    }
}

