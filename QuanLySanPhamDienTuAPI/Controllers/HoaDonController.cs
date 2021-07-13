using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [HttpGet("{maKhachHang}/{ghiChu}")]
        public async Task<IActionResult> Get(int maKhachHang, string ghiChu)
        {
            var hoaDon = db.HoaDon.Where(m => m.MaKhachHangNavigation.MaKhachHang == maKhachHang && m.GhiChu==ghiChu && m.TinhTrang== true).OrderByDescending(m=>m.NgayBan).ToList();
            if (hoaDon.Count == 0)
            {
                return NotFound();
            }
            return new ObjectResult(hoaDon);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] HoaDon hoaDon)
        {
            try
            {
                if (hoaDon == null)
                {
                    return BadRequest();
                }
                else
                {
                    hoaDon.NgayBan = DateTime.Now.Date;
                    hoaDon.NgayGiao = DateTime.Now.Date.AddDays(4);
                    db.HoaDon.Add(hoaDon);
                    db.SaveChanges();
                    return new ObjectResult(hoaDon); // status 200 => 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("" + ex);
                return BadRequest();
            }
        }

        [HttpPut("{maHoaDon}")]
        public async Task<IActionResult> Put(int maHoaDon, [FromBody] HoaDon hoaDon)
        {
            try
            {
                if (hoaDon == null)
                {
                    return BadRequest();
                }
                else
                {
                    var hd = await db.HoaDon.SingleOrDefaultAsync(m => m.MaHoaDon == maHoaDon);
                    if (hd == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        hd.GhiChu = hoaDon.GhiChu;
                        await db.SaveChangesAsync();
                        return new ObjectResult(hd); // status 200 => OK
                    }
                }
            }
            catch
            {
                return BadRequest(); // status code 400
            }
        }
    }
}
