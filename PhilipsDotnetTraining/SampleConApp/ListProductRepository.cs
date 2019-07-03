using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    using Entities;
    class ListProductRepository : ItemRepository
    {
        HashSet<UniqueItem> _items = new HashSet<UniqueItem>();

        public override void AddNewItem(Item item)
        {
            if(item is UniqueItem)
            {
                var tempItem = item as UniqueItem;
                if (!_items.Add(tempItem))
                {
                    throw new Exception("Item already exists");
                }
                return;
            }
            else
            {
                throw new Exception("Not a valid item to Add");
            }
            
        }

        public override void UpdateItem(Item item)
        {
            foreach (var selecteditem in _items)
            {
                if(selecteditem.ItemID == item.ItemID)
                {
                    selecteditem.ItemName = item.ItemName;
                    selecteditem.Cost = item.Cost;
                    return;
                }
            }
            throw new Exception("No Item is found matching the iD to update");
        }

        public override Item[] GetAllItems()
        {
            return _items.ToArray();
        }
    }
}
