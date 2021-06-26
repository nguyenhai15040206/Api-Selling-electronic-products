using System;
using System.Collections.Generic;

namespace QuanLySanPhamDienTuAPI.Models
{
    public partial class DanhMuc
    {
        public DanhMuc()
        {
            SanPham = new HashSet<SanPham>();
        }

        public int MaDanhMuc { get; set; }
        public string TenDanhMuc { get; set; }
        public int? MaNhaSanXuat { get; set; }
        public string GhiChu { get; set; }
        public string LogoTungDanhMucSp { get; set; }

        public virtual NhaSanXuat MaNhaSanXuatNavigation { get; set; }
        public virtual ICollection<SanPham> SanPham { get; set; }
    }
}
