using QuanLySanPhamDienTuAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySanPhamDienTuAPI
{
    public class ConverImageToBase64
    {
        public String ConvertImageURLToBase64(String img)
        {

            byte[] imgArr =    imgArr = System.IO.File.ReadAllBytes(ImagesUploadController._environment.WebRootPath + "\\Upload\\" + img);
            string base64 = Convert.ToBase64String(imgArr);
            return base64;
        }
    }
}
