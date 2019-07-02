using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Properties are like functions that have getters and setters to get and set data to the object.
 * Data for the class will be usually private, meaning they are unavailable outside the class.
 * To read and write to the data, we use properties. 
 * Properties are implemented in 2 ways: Proper implementation and Auto Properties.
 * Since C# 4.0, programmers use Auto Properties where we dont need to implement any functionality for them.
 * U can have only get and set also for a property, but for only set, method is recommended.
 * Old Programs used to have their data as private and have functions to read and write the data. Usually the functions that get the data were having a prefix called Get and the functions that were used to set the values were having methods by prefix set. 
 * Now in C#, U can have one property for both get and the set functionality. Internally the property behaves like a function but is used like a field. 
 */
namespace SampleConApp
{
    class PropertiesExample
    {
        static void Main()
        {
            //Instantiation of the class.
            Book bk = new Book(111, "Professional C#", "Herbert Schildt", 560);
            //Console.WriteLine("The cost  of the Book {0} written by {1} is {2:C}", bk.GetTitle(), bk.GetAuthor(), bk.GetPrice());//Reading the data by accessing the members thro the object....

            Console.WriteLine("The Book's Title is " + bk.BookTitle);
            Console.WriteLine("It is written by " + bk.BookAuthor);
            Console.WriteLine("It is priced at Rs." + bk.BookPrice);//Properties provide an easy way to read and write data to the class object. 
        }
    }

    class Book
    {
        //if U dont specify the access specifier within the class, the members will be automatically private, implies they are unavailable outside the class. Data is usually hidden, this is called Encapsulation.  
        int _bookID;
        string _title;
        string _author;
        int _cost;

        public Book(int id, string title, string auth, int cost)
        {
            _bookID = id;
            _title = title;
            _author = auth;
            _cost = cost;
        }

        //Property for the BookID:
        public int BookID
        {
            get
            {
                //return the value
                return _bookID;
            }
            set
            {
                _bookID = value;//value is a smart keyword that represents the data set by the user. 
                //set the value assigned by the user to the private field
            }
        }

        public string BookTitle
        {
            get { return _title; }
            set { _title = value; }//value will have the data type of the property.
        }
        //set for other fields....
        public string BookAuthor
        {
            get { return _author; }
            set { _author = value; }
        }

        public int BookPrice
        {
            get { return _cost; }
            set { _cost = value; }
        }
        //Functions that U want UR users to call them will be usually public. However U could make then private(within the class) or protected(within the class and its derived class) or internal(Within the project). public is unrestricted access to the member where the user can invoke  it at any location within the Application. 
        //public int GetBookID()
        //{
        //    return _bookID;
        //}

        //public string GetTitle()
        //{
        //    return _title;
        //}

        //public string GetAuthor()
        //{
        //    return _author;
        //}

        //public int GetPrice()
        //{
        //    return _cost;
        //}

    }
}
