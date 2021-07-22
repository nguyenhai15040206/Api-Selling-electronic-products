using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLySanPhamDienTuAPI.AI
{
    public class AprioriAlgorithm
    {

        public static ItemSetCollection DoApriori(ItemSetCollection db, double minSupport)
        {
            ItemSet I = db.GetUniqueItem();
            ItemSetCollection L = new ItemSetCollection();// tập bổ biến lớn
            ItemSetCollection Li = new ItemSetCollection(); // các tập hợp sau mỗi lần lặp
            ItemSetCollection Ci = new ItemSetCollection();// Các tập hợp đã được lặp sau mỗi lần lặp

            // Lầ lặp đầu tiên
            foreach(string item in I)
            {
                Ci.Add(new ItemSet(){ item });
            }

            // lần lặp kế tiếp
            int k = 2;
            while(Ci.Count !=0)
            {
                Li.Clear();
                foreach(ItemSet itemset in Ci)
                {
                    itemset.Support = db.FindSupport(itemset);
                    if(itemset.Support >= minSupport)
                    {
                        Li.Add(itemset);
                        L.Add(itemset);
                    }    
                }

                // set Ci từ lần lặp tiếp theo ( tìm tập con phổ biến của Li)
                Ci.Clear();
                Ci.AddRange(Bit.FindSubsets(Li.GetUniqueItem(), k)); // nhập tập con k-item
                k +=1;
            }    
            return L;
        }

        

        public static List<AssociationRule> ResultDoApriori(ItemSetCollection db, ItemSetCollection L, double minConfidence)
        {
            List<AssociationRule> listRule = new List<AssociationRule>();
            foreach(ItemSet itemset in L)
            {
                ItemSetCollection subsets = Bit.FindSubsets(itemset, 0); // nhận tất cả các tập con
                foreach(ItemSet subset in subsets)
                {
                    double confidence = (db.FindSupport(itemset) / db.FindSupport(subset) * 100.0);
                    if(confidence >= minConfidence)
                    {
                        AssociationRule rule = new AssociationRule();
                        rule.X.AddRange(subset);
                        rule.Y.AddRange(itemset.Remove(subset));
                        rule.Support = db.FindSupport(itemset);
                        rule.Confidence = confidence;
                        if(rule.X.Count >0 && rule.Y.Count >0)
                        {
                            listRule.Add(rule);
                        }    
                    }    
                }
            }    
            return listRule;
        }
    }
}
