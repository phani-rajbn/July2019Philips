using System;
/*
 * Enums are user defined types which store the data as Names, they are called as named consts. They internally represent integral value but is refered by name. Enums are usually group of values incremented by 1 'enum' means incrementing by 1. 
 * They are usualy created to represent a set of values and the variable created will hold any one of those values at any point. WeekDay is an enum that can hold any day but not any other values. MonthOfYear is designed to hold a Month of an Year but will not store any other value.  
 * U can set any integral type to the enum by using : integral type
 * U can get the value of the enum by typecasting it to int or any intergral type U have set for the enum.
 * All Enums can be represented by a class called System.Enum whose static methods can be used to get info about the Enums like its Values, Conversion from string to its type and getting its type info and many more.
 */
namespace SampleConApp
{
    enum AppStatus : long {  Processing, Rejected, Approved, Pending, Closed }
    class EnumsExample
    {
        static void Main(string[] args)
        {
            AppStatus status;
            status = AppStatus.Processing;
            Console.WriteLine("The integral Value of status is " + (short)status);
            Console.WriteLine("The internal data type is " + status.GetTypeCode());
            //Console.WriteLine("The Statis of the Application is " + status);//Read the enum value
            //Console.WriteLine("The Current status of my App is " + AppStatus.Pending);
            //Console.WriteLine("The Current status of my Application after 2 weeks will be " + AppStatus.Approved);
            //Console.WriteLine("The Status of the Application after the loan is cleared will be " + AppStatus.Closed);

            Console.WriteLine("Enter the status of the Current App from the list below");
            Array values = Enum.GetValues(typeof(AppStatus));
            foreach (object val in values) Console.WriteLine(val);
            status = (AppStatus)Enum.Parse(typeof(AppStatus), Console.ReadLine(), true);
            //Enum.Parse returns object which will be casted to the AppStatus. This is called UNBOXING. object is being converted to the specific type.
            Console.WriteLine("The Status selected by the user:" + status);

        }
    }
}
