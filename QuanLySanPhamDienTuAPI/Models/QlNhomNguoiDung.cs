using System;
using System.Collections.Generic;

namespace QuanLySanPhamDienTuAPI.Models
{
    public partial class QlNhomNguoiDung
    {
        public QlNhomNguoiDung()
        {
            QlNguoiDungNhomNguoiDung = new HashSet<QlNguoiDungNhomNguoiDung>();
            QlPhanQuyen = new HashSet<QlPhanQuyen>();
        }

        public int MaNhom { get; set; }
        public string TenNhom { get; set; }
        public string GhiChu { get; set; }

        public virtual ICollection<QlNguoiDungNhomNguoiDung> QlNguoiDungNhomNguoiDung { get; set; }
        public virtual ICollection<QlPhanQuyen> QlPhanQuyen { get; set; }
    }
}
