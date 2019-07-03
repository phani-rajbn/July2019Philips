using System;
/*
 * Method overriding is modifying the existing functionality that is available in the base class to a new implementation in the derived class. 
 * The base class should mark the method that is to be overriden as virtual. virtual is more like a permission to the derived class to override if required.
* derived class will override only virtual methods using a modifier called override. Only methods of the base class that are marked as virtual, override, abstract can be overriden in the derived class. 
* Overriding method cannot modify the signature of the method. No change in the name, parameters or the return type of the function. 
 */
namespace SampleConApp
{
    enum PaymentMode { Cash, Cheque, Card, UPI }
    class Parent
    {
        protected double _balance;//It is made available even in the derived class

        public Parent(double amount)
        {
            _balance = amount;
        }

        public Parent() : this(50000)
        {

        }

        public virtual void GetPayment(double amount, PaymentMode mode)
        {
            switch (mode)
            {
                case PaymentMode.Cash:  
                case PaymentMode.Cheque:
                    _balance += amount;
                    Console.WriteLine("Payment of {0:C} is made by {1}", amount, mode);
                    break;
                case PaymentMode.Card:
                case PaymentMode.UPI:
                    Console.WriteLine("Invalid Mode of Payment, not acccepted") ;
                    break;
            }
        }

        public double Balance
        {
            get { return _balance; }
        }
    }

    class Child : Parent
    {
        public Child() : base(50000)
        {
            /*
             * In Inheritance, if a base class has a parameterized constructor without a default one, then the derived class constructor must explicitly call the base class constructor using the above syntax. 
             * This need not be done if the base class is having default constructor(No Args) as the derived class constructor will implicitly call the base class's default constructor. So its adviced to always have a default constructor in ur class.
             * However, if U want to explicitly call a specific constructor of the base class if its overloaded, then also U can use base keyword.
             */
        }

        public override void GetPayment(double amount, PaymentMode mode)
        {
            //base.GetPayment(amount, mode);
            switch (mode)
            {
                case PaymentMode.Cheque:
                    Console.WriteLine("This payment mode is no longer accepted, please pay by Card or UPI or Cash");
                    break;
                case PaymentMode.Card:
                case PaymentMode.UPI:
                case PaymentMode.Cash:
                    Console.WriteLine("Payment of {0:C} is made by {1}", amount, mode);
                    break;
            }
        }
    }
    class MethodOverriding
    {
        static void Main(string[] args)
        {
            Parent currentBusiness = new Parent(50000);
            currentBusiness = new Child();
            Console.WriteLine("The Balance is " + currentBusiness.Balance);
            currentBusiness.GetPayment(5000, PaymentMode.Cash);
            currentBusiness.GetPayment(5000, PaymentMode.Cheque);
            currentBusiness.GetPayment(5000, PaymentMode.Card);
            currentBusiness.GetPayment(5000, PaymentMode.UPI);
            Console.WriteLine("The Balance is " + currentBusiness.Balance);
        }
    }
}
