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
    public class BannerController : ControllerBase
    {
        QL_SanPhamContext db = new QL_SanPhamContext();

        // load tất cả Banner
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var banner = db.Banner.ToList();
            if (banner == null)
            {
                return NotFound();
            }
            return new ObjectResult(banner);
        }

    }
}
