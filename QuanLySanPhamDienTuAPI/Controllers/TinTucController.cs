using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuanLySanPhamDienTuAPI.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace QuanLySanPhamDienTuAPI.Controllers
{
    [Route("Home/Introduct/[controller]")]
    [ApiController]
    public class TinTucController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public TinTucController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnvironment = webHostEnvironment;
        }
        QL_SanPhamContext db = new QL_SanPhamContext();

        public List<TinTuc> getTinTucPaginationList(int page = 1, int limit = 10)
        {
            var listModel = new List<TinTuc>();
            var sp = (from tin in db.TinTuc
                      select new TinTuc
                      {
                          MaTinTuc = tin.MaTinTuc,
                          TenTinTuc = tin.TenTinTuc,
                          NoiDung = tin.NoiDung,
                          NgayDang = tin.NgayDang,
                          AnhMinhHoa = SanPhamController.base_url+"TinTuc/"+ tin.AnhMinhHoa,
                          KichHoat = tin.KichHoat,
                          GhiChu = tin.GhiChu,
                          MaLoaiTin = tin.MaLoaiTin
                      }
                        
                      ).Skip((page - 1) * limit).Take(limit).OrderByDescending(m => m.NgayDang).ToList();
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

        [HttpGet("getTinTucPaginationList")]
        public async Task<IActionResult> GET(int page, int limit)
        {
            var rs = getTinTucPaginationList(page, limit);
            if (rs == null)
            {
                return NotFound();
            }
            return new ObjectResult(rs);
        }


        [HttpPost]
        public async Task<IActionResult> Upload([FromForm] IFormFile file)
        {
            var path = $"{this._webHostEnvironment.WebRootPath}\\TinTuc";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            FileInfo fileInfo = new FileInfo(file.FileName);
            var fullPath = Path.Combine(path, fileInfo.Name);
            if (!System.IO.File.Exists(fullPath))
            {
                using (FileStream fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                return new JsonResult(new { FileName = fileInfo.Name });
            }
            return BadRequest();
        }
    }
}
