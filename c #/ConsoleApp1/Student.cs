using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    
    internal class Student
    {

        public string Nam
        {
            get
            {
                return Nam;
            }
            set
            {
                Nam = value;
            }
        }
       
        String Name { get; set; }
        int sub1 { get; set; }
        int sub2 { get; set; }
        int sub3 { get; set; }
        int sub4 { get; set; }
        int sub5 { get; set; }

        int Total_Marks { get; set; }

        double Average { get; set; }
        public Student(string nam, string name, int sub1, int sub2, int sub3, int sub4, int sub5, int total_Marks, double average)
        {
            Nam = nam;
            this.Name = name;
            this.sub1 = sub1;
            this.sub2 = sub2;
            this.sub3 = sub3;
            this.sub4 = sub4;
            this.sub5 = sub5;
           
        }

       
        public void displayinfo()
        {
            Console.WriteLine(Name);
            Console.WriteLine(sub1);
            Console.WriteLine(sub2);
            Console.WriteLine(sub3);
            Console.WriteLine(sub4);
            Console.WriteLine(sub5);
            Console.WriteLine(Average);
            Console.WriteLine(Total_Marks);


        }

        public void getData()
        {
            Console.WriteLine($"Enter the Name {Name}");
            Name = Console.ReadLine();
            Console.WriteLine($"Enter sub1 Marks");
            sub1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Enter sub2 Marks ");
            sub2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Enter sub3 Marks");
            sub3 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Enter sub4 Marks");
            sub4 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Enter sub5 Marks");
            sub5 = Convert.ToInt32(Console.ReadLine());

        }
        public int gettotalmarks()
        {
            Total_Marks = sub1 + sub2 + sub3 + sub4 + sub5;
            Console.WriteLine($"Total Marks= ,{Total_Marks}");
            return Total_Marks;
        }
        public double getAverage()
        {
            Average = Total_Marks / 5.0;
            return Average;
        }
        public void grade()
        {
            if (Average > 90)
            {
                Console.WriteLine("Grade A");
            }
            else if (Average > 80)
            {
                Console.WriteLine("Grade B");

            }
            else if (Average > 60)
            {
                Console.WriteLine("Grade D");
            }
            else
            {
                Console.WriteLine("Fail");
            }
        }

    }
}
