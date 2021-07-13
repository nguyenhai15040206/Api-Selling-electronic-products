using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuanLySanPhamDienTuAPI.Models;

namespace QuanLySanPhamDienTuAPI.AI
{
    public class ItemSetCollection : List<ItemSet>
    {

        // lọc danh sách item lấy ra item không được trùng nhau(Unique)
        public ItemSet GetUniqueItem()
        {
            ItemSet unique = new ItemSet();
            foreach(ItemSet itemSet in this)
            {
                unique.AddRange(from item in itemSet
                                where !unique.Contains(item)
                                select item);
            }
            return unique;
        }

        // tính độ Support
        public double FindSupport(ItemSet item)
        {
            int matchCount = (from itemset in this
                              where itemset.Contains(item)
                              select itemset).Count();
            double support = ((double)matchCount / (double)this.Count) * 100.0;
            return support;
        }
    }
}
