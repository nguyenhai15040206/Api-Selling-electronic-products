using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLySanPhamDienTuAPI.Models
{
    public class NewSanPham
    {
        int maSanPham;
        string tenSanPham;
        int soLuong;
        double donGia;
        double donGiaNhap;
        string moTa;
        string moTaChiTiet;
        string khuyenMai;
        double giamGia;
        DateTime ngayCapNhat;
        string xuatXu;
        string hinhMinhHoa;
        string dsHinh;
        bool tinhTrang;
        string ghiChu;
        string tenDanhMuc;

        public int MaSanPham { get => maSanPham; set => maSanPham = value; }
        public string TenSanPham { get => tenSanPham; set => tenSanPham = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public double DonGia { get => donGia; set => donGia = value; }
        public double DonGiaNhap { get => donGiaNhap; set => donGiaNhap = value; }
        public string MoTa { get => moTa; set => moTa = value; }
        public string MoTaChiTiet { get => moTaChiTiet; set => moTaChiTiet = value; }
        public string KhuyenMai { get => khuyenMai; set => khuyenMai = value; }
        public double GiamGia { get => giamGia; set => giamGia = value; }
        public DateTime NgayCapNhat { get => ngayCapNhat; set => ngayCapNhat = value; }
        public string XuatXu { get => xuatXu; set => xuatXu = value; }
        public string HinhMinhHoa { get => hinhMinhHoa; set => hinhMinhHoa = value; }
        public string DsHinh { get => dsHinh; set => dsHinh = value; }
        public bool TinhTrang { get => tinhTrang; set => tinhTrang = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
        public string TenDanhMuc { get => tenDanhMuc; set => tenDanhMuc = value; }
    }
}
