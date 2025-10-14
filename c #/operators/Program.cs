namespace operators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 5;
            int b = a++;
            Console.WriteLine(a);
            Console.WriteLine($"post increment,{b}");
            Console.WriteLine(a);
            int c = 8;
            int d = ++c;
            Console.WriteLine(c);
            Console.WriteLine($"pre increment,{d}");
            


        }

    }
}
