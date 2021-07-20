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
    public class SanPhamSortController : ControllerBase
    {
        QL_SanPhamContext db = new QL_SanPhamContext();
        //public List<NewSanPham> getSanPhamTheoDonGiaGiam(int page = 1, int limit = 10)
        //{
        //    var listModel = new List<NewSanPham>();
        //    var sp = (from c in db.DanhMuc
        //              join b in db.SanPham on c.MaDanhMuc equals b.MaDanhMuc
        //              orderby b.DonGia descending
        //              select new NewSanPham
        //              {
        //                  MaSanPham = b.MaSanPham,
        //                  TenSanPham = b.TenSanPham,
        //                  SoLuong = (int)b.SoLuong,
        //                  DonGia = (double)b.DonGia,
        //                  DonGiaNhap = (double)b.DonGiaNhap,
        //                  MoTa = b.MoTa,
        //                  MoTaChiTiet = b.MoTaChiTiet,
        //                  KhuyenMai = b.KhuyenMai,
        //                  GiamGia = (double)b.GiamGia,
        //                  NgayCapNhat = (DateTime)b.NgayCapNhat,
        //                  XuatXu = b.XuatXu,
        //                  HinhMinhHoa = SanPhamController.base_url + "Upload/" + b.HinhMinhHoa,
        //                  DsHinh = b.DsHinh,
        //                  TinhTrang = (bool)b.TinhTrang,
        //                  GhiChu = c.GhiChu
        //              }).Skip((page - 1) * limit).Take(limit).ToList();
        //    listModel = sp;
        //    int totalRecord = db.Banner.Count();
        //    var pagination = new Pagination
        //    {
        //        count = totalRecord,
        //        currentPage = page,
        //        pagsize = limit,
        //        totalPage = (int)Math.Ceiling(decimal.Divide(totalRecord, limit)),
        //        indexOne = ((page - 1) * limit + 1),
        //        indexTwo = (((page - 1) * limit + limit) <= totalRecord ? ((page - 1) * limit * limit) : totalRecord)
        //    };
        //    //listModel.pagination = pagination;
        //    return listModel;
        //}
        

        [HttpGet("getSanPhamTheoDonGia")]
        public async Task<IActionResult> GET(int page, int limit, int donGia)
        {
             var rs = getSanPhamTheoDonGia(page, limit,donGia);
            if (rs == null)
            {
                return NotFound();
            }
            return new ObjectResult(rs);
        }

        public List<NewSanPham> getSanPhamTheoDonGia(int page = 1, int limit = 10, int donGia =1, string input= null)
        {
            var listModel = new List<NewSanPham>();
            var sp = new List<NewSanPham>();
            if (donGia == 1)
            {
                sp = (from c in db.DanhMuc
                          join b in db.SanPham on c.MaDanhMuc equals b.MaDanhMuc
                          orderby b.DonGia descending
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
                              HinhMinhHoa = SanPhamController.base_url + "Upload/" + b.HinhMinhHoa,
                              DsHinh = b.DsHinh,
                              TinhTrang = (bool)b.TinhTrang,
                              GhiChu = c.GhiChu,
                              TenDanhMuc = c.TenDanhMuc
                          }).Skip((page - 1) * limit).Take(limit).ToList();
            }
            if(donGia==0)
            {
                sp = (from c in db.DanhMuc
                          join b in db.SanPham on c.MaDanhMuc equals b.MaDanhMuc
                          orderby b.DonGia ascending
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
                              HinhMinhHoa = SanPhamController.base_url + "Upload/" + b.HinhMinhHoa,
                              DsHinh = b.DsHinh,
                              TinhTrang = (bool)b.TinhTrang,
                              GhiChu = c.GhiChu,
                              TenDanhMuc = c.TenDanhMuc
                          }).Skip((page - 1) * limit).Take(limit).ToList();
            }
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

    }
}
