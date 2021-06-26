using System;
using System.Collections.Generic;

namespace QuanLySanPhamDienTuAPI.Models
{
    public partial class NhaCungCap
    {
        public NhaCungCap()
        {
            PhieuNhap = new HashSet<PhieuNhap>();
        }

        public int MaNhaCungCap { get; set; }
        public string TenNhaCungCap { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }

        public virtual ICollection<PhieuNhap> PhieuNhap { get; set; }
    }
}
