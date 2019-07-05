using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleLib;
namespace SampleConApp
{
    class ConsumingDLL
    {
        static void Main(string[] args)
        {
            try
            {
                IDataComponent component = DataFactory.GetComponent();
                component.AddItem(123, "Tomato", 45);
                component.AddItem(124, "Banana", 65);
                var data = component.GetAllItems();
                foreach(DataRow row in data.Rows)
                    Console.WriteLine(row[1] +" costs " + row[2]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
