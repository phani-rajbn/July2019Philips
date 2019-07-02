using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    //class Customer
    //{
    //    private int _cstID;

    //    public int CustomerID
    //    {
    //        get { return _cstID; }
    //        set { _cstID = value; }
    //    }

    //    private string _cstName;

    //    public string CustomerName
    //    {
    //        get { return _cstName; }
    //        set { _cstName = value; }
    //    }

    //    private string _address;//2+1+1+1

    //    public string CustomerAddress
    //    {
    //        get { return _address; }
    //        set { _address = value; }
    //    }


    //}

//This class is created using the new syntax of C# 4.0 called Automatic properties. 
    class Customer
    {
        public int CustomerID { get; set; }//Internally the private data will be created and managed by the .NET Envinroment. 

        public string CustomerName { get; set; }

        public string CustomerAddress { get; set; }
        //Automatic Properties are designed to hide lot of implementations and simplify the code. They have have both get, set, only get or set and sometimes with access specifier

        public double BillAmount { get; private set; }//private set will allow to set the value within the class

        public void AddItemToBill(string itemName, double amount)
        {
            BillAmount += amount;//BillAmount is being set within the class but U can read the data outside the class...
        }
    }
    class AutomaticProperties
    {
        static void Main(string[] args)
        {
            Customer cst = new Customer
            {
                CustomerID = 123,
                CustomerAddress = "Bangalore",
                CustomerName="Phaniraj"
                
            };

            cst.AddItemToBill("Apples", 450);
            cst.AddItemToBill("Mangoes", 150);
            cst.AddItemToBill("Tomatoes", 50);
            cst.AddItemToBill("Onions", 10);
            Console.WriteLine("The Name of the Customer is " + cst.CustomerName + "\nHe is from " + cst.CustomerAddress +"\nHis Customer ID is " + cst.CustomerID);
            Console.WriteLine("The Total Bill for this customer is " + cst.BillAmount);
        }
    }
}
