using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLySanPhamDienTuAPI.Controllers
{
    [Route("Home/Introduct/[controller]")]
    [ApiController]
    public class UploadBannerController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public UploadBannerController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public async Task<IActionResult> Upload([FromForm] IFormFile file)
        {
            var path = $"{this._webHostEnvironment.WebRootPath}\\Banner";
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
