using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLySanPhamDienTuAPI.Controllers
{
    [Route("{controller}/{action}")]
    [Controller]
    public class HomeController : Controller
    {
        public ActionResult Introduct()
        {
            return View();
        }
    }
}
