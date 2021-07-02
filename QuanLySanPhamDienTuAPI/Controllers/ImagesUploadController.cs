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
        public static IWebHostEnvironment _environment;

        public ImagesUploadController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        QL_SanPhamContext db = new QL_SanPhamContext();
        public class FileUploadAPI
        {
            public IFormFile files { get; set; }
        }

        
        [HttpGet]
        public async Task<IActionResult> Get( )
        {
            var images = "Xin chào!";

            return new ObjectResult(images);
        }

        [HttpPost]
        public async Task<String> Post([FromForm]FileUploadAPI objFile)
        {
            try
            {
                if (objFile.files.Length > 0)
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\Upload\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\Upload\\");
                    }
                    using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\Upload\\" + objFile.files.FileName))
                    {
                        objFile.files.CopyTo(fileStream);
                        fileStream.Flush();
                        return "\\Upload\\" + objFile.files.FileName;
                    }
                }
                else
                {
                    return "failed";
                }
            }
            catch (Exception ex)
            {

                return ex.Message.ToString();
            }
        }

        [HttpPost("Images/Banner/{ghichu}")]
        public async Task<String> Post([FromForm] FileUploadAPI objFile,string ghichu =null)
        {
            try
            {
                if (objFile.files.Length > 0)
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\Banner\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\Banner\\");
                    }
                    using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\Banner\\" + objFile.files.FileName))
                    {
                        objFile.files.CopyTo(fileStream);
                        fileStream.Flush();
                        return "\\Banner\\" + objFile.files.FileName;
                    }
                }
                else
                {
                    return "failed";
                }
            }
            catch (Exception ex)
            {

                return ex.Message.ToString();
            }
        }
    }
}
