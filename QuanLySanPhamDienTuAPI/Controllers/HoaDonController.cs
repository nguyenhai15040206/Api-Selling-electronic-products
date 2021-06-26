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
    public class HoaDonController : ControllerBase
    {
        QL_SanPhamContext db = new QL_SanPhamContext();
        [HttpGet("{maKhachHang}")]
        public async Task<IActionResult> Get(int maKhachHang)
        {
            var hoaDon = db.HoaDon.Where(m => m.MaKhachHangNavigation.MaKhachHang == maKhachHang).ToList();
            if (hoaDon.Count == 0)
            {
                return NotFound();
            }
            return new ObjectResult(hoaDon);
        }
    }
}
