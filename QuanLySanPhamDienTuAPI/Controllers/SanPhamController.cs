using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLySanPhamDienTuAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLySanPhamDienTuAPI.Controllers
{
    [Route("Home/Introduct/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        QL_SanPhamContext db = new QL_SanPhamContext();
        public static string base_url = "http://192.168.1.3:5000/";

        public List<NewSanPham> getSanPhamPaginationList(int page = 1, int limit = 10)
        {
            var listModel = new List<NewSanPham>();
            var sp = (from c in db.DanhMuc
                      join b in db.SanPham on c.MaDanhMuc equals b.MaDanhMuc
                      select new NewSanPham
                      {
                          MaSanPham = b.MaSanPham,
                          TenSanPham = b.TenSanPham,
                          SoLuong = (int)b.SoLuong,
                          DonGia = (double)b.DonGia,
                          DonGiaNhap = (double)b.DonGiaNhap,
                          MoTa = b.MoTa,
                          MoTaChiTiet = b.MoTaChiTiet,
                          KhuyenMai = b.KhuyenMai,
                          GiamGia = (double)b.GiamGia,
                          NgayCapNhat = (DateTime)b.NgayCapNhat,
                          XuatXu = b.XuatXu,
                          HinhMinhHoa =  base_url+"Upload/" + b.HinhMinhHoa,
                          DsHinh = b.DsHinh,
                          TinhTrang = (bool)b.TinhTrang,
                          GhiChu = c.GhiChu
                      }).Skip((page - 1) * limit).Take(limit).OrderByDescending(m=>m.GiamGia).ToList();
            listModel = sp;
            int totalRecord = db.SanPham.Count();
            var pagination = new Pagination
            {
                count = totalRecord,
                currentPage = page,
                pagsize = limit,
                totalPage = (int)Math.Ceiling(decimal.Divide(totalRecord, limit)),
                indexOne = ((page - 1) * limit + 1),
                indexTwo = (((page - 1) * limit + limit) <= totalRecord ? ((page - 1) * limit * limit) : totalRecord)
            };
            //listModel.pagination = pagination;
            return listModel;
        }

        [HttpGet("getSanPhamPaginationList")]
        public async Task<IActionResult> GET(int page, int limit)
        {
            var rs = getSanPhamPaginationList(page, limit);
            if (rs == null)
            {
                return NotFound();
            }
            return new ObjectResult(rs);
        }
        // load sản phẩm theo mã sản phẩm
        [HttpGet("{maSanPham}")]
        public async Task<IActionResult> Get(int maSanPham)
        {
            var SanPham = (from c in db.DanhMuc
                           join b in db.SanPham on c.MaDanhMuc equals b.MaDanhMuc
                           select new NewSanPham
                           {
                               MaSanPham = b.MaSanPham,
                               TenSanPham = b.TenSanPham,
                               SoLuong = (int)b.SoLuong,
                               DonGia = (double)b.DonGia,
                               DonGiaNhap = (double)b.DonGiaNhap,
                               MoTa = b.MoTa,
                               MoTaChiTiet = b.MoTaChiTiet,
                               KhuyenMai = b.KhuyenMai,
                               GiamGia = (double)b.GiamGia,
                               NgayCapNhat = (DateTime)b.NgayCapNhat,
                               XuatXu = b.XuatXu,
                               HinhMinhHoa = base_url + "Upload/" + b.HinhMinhHoa,
                               DsHinh = b.DsHinh,
                               TinhTrang = (bool)b.TinhTrang,
                               GhiChu = c.GhiChu
                           }).Where(m => m.MaSanPham == maSanPham).FirstOrDefault();
            if (SanPham == null)
            {
                return NotFound();
            }
            return new ObjectResult(SanPham);
        }

        // load sản phẩm theo ghichu
        [HttpGet("ghiChu/{ghiChu}")]
        public async Task<IActionResult> Get(string ghiChu)
        {
            var sp = (from c in db.DanhMuc
                      join b in db.SanPham on c.MaDanhMuc equals b.MaDanhMuc
                      where c.GhiChu == ghiChu
                      select new NewSanPham
                      {
                          MaSanPham = b.MaSanPham,
                          TenSanPham = b.TenSanPham,
                          SoLuong = (int)b.SoLuong,
                          DonGia = (double)b.DonGia,
                          DonGiaNhap = (double)b.DonGiaNhap,
                          MoTa = b.MoTa,
                          MoTaChiTiet = b.MoTaChiTiet,
                          KhuyenMai = b.KhuyenMai,
                          GiamGia = (double)b.GiamGia,
                          NgayCapNhat = (DateTime)b.NgayCapNhat,
                          XuatXu = b.XuatXu,
                          HinhMinhHoa = base_url + "Upload/" + b.HinhMinhHoa,
                          DsHinh = b.DsHinh,
                          TinhTrang = (bool)b.TinhTrang,
                          GhiChu = c.GhiChu
                      }).ToList();
            if (sp.Count == 0)
            {
                return NotFound();
            }
            return new ObjectResult(sp);
        }
        [HttpGet("Apple")]
        public async Task<IActionResult> Get(string Iphone = "Iphone", string Macbook = "Macbook")
        {
            var sp = (from c in db.DanhMuc
                      join b in db.SanPham on c.MaDanhMuc equals b.MaDanhMuc
                      where c.TenDanhMuc == "Iphone" || c.TenDanhMuc == "Macbook"
                      select new NewSanPham
                      {
                          MaSanPham = b.MaSanPham,
                          TenSanPham = b.TenSanPham,
                          SoLuong = (int)b.SoLuong,
                          DonGia = (double)b.DonGia,
                          DonGiaNhap = (double)b.DonGiaNhap,
                          MoTa = b.MoTa,
                          MoTaChiTiet = b.MoTaChiTiet,
                          KhuyenMai = b.KhuyenMai,
                          GiamGia = (double)b.GiamGia,
                          NgayCapNhat = (DateTime)b.NgayCapNhat,
                          XuatXu = b.XuatXu,
                          HinhMinhHoa = base_url + "Upload/" + b.HinhMinhHoa,
                          DsHinh = b.DsHinh,
                          TinhTrang = (bool)b.TinhTrang,
                          GhiChu = c.GhiChu
                      }).ToList();
            if (sp.Count == 0)
            {
                return NotFound();
            }
            return new ObjectResult(sp);
        }

        // load sản phẩm theo danh mục
        [HttpGet("DanhMuc/{maDanhMuc}")]
        public async Task<IActionResult> Get(int? maDanhMuc)
        {
            var sp = (from c in db.DanhMuc
                      join b in db.SanPham on c.MaDanhMuc equals b.MaDanhMuc
                      where c.MaDanhMuc == maDanhMuc
                      select new NewSanPham
                      {
                          MaSanPham = b.MaSanPham,
                          TenSanPham = b.TenSanPham,
                          SoLuong = (int)b.SoLuong,
                          DonGia = (double)b.DonGia,
                          DonGiaNhap = (double)b.DonGiaNhap,
                          MoTa = b.MoTa,
                          MoTaChiTiet = b.MoTaChiTiet,
                          KhuyenMai = b.KhuyenMai,
                          GiamGia = (double)b.GiamGia,
                          NgayCapNhat = (DateTime)b.NgayCapNhat,
                          XuatXu = b.XuatXu,
                          HinhMinhHoa = base_url + "Upload/" + b.HinhMinhHoa,
                          DsHinh = b.DsHinh,
                          TinhTrang = (bool)b.TinhTrang,
                          GhiChu = c.GhiChu
                      }).ToList();
            if (sp.Count == 0)
            {
                return NotFound();
            }
            return new ObjectResult(sp);
        }

        // đếm số lượng sản phẩm
        [HttpGet("SoLuong/{ghiChu}")]
        public int countProducts(string ghiChu)
        {
            var sp = (from c in db.DanhMuc
                      join b in db.SanPham on c.MaDanhMuc equals b.MaDanhMuc
                      where c.GhiChu == ghiChu
                      select new NewSanPham
                      {
                          MaSanPham = b.MaSanPham,
                          TenSanPham = b.TenSanPham,
                          SoLuong = (int)b.SoLuong,
                          DonGia = (double)b.DonGia,
                          DonGiaNhap = (double)b.DonGiaNhap,
                          MoTa = b.MoTa,
                          MoTaChiTiet = b.MoTaChiTiet,
                          KhuyenMai = b.KhuyenMai,
                          GiamGia = (double)b.GiamGia,
                          NgayCapNhat = (DateTime)b.NgayCapNhat,
                          XuatXu = b.XuatXu,
                          HinhMinhHoa = base_url + "Upload/" + b.HinhMinhHoa,
                          DsHinh = b.DsHinh,
                          TinhTrang = (bool)b.TinhTrang,
                          GhiChu = c.GhiChu
                      }).Count();
            if (sp == 0)
            {
                return 0;
            }
            return sp;
        }
    }

}
