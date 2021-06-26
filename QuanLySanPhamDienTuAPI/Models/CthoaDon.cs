using System;
using System.Collections.Generic;

namespace QuanLySanPhamDienTuAPI.Models
{
    public partial class CthoaDon
    {
        public int MaHoaDon { get; set; }
        public int MaSanPham { get; set; }
        public int? SoLuong { get; set; }
        public decimal? DonGia { get; set; }
        public double? GiamGia { get; set; }
        public decimal? ThanhTien { get; set; }
        public string GhiChu { get; set; }

        public virtual HoaDon MaHoaDonNavigation { get; set; }
        public virtual SanPham MaSanPhamNavigation { get; set; }
    }
}
