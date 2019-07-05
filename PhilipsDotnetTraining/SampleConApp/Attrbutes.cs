using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Attributes are injectable properties used to add additional logic and evaluate it at runtime. These logic could be like providing serialization support to classes, Compiler specific instructions, warnings provider. 
 * Attributes could be builtin or Custom. All Custom Attributes are derived from System.Attribute Class. 
 * The values of the attributes are accessed only thro REFLECTION.
 * Serializable is an attribute that we set for all classes whose objects can be serialized. The Attribute would add an extra feature for those classes so that they can be persisted thro serialization. 
 */
namespace SampleConApp
{
    enum GenderInfo {  Male, Female };
    //Attributes are sufixed with Attribute
    [AttributeUsage(AttributeTargets.Class)]
    class GenderAttribute : Attribute
    {
        public GenderAttribute(GenderInfo info)
        {
            GenderInfo = info;
        }
        public GenderInfo GenderInfo { get; private set; }
    }

    [Gender(GenderInfo.Male)]
    class Employee
    {
        public int EmpID { get; set; }
        public int EmpName { get; set; }
        public int EmpAddress { get; set; }
        public int EmpSalary { get; set; }
    }
    static class GetAttributeInfo
    {
        public static void GetInfo(Type type)
        {
            var allAttributes = type.GetCustomAttributes(false);
            foreach(var attribute in allAttributes)
            {
                if(attribute is GenderAttribute)
                {
                    var info = attribute as GenderAttribute;
                    if(info.GenderInfo == GenderInfo.Male)
                    {
                        Console.WriteLine("Add some code for Male Employees");
                    }else
                        Console.WriteLine("Add some code for Female Employees");
                }
            }    
        }
    }
    class Attrbutes
    {
        //STAThread: This is an attribute that U set for Entry point in Win Based App. This will ensure that the Main thread will not allow child Threads to access the components which is a feature of Win32 GUI Apps. 
        
        static void Main(string[] args)
        {
            Employee emp = new Employee();
            GetAttributeInfo.GetInfo(emp.GetType());
        }
    }
}
