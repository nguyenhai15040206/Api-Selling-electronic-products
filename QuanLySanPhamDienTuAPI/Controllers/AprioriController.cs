using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLySanPhamDienTuAPI.AI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using QuanLySanPhamDienTuAPI.Models;
using System.Text;
using System.Net;

namespace QuanLySanPhamDienTuAPI.Controllers
{
    [Route("Home/Introduct/[controller]")]
    [ApiController]
    public class AprioriController : ControllerBase
    {
        private ItemSetCollection db;
        private ItemSetCollection L;
        private List<AssociationRule> listQuyTat;
        //double minSupp = 40.0;
        //double minConf = 70.0;
        double minSupp = 30.0;
        double minConf = 70.0;
        QL_SanPhamContext database = new QL_SanPhamContext();

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<string> dsGiaoDich = new List<string>();
            WebClient client = new WebClient();
            Stream stream = client.OpenRead("http://192.168.1.3:5000/DataKhaiPhaDuLieu/DataKhaiPhaDuLieu.txt");
            StreamReader sr = new StreamReader(stream);
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                dsGiaoDich.Add(line);
            }
            AddItemColection(dsGiaoDich);
            ItemSet item = db.GetUniqueItem();
            L = AprioriAlgorithm.DoApriori(db, minSupp);
            listQuyTat = AprioriAlgorithm.ResultDoApriori(db, L, minConf);
            //StreamWriter sw = new StreamWriter("Output.txt", true);
            //for (int i = 0; i < listQuyTat.Count; i++)
            //{
            //    sw.WriteLine( listQuyTat[i].X.toString() + " - " + listQuyTat[i].Y.toString() + " - " + listQuyTat[i].Support + " - " + listQuyTat[i].Confidence);
            //}
            //sw.Close();

            return new ObjectResult(listQuyTat);
        }

        [HttpGet("{tenSanPham}")]
        public async Task<IActionResult> GET(string tenSanPham)
        {
            listQuyTat = new List<AssociationRule>();
            WebClient client = new WebClient();
            Stream stream = client.OpenRead("http://192.168.1.3:5000/DataKhaiPhaDuLieu/Output.txt");
            StreamReader sr = new StreamReader(stream);
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                AssociationRule rule = new AssociationRule();
                string[] arr = line.Split('-');
                rule.X = new ItemSet { arr[0]};
                rule.Y = new ItemSet { arr[1] };
                rule.Support = double.Parse(arr[2].ToString().Trim()) ;
                rule.Confidence = double.Parse(arr[3].ToString().Trim());
                listQuyTat.Add(rule);
            }
            List<AssociationRule> listkq = new List<AssociationRule>();
            for (int i = 0; i < listQuyTat.Count; i++)
            {
                if (tenSanPham.Equals(listQuyTat[i].X.toString().Trim()))
                {
                    listkq.Add(listQuyTat[i]);
                }
            }
            if (listkq.Count == 0)
            {
                return BadRequest();
            }
            List<string> listString = listkq.AsEnumerable().OrderByDescending(m => m.Support).Select(m => m.Y.toString().Trim()).ToList();
            List<NewSanPham> dsSanPhamGoiY = getSP(listString);
            if (dsSanPhamGoiY.Count == 0)
            {
                return BadRequest();
            }
            return new ObjectResult(dsSanPhamGoiY);
        }

        public List<NewSanPham> getSP(List<string> liststring)
        {
            List<NewSanPham> stmp = new List<NewSanPham>();
            for (int k = 0; k < liststring.Count; k++)
            {
                List<NewSanPham> list = (from c in database.DanhMuc
                                         join b in database.SanPham on c.MaDanhMuc equals b.MaDanhMuc
                                         where c.TenDanhMuc.Contains(liststring[k].ToString()) || b.TenSanPham.Contains(liststring[k].ToString()) || c.GhiChu.Contains(liststring[k].ToString())
                                         select new NewSanPham
                                         {
                                             MaSanPham = b.MaSanPham,
                                             TenSanPham = b.TenSanPham,
                                             SoLuong = (int)b.SoLuong,
                                             DonGia = (double)b.DonGia,
                                             DonGiaNhap = (double)b.DonGiaNhap,
                                             MoTa = b.MoTa,
                                             MoTaChiTiet = b.MoTaChiTiet,
                                             KhuyenMai = b.KhuyenMai,
                                             GiamGia = (double)b.GiamGia,
                                             NgayCapNhat = (DateTime)b.NgayCapNhat,
                                             XuatXu = b.XuatXu,
                                             HinhMinhHoa = SanPhamController.base_url + "Upload/" + b.HinhMinhHoa,
                                             DsHinh = b.DsHinh,
                                             TinhTrang = (bool)b.TinhTrang,
                                             GhiChu = c.GhiChu,
                                             TenDanhMuc = c.TenDanhMuc
                                         }).Take(1).ToList();
                for (int i = 0; i < list.Count; i++)
                {
                    stmp.Add(list[i]);
                }
            }
            return stmp.Take(3).ToList();
        }

        public void AddItemColection(List<string> listItem)
        {
            db = new ItemSetCollection();
            for (int i = 0; i < listItem.Count; i++)
            {
                ItemSet giaoDich = new ItemSet();
                string[] record = listItem[i].Split(',');
                for (int j = 0; j < record.Count(); j++)
                {
                    giaoDich.Add(record[j].Trim());
                }
                db.Add(giaoDich);
            }
        }


    }
}
