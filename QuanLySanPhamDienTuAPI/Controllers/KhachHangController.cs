using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLySanPhamDienTuAPI.Data;
using QuanLySanPhamDienTuAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLySanPhamDienTuAPI.Controllers
{
    [Route("Home/Introduct/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        QL_SanPhamContext db = new QL_SanPhamContext();

        [HttpGet]
        public IEnumerable<KhachHang> Get()
        {
            return db.KhachHang.ToList();
        }

        [HttpGet("{maKhachHang}")]
        public KhachHang Get(int maKhachHang)
        {
            var kh = db.KhachHang.Where(m => m.MaKhachHang == maKhachHang).SingleOrDefault();
            if (kh == null)
            {
                return null;
            }
            return kh;
        }

        [HttpGet("getCustomer/{tenDangNhap}")]
        public async  Task<IActionResult> Get(string tenDangNhap)
        {
            var kh = db.KhachHang.Where( m => m.TenDangNhap== tenDangNhap).SingleOrDefault();
            if(kh==null)
            {
                return NotFound();
            }    
            return new ObjectResult(kh);
        }
        [HttpGet("{tenDangNhap}/{matKhau}")]
        public async Task<IActionResult> Get(string tenDangNhap, string matKhau)
        {
            var login = db.KhachHang.Where(m => m.TenDangNhap == tenDangNhap.Trim() && m.MatKhau == HashMD5.MD5Hash(matKhau.Trim())).SingleOrDefault();
            if (login == null)
            {
                return NotFound();
            }
            return new ObjectResult(login);
        }


        // thêm mới một khách hàng
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] KhachHang khachHang)
        {
            try
            {
                if (khachHang == null)
                {
                    return BadRequest();
                }
                else
                {
                    KhachHang kh = new KhachHang();
                    kh.MaKhachHang = 0;
                    kh.TenKhachHang = khachHang.TenKhachHang;
                    kh.SoDienThoai = khachHang.SoDienThoai;
                    kh.Email = khachHang.Email;
                    kh.DiaChi = khachHang.DiaChi;
                    kh.TenDangNhap = khachHang.TenDangNhap;
                    kh.MatKhau = HashMD5.MD5Hash(khachHang.MatKhau);
                    db.KhachHang.Add(kh);
                    db.SaveChanges();
                    return new ObjectResult(kh); // status 200 => 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("" + ex);
                return BadRequest();
            }
        }

        // cập nhật thông tin cảu một khách hàng
        [HttpPut("{maKhachHang}")]
        public async Task<IActionResult> Put(int maKhachHang, [FromBody] KhachHang khachHang)
        {
            try
            {
                if (khachHang == null || khachHang.MaKhachHang != maKhachHang)
                {
                    return BadRequest();
                }
                else
                {
                    var kh = await db.KhachHang.SingleOrDefaultAsync(m => m.MaKhachHang == maKhachHang);
                    if (kh == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        kh.TenKhachHang = khachHang.TenKhachHang;
                        kh.SoDienThoai = khachHang.SoDienThoai;
                        kh.Email = khachHang.Email;
                        kh.DiaChi = khachHang.DiaChi;
                        kh.MatKhau = HashMD5.MD5Hash(khachHang.MatKhau);
                        await db.SaveChangesAsync();
                        return new ObjectResult(kh); // status 200 => OK

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
