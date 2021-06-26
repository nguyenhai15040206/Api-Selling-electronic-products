using System;
using System.Collections.Generic;

namespace QuanLySanPhamDienTuAPI.Models
{
    public partial class DanhMucManHinh
    {
        public DanhMucManHinh()
        {
            QlPhanQuyen = new HashSet<QlPhanQuyen>();
        }

        public int MaManHinh { get; set; }
        public string TenManHinh { get; set; }

        public virtual ICollection<QlPhanQuyen> QlPhanQuyen { get; set; }
    }
}
