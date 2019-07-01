using System;
/*
 * Rules of implementing Entry point:
 * Main is case sensitive in C#....
 * It will either return void or int.
 * It can take either string[] as arg or nothing. String[] represents the Command line args for the Program. 
 * Only those classes which have the valid entry point can be seen in the Startup object dropdownlist while U select the Main Class. 
 * Main is always a part of the class, its a static function. As there is concept of global members in C#, Main is expected to be part of any class, as its invoked by the CLR without an object, it has to be static. 
 */
namespace SampleConApp
{
    class ClassDemo
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the Address");
            string addr = Console.ReadLine();
            Console.WriteLine("Enter the Salary");
            double salary = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the DateOfBirth as dd/MM/yyyy");
            DateTime Dt = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter the ContactNo");
            long phone = long.Parse(Console.ReadLine());

            Employee emp = new Employee
            {
                Address = addr,
                ContactNo = phone,
                DateofBirth = Dt,
                EmpName = name,
                Salary = salary
            };

            Employee[] philips = new Employee[1000];
            Console.WriteLine($"The Name of the Employee:{emp.EmpName}\nThe Address:{emp.Address}\nThe Salary:{emp.Salary:C}\nThe Phone no:{emp.ContactNo}\nThe Date of birth:{emp.DateofBirth.ToLongDateString()}");
        }
    }
    /*
     * Class is a User defined Reference type. With it comes a set of features based on OOP like Inheritance, Encapsulation, Polymorphism and Abstraction. These features are based on SOLID Principles of OOP. 
     * S->Single Responsibility Principle
     * O->Open Closed Principle
     * L->Luskov's Substitution Principle
     * I->Interface Segregation Principle
     * D->Dependency Inversion Principle
     * Any Class usage has 2 step process: 1 step: Provide the definition for the class to define what it holds and what it does. 2 step: To create a variable of the class called object and use it.  
     * 
     */

    class Employee
    {
        public string EmpName { get; set; }
        public string Address { get; set; }
        public DateTime DateofBirth { get; set; }
        public double Salary { get; set; }
        public long ContactNo { get; set; }
    }
}