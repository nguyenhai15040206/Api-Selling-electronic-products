using System;
using System.Collections.Generic;

namespace QuanLySanPhamDienTuAPI.Models
{
    public partial class NhaSanXuat
    {
        public NhaSanXuat()
        {
            DanhMuc = new HashSet<DanhMuc>();
        }

        public int MaNhaSanXuat { get; set; }
        public string TenNhaSanXuat { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }

        public virtual ICollection<DanhMuc> DanhMuc { get; set; }
    }
}
