using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLySanPhamDienTuAPI.AI
{
    public class AssociationRule
    {
        public ItemSet X { get; set; }
        public ItemSet Y { get; set; }

        public double Support { get; set; }
        public double Confidence { get; set; }

        public AssociationRule()
        {
            X = new ItemSet();
            Y = new ItemSet();
            Support = 0.0;
            Confidence = 0.0;
        }

        public override string ToString()
        {
            return (X + " =>" + Y + "(Supp: " + Math.Round(Support, 2)+ "%, conf: "+ Math.Round(Confidence,2)+"%)");
        }

    }
}
