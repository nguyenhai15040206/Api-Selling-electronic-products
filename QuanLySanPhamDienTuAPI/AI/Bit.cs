using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLySanPhamDienTuAPI.AI
{
    public class Bit
    {
        public static ItemSetCollection FindSubsets(ItemSet itemset, int n) // n là số giao dịch chứa X
        {
            ItemSetCollection subsets = new ItemSetCollection(); // tập hợp con
            int subsetCount = (int)Math.Pow(2, itemset.Count);
            for(int i=0; i< subsetCount; i++)
            {
                if(n==0 || GetOnCount(i, itemset.Count) == n)
                {
                    string binary = DecimalToBinary(i, itemset.Count);
                    ItemSet subset = new ItemSet();
                    for(int j=0; j <binary.Length; j++)
                    {
                        if (binary[j] == '1')
                        {
                            subset.Add(itemset[j]);
                        }
                    }
                    subsets.Add(subset);
                }
            }
            return subsets;
        }


        public static int GetBit(int value, int position)
        {
            int bit = value & (int)Math.Pow(2, position);
            return (bit > 0 ? 1 : 0);
        }

        public static string DecimalToBinary(int value, int lenght)
        {
            string binary = string.Empty;
            for(int position=0; position< lenght; position ++)
            {
                binary = GetBit(value, position) + binary;

            }
            return binary;
        } 

        public static int GetOnCount(int value, int lenght)
        {
            string binary = DecimalToBinary(value, lenght);
            var rs = (from char c in binary.ToCharArray() where c == '1' select c).Count();
            return rs;
        }
    }
}
