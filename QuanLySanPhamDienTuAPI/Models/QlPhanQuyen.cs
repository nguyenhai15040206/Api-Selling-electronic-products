using System;
using System.Collections.Generic;

namespace QuanLySanPhamDienTuAPI.Models
{
    public partial class QlPhanQuyen
    {
        public int MaNhom { get; set; }
        public int MaManHinh { get; set; }
        public bool? CoQuyen { get; set; }

        public virtual DanhMucManHinh MaManHinhNavigation { get; set; }
        public virtual QlNhomNguoiDung MaNhomNavigation { get; set; }
    }
}
