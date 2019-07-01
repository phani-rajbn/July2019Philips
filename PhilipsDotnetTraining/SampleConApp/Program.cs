//The namespace which we intend to use. The classes in this namespace can be accessed in our code without the mention of the namespace

//Solution is a group of Projects  which is saved with an Extension .sln. If U open the soln, all the projects associated with the soln will automatically open at one single click. 
//Project is a group of files to create an Exe. Every Project will give an EXE or a DLL as an output. All the files of the project are compiled and then an EXE would be created. If any of the files has compilation Erros, EXE will not created and the build process will fail. U must ensure that all the files of the project are free from compilation Errors and then build the project to generate an EXE file which is the File that will run.  
//U could customize the IDE by selecting Options from the Tools menu of the Environment.
//C# files will be saved with extension .cs. There is no rule that the classname and the filename be same. Visual Studio however creates the filename based on the name of the class U provide while U create a new Class. 
using System;

namespace SampleConApp
{
    class Program
    {
        static void Main(string[] args)//Entry point of the Application
        {
            //firstExample();
            takeInputsExample();
        }//Console is a Class of .NET that is used to interact with the Console window which is the output Window of UR App. A Class can invoke its methods without creating an object if the methods are static. Console class contains only static methods in it, so its methods can be invoked without an object instance. Static methods are invoked by the name of the class.

        private static void takeInputsExample()
        {
            Console.WriteLine("Enter the Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the City");
            string city = Console.ReadLine();
            
            Console.WriteLine("Enter the Age");
            string age = Console.ReadLine();//ReadLine reads the input given by the User on the Console and returns a string representation of it.
            Console.WriteLine("Enter the Gender as M or F");
            string gender = Console.ReadLine().ToUpper();
            Console.WriteLine($"The Name entered is {name}\nThe City from where he belongs is {city}.");//New in C# 6.0....
            Console.WriteLine("{0}. {1}'s age is {2}" , gender == "M" ? "Mr" : "Ms", name, age );
        }

        private static void firstExample()
        {
            Console.WriteLine("Testing 123");
            Console.WriteLine("Another line");
            Console.WriteLine("Some content with a number " + 123);
        }

        //To Execute the Program: Ctrl+ F5
    }
    /*Points to remember:
     * Console is a Static class used to perform IO operations on Console. 
     * WriteLine writes a stream of text on the Console as ReadLine reads the input as a string. 
     * WriteLine is overloaded with 17 versions to concatinate string with other data types of .NET
     * U could combine the string with variables using placeholders{0} as well as the new Interpolation Syntax using $.
     */
}
