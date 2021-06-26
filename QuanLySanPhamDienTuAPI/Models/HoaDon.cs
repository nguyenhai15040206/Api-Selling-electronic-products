using System;
using System.Collections.Generic;

namespace QuanLySanPhamDienTuAPI.Models
{
    public partial class HoaDon
    {
        public HoaDon()
        {
            CthoaDon = new HashSet<CthoaDon>();
        }

        public int MaHoaDon { get; set; }
        public DateTime? NgayBan { get; set; }
        public DateTime? NgayGiao { get; set; }
        public int? MaKhachHang { get; set; }
        public decimal? TienBan { get; set; }
        public double? GiamGia { get; set; }
        public decimal? TongTien { get; set; }
        public string GhiChu { get; set; }
        public int? MaNguoiDung { get; set; }
        public bool? TinhTrang { get; set; }

        public virtual KhachHang MaKhachHangNavigation { get; set; }
        public virtual NguoiDung MaNguoiDungNavigation { get; set; }
        public virtual ICollection<CthoaDon> CthoaDon { get; set; }
    }
}
