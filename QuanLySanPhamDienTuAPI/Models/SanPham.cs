using System;
using System.Collections.Generic;

namespace QuanLySanPhamDienTuAPI.Models
{
    public partial class SanPham
    {
        public SanPham()
        {
            CthoaDon = new HashSet<CthoaDon>();
            CtphieuNhap = new HashSet<CtphieuNhap>();
        }

        public int MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public int? SoLuong { get; set; }
        public decimal? DonGia { get; set; }
        public decimal? DonGiaNhap { get; set; }
        public string MoTa { get; set; }
        public string MoTaChiTiet { get; set; }
        public string KhuyenMai { get; set; }
        public decimal? GiamGia { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public string XuatXu { get; set; }
        public string HinhMinhHoa { get; set; }
        public string DsHinh { get; set; }
        public int? MaDanhMuc { get; set; }
        public bool? TinhTrang { get; set; }

        public virtual DanhMuc MaDanhMucNavigation { get; set; }
        public virtual ICollection<CthoaDon> CthoaDon { get; set; }
        public virtual ICollection<CtphieuNhap> CtphieuNhap { get; set; }
    }
}
