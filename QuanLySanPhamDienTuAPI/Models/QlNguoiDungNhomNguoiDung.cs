using System;
using System.Collections.Generic;

namespace QuanLySanPhamDienTuAPI.Models
{
    public partial class QlNguoiDungNhomNguoiDung
    {
        public int MaNguoiDung { get; set; }
        public int MaNhom { get; set; }
        public string GhiChu { get; set; }

        public virtual NguoiDung MaNguoiDungNavigation { get; set; }
        public virtual QlNhomNguoiDung MaNhomNavigation { get; set; }
    }
}
