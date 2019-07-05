using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * DLLs are precompiled units that are available as binary files that can be consumed by multiple apps. With .NET, Dlls are language independent which means that a C# written DLL can be consumed on any .NET language like VB, J# and many more.
 * The binary files in .NET are called as Assembly. An Assembly is the deployment unit of .NET. Even an EXE is an Assembly. 
 * Assembly can be either DLLs or EXEs. They contain ByteCode called MSIL(MS Intermediate Language) and metadata about the IL Code called Manifest. .NET Apps dont have header file concept where the declarations of functions and classes are not required,as the Assemblies contain metadata which can be used as declarations of the code.
 */
namespace SampleLib
{
    public interface IDataComponent
    {
        void AddItem(int id, string name, double cost);
        void DeleteItem(int id);
        DataTable GetAllItems();
    }

    [Serializable]//Attributes are injectable properties which have some code that is injected at runtime and is evaluated by the applications using REFLECTION. Serializable is a builtin Attribute of .NET for performing serialization on UR object. Serialization is an ability to save a state of the object for a certain period of time which can be retrieved later either by the same process or by another process. 
    class DataObject : IDataComponent
    {
        Dictionary<int, string> _items = new Dictionary<int, string>();
        public void AddItem(int id, string name, double cost)
        {
            if (_items.ContainsKey(id))
                throw new Exception("ID already exists");
            _items[id] = string.Format($"{name},{cost}");
        }

        public void DeleteItem(int id)
        {
            if(!_items.ContainsKey(id))
                throw new Exception("Item not found to delete");
            _items.Remove(id);
        }

        public DataTable GetAllItems()
        {
            DataTable table = new DataTable("TableOfItems");
            table.Columns.Add("ItemID", typeof(int));
            table.Columns.Add("ItemName", typeof(string));
            table.Columns.Add("ItemCost", typeof(int));
            foreach(var pair in _items)
            {
                DataRow row = table.NewRow();
                row[0] = pair.Key;
                var values = pair.Value.Split(',');
                row[1] = values[0];
                row[2] = values[1];
                table.Rows.Add(row);
            }
            table.AcceptChanges();
            return table;
        }
    }

    public static class DataFactory
    {
        public static IDataComponent GetComponent()
        {
            return new DataObject();
        }
    } 
}
