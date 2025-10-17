using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lastdemo
{
    internal class Employee
    {
        static int lab = 5;
        int Id { get; set; }
        string Name { get; set; }
        string Department { get; set; }

        double Salary { get; set; }


        public void DisplayEmployeeinfo()
        {
            Console.WriteLine($"Employee Id:,{Id}");
            Console.WriteLine($"Name:,{Name}");
            Console.WriteLine($"Department:,{Department}");
            Console.WriteLine($"Salary:,{Salary}");



        }
        public void getEmployeeData()
        {

            Console.WriteLine(Id);
            Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(Name);
            Name = Console.ReadLine();
            Console.WriteLine(Department);
            Department = Console.ReadLine();
            Console.WriteLine(Salary);
            Salary = Convert.ToInt32(Console.ReadLine());

        }


    }
    
}
