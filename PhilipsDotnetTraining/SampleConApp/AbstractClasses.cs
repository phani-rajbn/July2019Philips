using System;
/*
 * Abstract classes are those that have atleast one abstract method.
 * Abstract method is one that does not have a body but only a declaration.
 * The Abstract methods are to be implemented by the derived classes. 
 * Abstract classes can have other methods also.
 * As Abstract classes have incomplete methods(Methods that are not implemented), they are incomplete classes and so, they cannot be instantiated. However U could instantiate it to any of its derived classes which implement all the abstract methods. 
 * Derived classes must implement all the abstract methods of its base class, else even this class will be marked as abstract. 
 */
namespace SampleConApp
{
    abstract class Account // This class cannot be instantiated...
    {
        public Account()
        {
            Balance = 5000;
        }
        public int AccountNo { get; set; }
        public string Name { get; set; }
        public int Balance { get; protected set; }//U cannot set the balance outside this class if its private....
        public void CreditAmount(int amount)
        {
            Balance += amount;
        }

        public void DebitAmount(int amount)
        {
            if (amount > Balance)
                throw new Exception("Insufficient funds");
            Balance -= amount;
        }

        public abstract void CalculateInterest();
    }

    //U must implement all the abstract methods of the base....
    class SBAccount : Account
    {
        public override void CalculateInterest()
        {
            double interest = Balance * 6.5 / 100 * 1 / 12;
            Balance += (int)interest;
        }
    }

    class RDAccount : Account
    {
        public override void CalculateInterest()
        {
            double interest = Balance * 8.5 / 100 * 1 / 12;
            CreditAmount((int)interest);
        }
    }
    class AbstractClasses
    {
        static void Main(string[] args)
        {
            //Use the object of the Abstract class but instantiate it to the Derived...
            Account acc = new SBAccount();
            acc.CreditAmount(5000);
            acc.CalculateInterest();
            Console.WriteLine("The Current balance is " + acc.Balance);

            acc = new RDAccount();
            acc.CreditAmount(5000);
            acc.CalculateInterest();
            Console.WriteLine("The Current balance is " + acc.Balance);
        }
    }
}
