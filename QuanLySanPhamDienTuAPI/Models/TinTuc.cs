using System;
using System.Collections.Generic;

namespace QuanLySanPhamDienTuAPI.Models
{
    public partial class TinTuc
    {
        public int MaTinTuc { get; set; }
        public string TenTinTuc { get; set; }
        public string NoiDung { get; set; }
        public DateTime? NgayDang { get; set; }
        public string AnhMinhHoa { get; set; }
        public bool? KichHoat { get; set; }
        public string GhiChu { get; set; }
        public int? MaLoaiTin { get; set; }

        public virtual LoaiTinTuc MaLoaiTinNavigation { get; set; }
    }
}
