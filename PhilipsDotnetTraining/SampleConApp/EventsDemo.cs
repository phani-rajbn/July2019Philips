using System;
using System.Text;
/*
 * Action performed on the object is called Event.
 * All Events are instances of delegates and created using event keyword. 
 * Func and Action are generic Delegates that can be used on any kind of data types and on any no of parameters.
 * Func is used for Functions with return types and Action is used for void Functions.
 * Events will be associated with Event handlers, which are functions that are invoked when the event occurs. 
 */
namespace SampleConApp
{
    //We are using the .NET Delegates instead of custom delegates in this example.
    class Database
    {
        public event Action<string> OnInsert;//All Events are creatd with a keyword called event, usualy public and an instance of a delegate
        public void InsertRecord(params object[] args)
        {
            if (args.Length == 4)
            {
                StringBuilder builder = new StringBuilder();
                foreach (var obj in args)
                    builder.Append(string.Format("{0},", obj));
                Console.WriteLine(builder.ToString().TrimEnd(','));
                OnInsert("Insertion successfull");//Trigger the event here.....
            }
            else
                OnInsert("Insertion failed as argslist is wrong");//Trigger the event here.....
        }
    }
    class EventsDemo
    {
        static void Main(string[] args)
        {
            Database db = new Database();
            db.OnInsert += Db_OnInsert;
            db.InsertRecord(123, "Phaniraj", "Bangalore", 23423423432);
        }

        private static void Db_OnInsert(string statement)
        {
            Console.WriteLine(statement);
        }
    }
}
