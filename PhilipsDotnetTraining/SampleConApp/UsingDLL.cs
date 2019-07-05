using System;

/*If a class of a DLL has to be consumed in this project, then U should do the following things:
 * Add the reference of the DLL: Project Reference(If its in the same soln) or Browse(If the Project is not in the current soln).
 * Use the namespace in which the class is created...By Default, the projectname is the namespace of the project...
 * Create the object of the class like any other class creation U have done till now...
 * Dlls make UR App more modular in nature as the code is divided into multiple projects and code is reusable across different projects. 
 * Dynamic Link Library files are loaded at runtime when the App begins its execution. 
 * Sometimes, U may have to load the dll programmatically without referencing it or using the namespaces or sometimes load them when U need instead of loaded at the begining of UR project execution. 
 * This is done thro REFLECTION. Reflection is a library of classes that allows to read the metadata of the Assembly and get its Information like Types, Methods and so forth and with which we could load the classes and invoke the methods of those classes. 
 * 
*/
namespace SampleConApp
{
    using MathComponentLib;
    class UsingDLL
    {
        static void Main(string[] args)
        {
            var com = new MathObject();
            var data = com.AddFunc(123, 234);
            Console.WriteLine(data);
        }
    }
}
