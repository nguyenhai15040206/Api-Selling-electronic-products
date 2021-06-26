using System;
using System.Collections.Generic;

namespace QuanLySanPhamDienTuAPI.Models
{
    public partial class Banner
    {
        public int MaBanner { get; set; }
        public string FileBanner { get; set; }
        public bool? KichHoat { get; set; }
        public string GhiChu { get; set; }
    }
}
