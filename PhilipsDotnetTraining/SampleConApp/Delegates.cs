using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Delegates are reference types that are created for methods. 
 * They are used to pass functions as args to other functions. 
 * Used for callback functions and internally behave like function pointers.
 * U would pass a method as arg if U want it to be invoked by the function after certain condition is met or some criteria is done. 
 */
namespace SampleConApp
{

    delegate double MathOperation(double first, double second);

    //Custom Generic class...
    class CustomCollection<T> where T: class
    {
        private List<T> _collection = new List<T>();

        public void Add(T item)
        {
            _collection.Add(item);
        }

        public T Find(Predicate<T> arg)
        {
            return _collection.Find(arg);
        }
    }
    class DelegatesExample
    {
        
        //This function is creatd to call another function. The Function to invoke will be passed as arg....
        static void InvokeFunc(MathOperation functionToCall)
        {
            if (functionToCall == null) return;
            Console.WriteLine("Enter first Value");
            double v1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter second Value");
            double v2 = double.Parse(Console.ReadLine());
            double result = functionToCall(v1, v2);
            Console.WriteLine("The Result: " + result);
        }
        static void Main(string[] args)
        {
            //simpleExample();
            realTimeExample();
        }
        static string input = string.Empty;
        static bool findingLogic(Student s)
        {
            return s.Name == input;
        }
        private static void realTimeExample()
        {
            CustomCollection<Student> college = new CustomCollection<Student>();
            college.Add(new Student { Name = "Phaniraj" });
            college.Add(new Student { Name = "Vanisree" });
            college.Add(new Student { Name = "Suman", ContactNo = 554433 });
            college.Add(new Student { Name = "Ramnath" });
            college.Add(new Student { Name = "JoyDip" });
            Predicate<Student> func = new Predicate<Student>(findingLogic);
            Console.WriteLine("Enter the Name of the student to find");

            input = Console.ReadLine();
            //            var foundStudent = college.Find(func);
            var foundStudent = college.Find((s) => s.Name == input);
            Console.WriteLine("The Student named {0} can be called on this number:  {1}", foundStudent.Name, foundStudent.ContactNo);
        }

        private static void simpleExample()
        {
            MathOperation func = new MathOperation(someFunc);
            InvokeFunc(func);

            InvokeFunc(new MathOperation((v1, v2) => v1 + v2));
        }

        static double someFunc(double v1, double v2)
        {
            double res = (v1 + v2) - (v2 - v1);
            return res;
        }

    }
}
