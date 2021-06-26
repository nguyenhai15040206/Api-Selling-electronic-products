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
    public class CTHoaDonController : ControllerBase
    {
        QL_SanPhamContext db = new QL_SanPhamContext();

        [HttpGet("{maKhachHang}")]
        public async Task<IActionResult> Get(int maKhachHang)
        {
            var ctHoaDon = db.CthoaDon.Where(m => m.MaHoaDonNavigation.MaKhachHang == maKhachHang).ToList();
            if (ctHoaDon.Count == 0)
            {
                NotFound();
            }
            return new ObjectResult(ctHoaDon);
        }
    }
}
