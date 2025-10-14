using System.Diagnostics.Contracts;

namespace Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] my_array = get_array();
            Display(my_array);


        }
        public static int[] get_array()
        {

            int[] num = new int[5];

            Console.WriteLine("num[0]");
            num[0] = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("num[1]");
            num[1] = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("num[2]");
            num[2] = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("num[3]");
            num[3] = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("num[4]");
            num[4] = Convert.ToInt32(Console.ReadLine());

            return num;
        }

        public static void Display(int[] my_array)
        {
            Console.WriteLine($"{my_array[0]},{my_array[1]},{my_array[2]},{my_array[3]}");
        }
    }
}
