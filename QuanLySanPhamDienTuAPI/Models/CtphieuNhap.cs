using System;
using System.Collections.Generic;

namespace QuanLySanPhamDienTuAPI.Models
{
    public partial class CtphieuNhap
    {
        public int MaPhieuNhap { get; set; }
        public int? MaSanPham { get; set; }
        public int? SoLuong { get; set; }
        public decimal? GiaNhap { get; set; }
        public decimal? ThanhTien { get; set; }

        public virtual PhieuNhap MaPhieuNhapNavigation { get; set; }
        public virtual SanPham MaSanPhamNavigation { get; set; }
    }
}
