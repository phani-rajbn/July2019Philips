using System;
using System.Threading;

/*
 * Constructors are functions that are invoked while the object is being created. 
 * They have the same name as the class and will not have any return types(Not even void)
 * They can overloaded with parameters for better object creation.
 * It maintains inheritance hirarchy where the base class constructor will be called before the current class constructor. 
 * U can call the base class's specific constructor using base keyword. 
 */
namespace SampleConApp
{
    class BaseClass
    {
        public BaseClass()
        {
            Console.WriteLine("Default Constructor");
        }

        public BaseClass(string arg)
        {
            Console.WriteLine("Parameterised Constructor with arg " + arg);
        }
    }

    class DerivedClass : BaseClass
    {
        public DerivedClass() : base("Arg")
        {
            Console.WriteLine("Derived class constructor");
        }
    }

    class TestClass : IDisposable
    {
        private string className = string.Empty;

        public TestClass(string name)
        {
            className = name;
            Console.WriteLine("The Class {0} is created" , className);
        }

        //Destructors are functions with a ~ and no access specifiers or parameters. They cannot be invoked as they are internally used by the GC. Its not recommended to create Destructors unless U R working with unmanaged code(COM or Win32 API or Non .NET Code) 
        //GC of the CLR will call the Destructor when the object is being destroyed by it. U can call the GC's functions to destroy the objects if required before U wait for the GC to do so...
        ~TestClass()
        {
            Console.WriteLine("The object {0} is destroyed", className);
        }

        public void Dispose()
        {
            Console.WriteLine("The object {0} is destroyed", className);
        }
    }
    class ConstructorsAndDestructors
    {
        static void createAndDeleteObjects()
        {
            for (int i = 0; i < 100; i++)
            {
                TestClass cls = new TestClass("Object:" + i);
                GC.Collect();//GC will clean up the memory of unused objects as background Thread...
                GC.WaitForPendingFinalizers();//It makes the Main thread wait till the clean up is completed....
                Thread.Sleep(100);
                GC.SuppressFinalize(cls);//This tells the GC not to call the specified object's destructor as it implies that U have handled that code thro Dispose method...
                cls.Dispose();//UR code to be invoked after the usage of the object....
            }
        }
        static void Main(string[] args)
        {
            createAndDeleteObjects();
            Console.WriteLine("End of Main");
            //DerivedClass cls = new DerivedClass();
        }
    }
}
