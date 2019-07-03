using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * If U have an Abstract with only abstract methods in it, It could be made as an interface. Interfaces contain only abstract methods with no fields in it. 
 * With interfaces, U can have a class that implements multiple interfaces which is not possible with Abstract classes. 
 * All methods in the interfaces are public and the class that implements the interface must implement the methods as public. 
 * interface is more like a contract where the class that implements the interface is more like implementing the contract of having x no of methods with y implementations. 
 */
namespace SampleConApp
{
    interface IProductRepository
    {
        void AddNewItem(int id, string name, double price, int quantity);
        void UpdateItem(int id, string name, double price, int quantity);
        void DeleteItem(int id);
        DataTable GetAllProducts();
        int TotalProducts { get; }
    }

    class ProductDatabase : IProductRepository
    {
        public int TotalProducts => 123;

        public void AddNewItem(int id, string name, double price, int quantity)
        {
            Console.WriteLine("Item is added");
        }

        public void DeleteItem(int id)
        {
            Console.WriteLine("item is deleted");
        }

        public DataTable GetAllProducts()
        {
            return new DataTable("Test");
        }

        public void UpdateItem(int id, string name, double price, int quantity)
        {
            Console.WriteLine("Item is updated");
        }
    }

    interface IParty
    {
        void OrderCake();
        void InvitePeople();
        void OrderFood();
        void ReturnGifts();
    }

    interface IEmployee
    {
        void Create();
    }

    interface ICustomer
    {
         void Create();
    }
   
    class PhaniParty : IParty
    {
        public void InvitePeople()
        {
            Console.WriteLine("Sent Invitation thro whatsApp");
        }

        public void OrderCake()
        {
            Console.WriteLine("Prepare the cake by myself");
        }

        public void OrderFood()
        {
            Console.WriteLine("Order the food from Pizza Hut");
        }

        public void ReturnGifts()
        {
            Console.WriteLine("Heartly wishes");
        }
    }

    class MyParty : IParty
    {
        public void InvitePeople()
        {
            Console.WriteLine("Personally inviting them");
        }

        public void OrderCake()
        {
            Console.WriteLine("Get it from French Loaf");
        }

        public void OrderFood()
        {
            Console.WriteLine("Food ordered from Nandini");
        }

        public void ReturnGifts()
        {
            Console.WriteLine("Droping them to home");
        }
    }

    interface IExample
    {
        void Create();
    }

    interface ISimple
    {
        void Create();
    }

    class SimpleExample : IExample, ISimple
    {
        //Explicit Interface Implementation...
        void ISimple.Create()
        {
            Console.WriteLine("Simple Creation");
        }

        void IExample.Create()
        {
            Console.WriteLine("Example Creation");
        }
        public void Create()
        {
            Console.WriteLine("Simple Example Creation");
        }
    }
        class InterfaceDemo
    {
        static void Main(string[] args)
        {
            //firstExample();
            //IParty party = new PhaniParty();
            //birthdayParty(party);

            ISimple sim = new SimpleExample();
            sim.Create();

            IExample ex = new SimpleExample();
            ex.Create();

            SimpleExample simEx = new SimpleExample();
            simEx.Create();
        }

        private static void birthdayParty(IParty party)
        {
            party.InvitePeople();
            party.OrderCake();
            party.OrderFood();
            party.ReturnGifts();
        }

        private static void firstExample()
        {
            IProductRepository repository = new ProductDatabase();
            repository.AddNewItem(32, "Test", 45.66, 100);
            repository.UpdateItem(32, "Test", 45.66, 100);
            repository.DeleteItem(32);
            DataTable table = repository.GetAllProducts();
            Console.WriteLine("The table is got");
        }
    }
}
