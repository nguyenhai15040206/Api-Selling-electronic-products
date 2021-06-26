using System;
using System.Collections.Generic;

namespace QuanLySanPhamDienTuAPI.Models
{
    public partial class PhieuNhap
    {
        public int MaPhieuNhap { get; set; }
        public DateTime? NgayNhap { get; set; }
        public int? MaNhaCungCap { get; set; }
        public int? MaNguoiDung { get; set; }
        public decimal? TienNhap { get; set; }
        public bool? TinhTrang { get; set; }

        public virtual NguoiDung MaNguoiDungNavigation { get; set; }
        public virtual NhaCungCap MaNhaCungCapNavigation { get; set; }
        public virtual CtphieuNhap CtphieuNhap { get; set; }
    }
}
