using System;

/*
 * A Class typically has methods to manipulate the data. We use methods to compute some value based on the inputs provided in the form of parameters and give a result out of the computation. The value that has been computed might be set or affect the data of the class. 
 * Functions are typically created to manipulate the data. 
 * In C#, every method is created either within the class or the structure. There is no concept of global functions. 
 * A class can have either a static function or NonStatic(Instance) Functions. Static Functions are invoked by the name of the class whereas the instance functions are invoked thro an object only. 
 * Parameters within the function can be either passed by value, out , ref or params.
 * Static methods gives the feel of global functions as they are not associated with any object. We create static functions where U dont want to have the burden of creating objects or when U want to share a data among all the instances of the class.
 * Static methods can be invoked inside the Instance methods, but the reverse is not possible as the instance methods have to be always invoked thro an object, even if its in the same class. However U could call that method by creating an instance of the class inside the static method and then invoke it thro that object.
 */
namespace SampleConApp
{
    class Example
    {
        private int data;
        private static int no;
        public static void TestFunc(int no)
        {
            Example copy = new Example();
            copy.NormalFunc(123);
            Example.no = no;
            Console.WriteLine("Test func invoke thro Classname");
            Console.WriteLine("The Static value is " + Example.no);
        }

        public void NormalFunc(int value)
        {
            data += value * value + (value + value);
            Console.WriteLine("Normal Func invoked thro object");
        }

        public void DisplayValue()
        {
            TestFunc(123);
            Console.WriteLine("The Data is " + data);
        }
    }

    class MathComponent
    {
        public static double AddFunc(double firstValue, double secondValue) => firstValue + secondValue;

        public static double SubFunc(double v1, double v2) => v1 - v2;

        public static double MulFunc(double v1, double v2) => v1 * v2;

        public static double DivFunc(double v1, double v2) => v1 / v2;

        public static double Square(double v1) => MulFunc(v1, v1);

        public static double SquareRoot(double no) => Math.Sqrt(no);

        public static void AllFunctions(double v1, double v2, ref double res1, ref double res2, ref double res3, out double res4)
        {
            res1 = v1 + v2;
            res2 = v1 - v2;
            res3 = v1 * v2;
            if (v2 != 0)
                res4 = v1 / v2;
            else
                res4 = 0;
            //out parameter must be set with a value within the function before it is returned to the caller. IN this case, res4 must be set with any value even for the else condition. out parameter is not initialized by the caller, but is expected as a value from the Function itself, function must guarantee it. 
        }

        public static double GetSum(params double [] inputs)
        {
            double result = 0.0;
            foreach (double input in inputs)
                result += input;
            return result;
        }
    }
    class MethodsExample
    {
        static void Main(string[] args)
        {
            // concept();
            //callStaticMethods();
            //passByReference();
            //passByReferenceExample();
            //paramsExample();
        }

        private static void paramsExample()
        {
            //Params allows to pass variable no of args to the function. It is similar to ... of C++. 
            //Params should be last of the paramter list, It will always be an array, there can be only one params within a function. Params cannot be passed using ref or out keywords. 
            double res = MathComponent.GetSum(123, 23, 34, 23, 234, 234, 4, 5, 5, 23, 4);
            Console.WriteLine("The Final Sum:" + res);
        }

        private static void passByReferenceExample()
        {
            //The values that is passed to the function as reference is initialized before sending into the function. 
            //With out parameter, the caller need not intialize the values, rather he gets the values from the function similar to an output of a function, hense the name out parameter..
            double added = 0, subtracted = 0, multiplied = 0, div = 0;
            MathComponent.AllFunctions(14, 2, ref added, ref subtracted, ref multiplied, out div);

            Console.WriteLine("The Multiplied value " + multiplied);
            Console.WriteLine("The Divided value " + div);
        }

        private static void passByReference()
        {
            int value = 2;
            PassValueFunc(ref value);
            Console.WriteLine("The Current Value:" + value);
        }

        //Copy goes into the function and the original is still with the caller. The caller will not get the modified value in the function....
        //When its passed by ref, the same value will be passed as arg and any changes made to the value will be retained even after the function returns to the caller. 
        static void PassValueFunc(ref int value)
        {
            Console.WriteLine("value: " + value);
            value += value + (value * value);
            Console.WriteLine("Changed Value:" + value);
            //Value is local to this function...
        }

        private static void callStaticMethods()
        {
            Console.WriteLine("The Added value is " + MathComponent.AddFunc(123,23));
            Console.WriteLine("The Subtracted value is " + MathComponent.SubFunc(123,23));
            Console.WriteLine("The Multiplied value is " + MathComponent.MulFunc(123,23));
            Console.WriteLine("The Divided value is {0:#.##}" ,MathComponent.DivFunc(12876873,23));
        }

        private static void concept()
        {
            Example.TestFunc(123);//Static methods are invoked only thro the classname

            Example ex = new Example();
            ex.NormalFunc(3);//U need an instance of the class....
            ex.DisplayValue();

            Example ex2 = new Example();
            ex2.NormalFunc(4);
            ex2.DisplayValue();

            Example.TestFunc(234);
            Example.TestFunc(345);
            Example.TestFunc(456);
            Example.TestFunc(567);
        }
    }
}
