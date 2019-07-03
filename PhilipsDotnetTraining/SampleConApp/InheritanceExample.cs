using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Based on Open-Closed Principle. A Class is designed to be extended rather than modifying it. 
 * C# supports Single Inheritance, not multiple inheritance. It means that a class cannot have 2 base classes at the same level.  
 * There is no public or private inheritance in C#, all members of the base class will retain their access in the derived class. 
 * Syntax is similar to C++ as we dont have extends or implements keywords..
 */
namespace SampleConApp
{
    class Parent
    {
        public void MakePayment(double amount)
        {
            Console.WriteLine("The payment of {0:C} is made using cheque or cash", amount);
        }
    }
    //Add a new functionality....Open Closed Princple says that once the class is created, it becomes immutable. U cannot change the existing class, but u could extend the class and add new methods to it...
    class Child : Parent
    {
        public void RecievePayment(double amount)
        {
            Console.WriteLine("Payment of {0:C} recieved as reciept", amount);
        }
    }
    class InheritanceExample
    {
        static void Main(string[] args)
        {
            //firstexample();
            polymorphismExample();
        }

        private static void polymorphismExample()
        { 
            Parent business = new Parent();
            business.MakePayment(5000);
            
            business = new Child();//Luskov's substitution principle which says that a base type object can be substituted by any of the subtypes within a program. Base class object can be instantiated to a derived class object.  However, U will get only those methods of the base. The new methods of the derived are not available as the object is of the type Base. 
            //U must type cast it to call the derived methods...
            if(business is Child)//is is used to check the object info...
            {
                //Reference types can be typecasted using as operator
                Child oldBusiness = business as Child;
                oldBusiness.RecievePayment(4000);
                //This is called as Downcasting. 
            }            
        }

        private static void firstexample()
        {
            Parent business = new Parent();
            business.MakePayment(5000);

            Child newBusiness = new Child();
            newBusiness.MakePayment(5000);
            newBusiness.RecievePayment(6000);//Extendability where a class extends the existing class with new features without breaking the old one.
        }
    }
}
