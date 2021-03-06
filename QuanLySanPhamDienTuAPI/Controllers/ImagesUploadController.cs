using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using QuanLySanPhamDienTuAPI.Models;
using System.Net;
using Microsoft.AspNetCore.Hosting.Server;

namespace QuanLySanPhamDienTuAPI.Controllers
{
    [Route("Home/Introduct/[controller]")]
    [ApiController]
    public class ImagesUploadController : ControllerBase
    {
        public readonly IWebHostEnvironment _environment;

        public ImagesUploadController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var images = "Xin chào!";

            return new ObjectResult(images);
        }



        [HttpPost]
        public async Task<IActionResult> Post([FromForm] IFormFile file)
        {
            var path = $"{this._environment.WebRootPath}\\Upload";
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
