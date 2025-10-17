namespace Loops_1_pat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write(" * ");
                }
                Console.WriteLine();
            }
        }
    }
}