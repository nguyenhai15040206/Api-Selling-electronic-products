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
    public class SanPhamFillterController : ControllerBase
    {
        QL_SanPhamContext db = new QL_SanPhamContext();
        [HttpGet("getSanPhamFillter")]
        public async Task<IActionResult> GET(int page, int limit, string input)
        {
            var rs = TimKiemSanPham(page, limit, input);
            if (rs == null)
            {
                return NotFound();
            }
            return new ObjectResult(rs);
        }

        public List<NewSanPham> TimKiemSanPham(int page = 1, int limit = 10, string input = null)
        {
            var listModel = new List<NewSanPham>();
            var sp = new List<NewSanPham>();
            sp = (from c in db.DanhMuc
                  join b in db.SanPham on c.MaDanhMuc equals b.MaDanhMuc
                  where c.TenDanhMuc.Contains(input) || b.TenSanPham.Contains(input) || c.GhiChu == input
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
                      GhiChu = c.GhiChu
                  }).Skip((page - 1) * limit).Take(limit).ToList();

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
