using System;

namespace student
{
    internal class Program
    {
        static string[] student_names = new string[3];
        static string[] student_classes = new string[3];
        static int[] student1_marks = new int[3];
        static int[] student2_marks = new int[3];
        static int[] student3_marks = new int[3];

        static void Main(string[] args)
        {
            Console.WriteLine("Student Results ");

            get_student_1();
            get_student_2();
            get_student_3();

            display_student_results();
        }

        public static void get_student_1()
        {
            Console.WriteLine("Enter 1st student name");
            student_names[0] = Console.ReadLine();

            Console.WriteLine("Enter class name");
            student_classes[0] = Console.ReadLine();

            Console.WriteLine("Enter 1st sub marks");
            student1_marks[0] = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter 2nd sub marks");
            student1_marks[1] = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter 3rd sub marks");
            student1_marks[2] = Convert.ToInt32(Console.ReadLine());
        }

        public static void get_student_2()
        {
            Console.WriteLine("Enter 2nd student name");
            student_names[1] = Console.ReadLine();

            Console.WriteLine("Enter class name");
            student_classes[1] = Console.ReadLine();

            Console.WriteLine("Enter 1st sub marks");
            student2_marks[0] = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter 2nd sub marks");
            student2_marks[1] = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter 3rd sub marks");
            student2_marks[2] = Convert.ToInt32(Console.ReadLine());
        }

        public static void get_student_3()
        {
            Console.WriteLine("Enter 3rd student name");
            student_names[2] = Console.ReadLine();

            Console.WriteLine("Enter class name");
            student_classes[2] = Console.ReadLine();

            Console.WriteLine("Enter 1st sub marks");
            student3_marks[0] = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter 2nd sub marks");
            student3_marks[1] = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter 3rd sub marks");
            student3_marks[2] = Convert.ToInt32(Console.ReadLine());
        }

        public static int get_student_total_marks(int[] marks)
        {
            return marks[0] + marks[1] + marks[2];
        }

        public static double get_student_Average_marks(int[] marks)
        {
            int total = get_student_total_marks(marks);
            return total / 3.0;
        }

        public static void display_student_results()
        {
            Console.WriteLine("\n============== Student Results================");

            Console.WriteLine($"\nStudent 1: {student_names[0]}");
            Console.WriteLine($"Class: {student_classes[0]}");
            Console.WriteLine($"Sub1: {student1_marks[0]}, Sub 2: {student1_marks[1]},Sub 3: {student1_marks[2]}");
            Console.WriteLine($"Total: {get_student_total_marks(student1_marks)}");
            Console.WriteLine($"Average: {get_student_Average_marks(student1_marks):F2}");
            Console.WriteLine("\n==========================");


            Console.WriteLine($"\nStudent 2: {student_names[1]}");
            Console.WriteLine($"Class: {student_classes[1]}");
            Console.WriteLine($"Sub1: {student2_marks[0]}, Sub2: {student2_marks[1]}, Sub3: {student2_marks[2]}");
            Console.WriteLine($"Total: {get_student_total_marks(student2_marks)}");
            Console.WriteLine($"Average: {get_student_Average_marks(student2_marks):F2}");
            Console.WriteLine("\n==========================");


            Console.WriteLine($"\nStudent 3: {student_names[2]}");
            Console.WriteLine($"Class: {student_classes[2]}");
            Console.WriteLine($"Sub 1: {student3_marks[0]}, Sub2: {student3_marks[1]},Sub 3: {student3_marks[2]}");
            Console.WriteLine($"Total: {get_student_total_marks(student3_marks)}");
            Console.WriteLine($"Average: {get_student_Average_marks(student3_marks):F2}");
            Console.WriteLine("\n==========================");

        }
    }
}