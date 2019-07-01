using System;

/*
 * Arrays are reference types in .NET. They are objects of a class called System.Array. This class has methods and properties to get the details about the array at runtime, like Size, Dimensions, Size in each dimensions, copying the array to another, cloning the array and many more. 
 * Length: Gets the size of the Array
 * Rank: Gets the dimensions of the Array if its multi dimensional Array
 * GetLength: Gets the no of elements in the specified dimension.
 * Clone: Does a replica of the array into another
 * CopyTo: Copies the contents from one array to another from a certain index.
 * LongLength: Gets the length in the terms of long variable. 
 * 
 */
namespace SampleConApp
{
    class Arrays
    {
        static void Main(string[] args)
        {
            //singleDimensionalArray();
            //multiDimensionalArray();
            //jaggedArray();
            //dynamicArrayCreation();
        }

        private static void dynamicArrayCreation()
        {
            //With System.Array class, U could get the size and the datatype of the array from the user input and create an array at runtime and set values to it. 
            Console.WriteLine("Enter the size");
            int size = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the data type of the Array based on CTS Type");
            Type type = Type.GetType(Console.ReadLine());
            if (type == null)
            {
                Console.WriteLine("Invalid CTS Type");
                return;//exit the function if there is invalid type
            }
            Array array = Array.CreateInstance(type, size);
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("Enter the value for the type " + type.Name);
                object value = Convert.ChangeType(Console.ReadLine(), type);
                array.SetValue(value, i);                
            }
            Console.WriteLine("-------------------Reading all the values--------------------------");
            foreach (object value in array) Console.WriteLine(value);
        }

        private static void jaggedArray()
        {
            //Array of Arrays is called Jagged Array, a school as an array of classrooms where each classroom is an array of students in it. Each classroom will have variable no of students in it. In this case, U will have a fixed no of rows and variable no of columns in each row. 
            int[][] school = new int[4][];
            school[0] = new int[] { 56, 56, 56, 56, 55 };
            school[1] = new int[] { 55, 44, 33 };
            school[2] = new int[] { 66, 66, 55, 44, 55, 66, 65, 56, 45, 56 };
            school[3] = new int[] { 55, 76, 45, 45, 67, 46, 66, 88, 67, 67, 88, 78 };
            foreach(int[] classRoom in school)
            {
                foreach(int score in classRoom)
                    Console.Write(score + " ");
                Console.WriteLine();
            }
        }

        private static void multiDimensionalArray()
        {
            int[,] TwoDArray = new int[2, 3];//5 Students(5 Rows) 3 Subjects(Scores in 3 columns)....
            Console.WriteLine("The no of dimensions: " + TwoDArray.Rank);
            for (int i = 0; i < TwoDArray.GetLength(0); i++)
            {
                Console.WriteLine("Please enter the Marks for Student :" + (i + 1));
                for (int j = 0; j < TwoDArray.GetLength(1); j++)
                {
                    Console.WriteLine("Enter the Score for Subject " + (j+1));
                    TwoDArray[i, j] = int.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("------------Displaying the data in a matrix format------------------");
            for (int i = 0; i < TwoDArray.GetLength(0); i++)
            {
                for (int j = 0; j < TwoDArray.GetLength(1); j++)
                {
                    Console.Write(TwoDArray[i,j] + " ");
                }
                Console.WriteLine();//Write vs WriteLine method...
            }

        }

        private static void singleDimensionalArray()
        {
            string[] fruits = new string[10];
            for (int i = 0; i < fruits.Length; i++)
            {
                Console.WriteLine("Enter the fruit name");
                fruits[i] = Console.ReadLine();
            }

            Console.WriteLine("--------Displaying all the items in the Array-------------------");
            foreach (string item in fruits)
            {
                Console.WriteLine(item);
            }//reading the elements thro a foreach....
        }
    }
}
