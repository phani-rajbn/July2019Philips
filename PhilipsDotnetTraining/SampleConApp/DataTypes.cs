using System;
/*
 * All Data types are based on the CTS.
 * There are 2 types: Value Types and Reference types
 * Value Types: All are structures. 
 * Integral : byte(Byte), short(Int16), int(Int32), long(Int64)
 * Floating: float(Single), double(Double), decimal(Decimal)
 * Other Types: char(Char), bool(Boolean)
 * Custom : Enums and Structs along with Predefined Structs of .NET like DateTime, TimeSpan and many more....
 */
namespace SampleConApp
{
    class DataTypeDemo
    {
        static void Main(string[] args)
        {
            //basicDataTypes();
            //inputsFromUser();
            typeConversionDemo();
        }

        private static void typeConversionDemo()
        {
            //Smaller range data can be set to the large range variables.
            long value = 123;//int is shorter range data which is implicitly placed in a long variable. 
            Console.WriteLine(value);
            //longer range data can be set to the shorter range thro Typecasting..C# uses C Style Typecasting...
            //int intVal = (int)value;//value(long) is longer than int...This is called as Type casting.
            int intVal = Convert.ToInt32(value);//There is no need for casting here....
            Console.WriteLine("The int value:" + intVal);
            Console.WriteLine("For byte, MinValue:{0} and MaxValue:{1}", byte.MinValue, byte.MaxValue);
            Console.WriteLine("For short, MinValue:{0} and MaxValue:{1}", short.MinValue, short.MaxValue);
            Console.WriteLine("For int, MinValue:{0} and MaxValue:{1}", int.MinValue, int.MaxValue);
            Console.WriteLine("For float, MinValue:{0} and MaxValue:{1}", float.MinValue, float.MaxValue);
            Console.WriteLine("For long, MinValue:{0} and MaxValue:{1}", long.MinValue, long.MaxValue);
            Console.WriteLine("For decimal, MinValue:{0} and MaxValue:{1}", decimal.MinValue, decimal.MaxValue);
            Console.WriteLine("For double, MinValue:{0} and MaxValue:{1}", double.MinValue, double.MaxValue);
            //For better performance use Convert Class to perform any kind of data conversions. 
            //intVal = int.TryParse(Console.ReadLine());
            intVal = GetNumber("Enter a positive no");
            Console.WriteLine(intVal);
            //For converting string to value type, use the Parse method. For conversion from one value type to another use the Convert class. 
        }

        private static void inputsFromUser()
        {
            Console.WriteLine("Enter a number");
            int no = int.Parse(Console.ReadLine());//Parse is a method of the Structure Int32 which is used to convert string to integer if its possible, else throws Format Exception.

            Console.WriteLine("Enter the second no");
            int secondNo = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the choice as + or -");
            string choice = Console.ReadLine();
            if(choice == "+")
                Console.WriteLine("The Added value is " + (no + secondNo));
            else
                Console.WriteLine("The Subtracted value is " + (no - secondNo));
        }

        private static int GetNumber(string statement)
        {
            int result = 0;
            bool processing = false;
            do
            {
                Console.WriteLine(statement);
                processing = int.TryParse(Console.ReadLine(), out result);
                if(!processing)
                    Console.WriteLine("Invalid no, please try again");
            } while (!processing);
            return result;
        }
        private static void basicDataTypes()
        {
            int age = 42;
            Console.WriteLine("The Age is " + age);

            long sum = 123 + 234;
            Console.WriteLine("The Sum is " + sum);

            double amount = 234.345;
            Console.WriteLine("The amount is " + amount);

            float smallAmount = 123.34F;//F is required for float, else it will assume as double...
            Console.WriteLine("The Float amount is " + smallAmount);
        }
    }
}
/* POINTS TO REMEMBER:
 * Multiple Mains in a project:
 * Project->Properties->Application->StartUp Object->Select the Class which U want to execute.....
 * Casting is implicit if there is no possible loss of data while the conversion is happening. 
 * If there is a possibility of lossing the data, then the programmer must explicitly(forcefully) convert the data thro Casting..
 * Convert class could be used to perform basic conversion from one type to any type in .NET. It has static methods that can convert any data type to another.
 * Parse is used to convert string to value type, TryParse will evaluate if the conversion is possible or not. Convert class to convert from one type to another(Value type conversions). Parse and TryParse are used for converting string to its value type. Almost all the Value types have these 2 functions. 
 */