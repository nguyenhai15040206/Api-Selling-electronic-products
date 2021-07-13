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
    public class CTHoaDonController : ControllerBase
    {
        QL_SanPhamContext db = new QL_SanPhamContext();

        [HttpGet("{maHoaDon}/{ghiChu}")]
        public async Task<IActionResult> Get(int maHoaDon, string ghiChu)
        {
            var ctHoaDon = (from hd in db.HoaDon
                            join cthd in db.CthoaDon on hd.MaHoaDon equals cthd.MaHoaDon
                            join sp in db.SanPham on cthd.MaSanPham equals sp.MaSanPham
                            where hd.GhiChu== ghiChu && hd.MaHoaDon==maHoaDon
                            orderby hd.NgayBan descending
                            select new NewCTHoaDon
                            {
                                MaHoaDon = hd.MaHoaDon,
                                MaSanPham = sp.MaSanPham,
                                TenSanPham = sp.TenSanPham,
                                HinhAnh = SanPhamController.base_url+ "Upload/" + sp.HinhMinhHoa,
                                SoLuong = (int)cthd.SoLuong,
                                DonGia = (double)cthd.DonGia,
                                GiamGia = (double)cthd.GiamGia,
                            }).ToList();
            if (ctHoaDon.Count == 0)
            {
                NotFound();
            }
            return new ObjectResult(ctHoaDon);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CthoaDon ctHoaDon)
        {
            try
            {
                if (ctHoaDon == null)
                {
                    return BadRequest();
                }
                else
                {
                    db.CthoaDon.Add(ctHoaDon);
                    db.SaveChanges();
                    return new ObjectResult(ctHoaDon); // status 200 => 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("" + ex);
                return BadRequest();
            }
        }

        [HttpPut("{maHoaDon}/{maSanPham}")]
        public async Task<IActionResult> Put(int maHoaDon,int maSanPham, [FromBody] CthoaDon ctHoaDon)
        {
            try
            {
                if (ctHoaDon == null || (ctHoaDon.MaHoaDon != maHoaDon || ctHoaDon.MaSanPham !=maSanPham ))
                {
                    return BadRequest();
                }
                else
                {
                    var cthd = await db.CthoaDon.SingleOrDefaultAsync(m => m.MaHoaDon == maHoaDon);
                    if (cthd == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        cthd.GhiChu = ctHoaDon.GhiChu;
                        await db.SaveChangesAsync();
                        return new ObjectResult(cthd); // status 200 => OK
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
