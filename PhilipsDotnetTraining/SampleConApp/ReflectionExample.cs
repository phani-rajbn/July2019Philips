using System;
using System.Reflection;

/*
 * With Reflection, we can read the info about the class and its methods by accessing the metadata of the Assembly that we programmatically load....
 * Assembly contains Classes, Interfaces, structs, Enums, Delegates grouped into namespaces. 
 * 
 */
namespace SampleConApp
{
    class ReflectionExample
    {
        static Assembly assembly;
        static Type selectedType;
        static MethodInfo selectedMethod;
        const string dllFile = @"C:\Users\phani\source\repos\PhilipsDotnetTraining\MathComponentLib\bin\Debug\MathComponentLib.dll";

        static void getClassDetails()
        {
            assembly = Assembly.LoadFile(dllFile);
            if (assembly == null)
                return;
            Type[] ourClasses = assembly.GetTypes();
            foreach (var type in ourClasses)
                Console.WriteLine(type.FullName);
        }
        static void Main(string[] args)
        {
            getClassDetails();
            getMethodDetails();
            getParameterDetails();
            object instance = Activator.CreateInstance(selectedType);
            if(selectedMethod.GetParameters().Length == 0)
            {
                //No parameters for this function...
                var value = selectedMethod.Invoke(instance, null);
                Console.WriteLine(value);
                return;
            }
            else
            {
                var parameters = selectedMethod.GetParameters();
                object[] pmValues = new object[parameters.Length];
                for (int i = 0; i < parameters.Length; i++)
                {
                    Console.WriteLine("Enter the value for the parameter {0} of the data type {1}", parameters[i].Name, parameters[i].ParameterType.Name);
                    pmValues[i] = Convert.ChangeType(Console.ReadLine(), parameters[i].ParameterType);
                }
                Console.WriteLine("All the parameters are set, \nLets invoke");
                var result = selectedMethod.Invoke(instance, pmValues);
                Console.WriteLine("The Result: " + result);
            }
        }

        private static void getParameterDetails()
        {
            
            Console.WriteLine("Enter the method to invoke from the list above");
            selectedMethod = selectedType.GetMethod(Console.ReadLine());
            if (selectedMethod == null)
            {
                Console.WriteLine("This method is not supported by our class");
            }
        }

        private static void getMethodDetails()
        {

            Console.WriteLine("Please enter the class that U want to find details");
            var name = Console.ReadLine();
            selectedType = assembly.GetType(name, false, true);
            if (selectedType == null)
            {
                Console.WriteLine("Invalid class selected");
                return;
            }

            var methods = selectedType.GetMethods();
            foreach (var method in methods)
            {
                Console.WriteLine($"{method.Name}, Its returntype: {method.ReturnType.Name}, Its Arguments: ");
                foreach (var pm in method.GetParameters())
                    Console.WriteLine("Parameter {0}, DataType:{1}", pm.Name, pm.ParameterType.Name);
            }
        }
    }
}
