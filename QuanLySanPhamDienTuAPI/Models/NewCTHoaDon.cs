using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLySanPhamDienTuAPI.Models
{
    public class NewCTHoaDon
    {
        int maHoaDon;
        int maSanPham;
        string tenSanPham;
        string hinhAnh;
        int soLuong;
        double donGia;
        double giamGia;

        public int MaSanPham { get => maSanPham; set => maSanPham = value; }
        public string TenSanPham { get => tenSanPham; set => tenSanPham = value; }
        public string HinhAnh { get => hinhAnh; set => hinhAnh = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public double DonGia { get => donGia; set => donGia = value; }
        public double GiamGia { get => giamGia; set => giamGia = value; }
        public int MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
    }
}
