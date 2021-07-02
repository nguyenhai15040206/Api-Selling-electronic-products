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
        ConverImageToBase64 convertbase64 = new ConverImageToBase64();
        // load tất cả Banner
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var banner = (from bn in db.Banner
                          select new Banner
                          {
                              MaBanner= bn.MaBanner,
                              FileBanner= SanPhamController.base_url+ "Banner/"+ bn.FileBanner,
                              KichHoat =  bn.KichHoat,
                              GhiChu = bn.GhiChu
                              
                          }).ToList();
            if (banner == null)
            {
                return NotFound();
            }
            return new ObjectResult(banner);
        }


    }
}
