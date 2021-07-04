using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLySanPhamDienTuAPI.AI
{
    public class ItemSet : List<String>
    {
        public double Support { get; set; }
        public bool Contains(ItemSet itemset)
        {
            return (this.Intersect(itemset).Count() == itemset.Count);
        }

        public ItemSet Remove(ItemSet itemset)
        {
            ItemSet removed = new ItemSet();
            removed.AddRange(from item in this
                             where !itemset.Contains(item)
                             select item);
            return (removed);
        }
    }
}
