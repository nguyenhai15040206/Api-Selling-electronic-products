using System;
using System.Collections.Generic;

namespace QuanLySanPhamDienTuAPI.Models
{
    public partial class NguoiDung
    {
        public NguoiDung()
        {
            HoaDon = new HashSet<HoaDon>();
            PhieuNhap = new HashSet<PhieuNhap>();
            QlNguoiDungNhomNguoiDung = new HashSet<QlNguoiDungNhomNguoiDung>();
        }

        public int MaNguoiDung { get; set; }
        public string TenNguoiDung { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public DateTime? NgayVaoLam { get; set; }
        public bool? HoatDong { get; set; }

        public virtual ICollection<HoaDon> HoaDon { get; set; }
        public virtual ICollection<PhieuNhap> PhieuNhap { get; set; }
        public virtual ICollection<QlNguoiDungNhomNguoiDung> QlNguoiDungNhomNguoiDung { get; set; }
    }
}
