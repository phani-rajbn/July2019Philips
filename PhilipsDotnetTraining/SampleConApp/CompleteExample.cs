using System;
using System.IO;

namespace Entities
{
    class Item
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public double  Cost { get; set; }
        public short Quantity { get; set; }
    }
}

namespace DataLayer
{
    using Entities;
    //Repository Pattern is a component which can perform operations like read, Delete, update and add to a Data Structure that represent the storage of the data.
    class ItemRepository
    {
        const int size = 100;//they are also static....
        private Item[] _items = new Item[size];//Arrays are fixed in size, U cannot add, remove after the array is created, U cannot modify the Array size.....

        //Array that stores Value Types vs Array that stores reference types
        //Create
        public void AddNewItem(Item item)
        {
            //iterate thro the array to find the first null object....
            for (int i = 0; i < size; i++)
            {
                if(_items[i] == null)
                {
                    _items[i] = new Item//set the Item into that null location.
                    {
                        ItemID = item.ItemID,
                        Cost = item.Cost,
                        ItemName = item.ItemName,
                        Quantity = item.Quantity
                    };
                    return;//exit the function...
                }//Raise an Exception saying no more objects could be added....
            }
            throw new Exception("No more Items can be added to the store");
        }
            
            
            
        //Update
        public void UpdateItem(Item item)
        {
            throw new Exception("Not implemented, will come in the next version");
        }
        //Delete
        public void DeleteItem(int itemID)
        {
            //Iterate thro the collection
            for (int i = 0; i < size; i++)
            {
                //Find the matching Item with the iD
                if((_items[i] != null) && (_items[i].ItemID == itemID))
                {
                    //Set it to null.(We dont have delete operator)
                    _items[i] = null;
                    //Exit the function
                    return;
                }
            }
            throw new Exception(string.Format($"No item by ID {itemID} found to delete"));
            //If no mathching is found, throw an Exception that this ID does not exist to delete....
        }
        //Read
        public Item[] GetAllItems()
        {
            return _items;
        }
    }
}

namespace UILayer
{
    using Entities;
    static class Helper
    {
        //If U have a set of functions that are repeatedly used frequently then U can make those methods are static and place it inside a static class. 
        public static string GetString(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        public static int GetNumber(string question) => int.Parse(GetString(question));

        public static double GetDouble(string question) => double.Parse(GetString(question));

        public static short GetShort(string question) => short.Parse(GetString(question));
    }
    //If u create once and dont want to change it again, then U can go for read only members. Consts are computable at compile Time, but readonly are computable at runtime. 
    class MainProgram
    {
        static readonly DataLayer.ItemRepository repository = new DataLayer.ItemRepository();
        static string createMenu(string fileName)
        {
            StreamReader reader = new StreamReader(fileName);
            string contents = reader.ReadToEnd();
            return contents;
        }

        static void clearScreen()
        {
            Console.WriteLine("Press any key to clear");
            Console.ReadKey();
            Console.Clear();
        }
        static void Main(string[] args)
        {

            string menu = createMenu(args[0]);
            bool processing = true;
            do
            {
                string choice = Helper.GetString(menu);
                processing = processMenu(choice);
                if (processing) clearScreen();
            } while (processing);
        }

        private static bool processMenu(string choice)
        {
            switch (choice)
            {
                case "A":
                    addItemHelper();
                    return true;
                case "D":
                    deleteItemHelper();
                    return true;
                case "U":
                    return true;
                case "F":
                    findingItem();
                    return true;
                default:
                    break;
            }
            return false;
        }

        private static void findingItem()
        {
            string search = Helper.GetString("Enter the Name or part of the Name to search");
            Item[] items = repository.GetAllItems();
            foreach(Item item in items)
            {
                if((item != null) && (item.ItemName.Contains(search)))
                {
                        Console.WriteLine("The Item Details are available here:");
                    Console.WriteLine("The Item Name:" + item.ItemName);
                    Console.WriteLine("The Item Cost:" + item.Cost);
                    Console.WriteLine("The Item Quantity:" + item.Quantity);
                    Console.WriteLine();//Blank line to seperate each item
                }
            }
        }

        private static void deleteItemHelper()
        {
            //LABEL:
            int id = Helper.GetNumber("Enter the ID of the item to remove");
            try
            {
                repository.DeleteItem(id);
                Console.WriteLine("Item is removed from the Storage");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                //goto LABEL;
            }
            finally
            {
                Console.WriteLine("Thanks for your support!!!");
            }
        }

        private static void addItemHelper()
        {
            //Create an object of the Item class
            Item item = new Item();
            //Take the inputs to store the data
            item.ItemID = Helper.GetNumber("Enter the ID of the Item");
            item.ItemName = Helper.GetString("Enter the Name for this Item");
            item.Cost = Helper.GetDouble("Enter the price of this Item");
            item.Quantity = Helper.GetShort("Enter the Quantity of this Item");
            //add this item to the repository class object..
            repository.AddNewItem(item);
            Console.WriteLine("Item added successfully to the Repositore");
        }
    }
}