using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Collections are available 2 versions: Generic(2.0) and Non Generic(1.0)
 * Many of the Generic collections share the common interfaces with Non Generics. 
 * Generics are type safe and work like Templates of C++.
 * Some of the important Generic Collections:
 * List<T> : ArrayList : Extended version of Array.
 * HashSet<T>: Similar to List<T> but stores only Unique values...
 * Dictionary<K,V>: HashTable<object, object> : Stores the data in the form of key-value pairs. 
 * Queue<T>: Queue: Stores the data as First in First Out. 
 * Stack<T>: Stack: Last in, First Out.
 * LinkedList<T>: Address of the next link. 
 * Collection class in .NET is one that implements an interface called IEnumerable. 
 * Above it, it can have other interfaces like ICollection, IList, ISet, IDictionary.
 * List<T>->IList<T>->ICollection<T>->IEnumerable<T>
 * Hashset<T>->ISet<T>->IList<T>.....
 * Dictionary<K,V>->IDictionary<K,V>->ICollection<K>
 * Queue<T>->ICollection<T>->IEnumerable<T>
 * Stack<T>->IEnumerable<T>->ICollection.
 * U could create UR own Custom collection Classes by implementing appropriate interfaces. U could also overload the [] operator to interate the elements thro indexers...
 */
namespace SampleConApp
{
    class Item
    {
        public int ID { get; set; }
        public string  Name { get; set; }
        public double  Amount { get; set; }
        public int Quantity { get; set; } = 1;

        //Equals, ToString and GetHashCode functions are available from the System.Object which can be overriden in our classes.....
        public override bool Equals(object obj)
        {
            //Equals method can be overriden to define how an equality be checked for the current object.....
            if (obj is Item)
            {

                Item copy = obj as Item;
                return Name == copy.Name;
            }
            else return false;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public override string ToString()
        {
            string details = string.Format("The Item Name:{0}\nThe Price:{0:C}\nQuantity:{2}\n", Name, Amount, Quantity);
            return details;
        }
    }
    class CollectionsDemo
    {
        static void Main(string[] args)
        {
            //listExample();
            //hashsetExample();
            //DictionaryExample();
            QueueExample();
        }

        private static void QueueExample()
        {
            Queue<string> recentItems = new Queue<string>();
            do
            {
                Console.WriteLine("Enter the product to view");
                if (recentItems.Count == 5)
                    recentItems.Dequeue();//Removes the first item in the list...
                recentItems.Enqueue(Console.ReadLine());
                Console.WriteLine("\n\nUr recently viewed items:");
                var list = recentItems.Reverse();
                foreach (var item in list) Console.WriteLine(item);
            } while (true);
        }

        private static void DictionaryExample()
        {
            /*
             * Stores the data as key-value pairs.
             * Key is unique and value might be same. 
             * Values can be read using key as an index. [key] will give the value of the key.
             */
            Dictionary<string, string> users = new Dictionary<string, string>();
            users.Add("Phaniraj", "welcome123");
            if(!users.ContainsKey("Phaniraj"))
                users.Add("Phairaj", "welcome123");

            users["Suresh"] = "apple123";//Adds a key-value pair if the key does not exist, else replaces the value of that key....
            users["Suresh"] = "mango123";

            foreach(var pair in users)
                Console.WriteLine("{0}:{1}", pair.Key, pair.Value);

            foreach(var key in users.Keys)
                Console.WriteLine(users[key]);

            foreach(var value in users.Values)
                Console.WriteLine(value);
        }

        private static void hashsetExample()
        {
            HashSet<Item> cart = new HashSet<Item>();
            cart.Add(new Item { ID = 1, Amount = 4500, Name = "Samsung Guru 4" });
            cart.Add(new Item { ID = 2, Amount = 1500, Name = "Philips Trimmer 1100" });
            cart.Add(new Item { ID = 3, Amount = 900, Name = "Mi X Band" });
            cart.Add(new Item { ID = 4, Amount = 14500, Name = "Mi Note 6" });

            cart.Add(new Item { ID = 1, Amount = 4500, Name = "Tomato" });
            cart.Add(new Item { ID = 1, Amount = 4500, Name = "Orange" });
            cart.Add(new Item { ID = 2, Amount = 1500, Name = "Philips Trimmer 1100" });
            cart.Add(new Item { ID = 3, Amount = 900, Name = "Mi X Band" });
            cart.Add(new Item { ID = 4, Amount = 14500, Name = "Mi Note 6" });
            Console.WriteLine("Total Items in the cart:" + cart.Count);

            foreach(Item item in cart)
                Console.WriteLine(item);
        }

        private static void listExample()
        {
            /*
             * List allows to add, remove anywhere within the collection.
             * Resolves all the limitations of an Array..
             * It does not check for Uniqueness. So U cannot use List to store unique data. 
             */
            List<string> fruits = new List<string>();
            fruits.Add("Apple");//Adds an item to the bottom of the List....
            fruits.Add("Mango");
            fruits.Add("PineApple");
            fruits.Add("Orange");
            fruits.Add("Grapes");
            fruits.Add("Banana");
            fruits.Remove("Grapes");//returns a bool.
            if (!fruits.Remove("Apple Washington")) Console.WriteLine("Fruit is not in the basket to remove");
            fruits.Add("Pomogranate");
            Console.WriteLine("The total no of fruits in the basket is " + fruits.Count);
            Console.WriteLine("Iterating thro a Foreach loop");
            foreach (string item in fruits)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Iterating thro a for loop");
            for (int i = 0; i < fruits.Count; i++)
            {
                Console.WriteLine(fruits[i]);
            }
        }
    }
}
