namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student first = new Student();
            first.getData();
            first.gettotalmarks();
            first.displayinfo();
            first.getAverage();
            first.grade();
            Student second = new Student();
            second.getData();
            second.gettotalmarks();
            second.displayinfo();
            second.getAverage();
            second.grade();
            Student third = new Student();
            third.getData();
            third.gettotalmarks();
            third.displayinfo();
            third.getAverage();
            third.grade();
            Student fourth = new Student();
            fourth.getData();
            fourth.gettotalmarks();
            fourth.displayinfo();
            fourth.getAverage();
            fourth.grade();
            Student fifth = new Student();
            fifth.getData();
            fifth.gettotalmarks();
            fifth.displayinfo();
            fifth.getAverage();
            fifth.grade();

            //get set method

            first.Nam = "abcd";
            Console.WriteLine(first.Nam);



        }
    }
}
