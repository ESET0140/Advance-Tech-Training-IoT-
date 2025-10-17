namespace lastdemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Employee first = new Employee();//object instantiation
            first.getEmployeeData();
            first.DisplayEmployeeinfo();
        }
    }
}
