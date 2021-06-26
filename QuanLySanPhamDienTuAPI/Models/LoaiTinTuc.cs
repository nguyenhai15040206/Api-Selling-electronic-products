using System;
using System.Collections.Generic;

namespace QuanLySanPhamDienTuAPI.Models
{
    public partial class LoaiTinTuc
    {
        public LoaiTinTuc()
        {
            TinTuc = new HashSet<TinTuc>();
        }

        public int MaLoaiTin { get; set; }
        public string TenLoaiTin { get; set; }
        public string GhiChu { get; set; }

        public virtual ICollection<TinTuc> TinTuc { get; set; }
    }
}
