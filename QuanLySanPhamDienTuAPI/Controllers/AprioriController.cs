using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLySanPhamDienTuAPI.AI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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
        double minSupp = 40.0;
        double minConf = 70.0;
        int dong = 0;

        [HttpGet("{tenSanPham}")]
        public async Task<IActionResult> Get(String tenSanPham)
        {
            List<AssociationRule> listkq = new List<AssociationRule>();
            List<string> dsGiaoDich = new List<string>();
            StreamReader sr = new StreamReader("C:\\Users\\Admin\\Desktop\\DoAnMonHoc\\ApiQLSanPhamDienTu\\QuanLySanPhamDienTuAPI\\QuanLySanPhamDienTuAPI\\wwwroot\\DataKhaiPhaDuLieu\\DataKhaiPhaDuLieu.txt");
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                dsGiaoDich.Add(line);
            }
            AddItemColection(dsGiaoDich);
            ItemSet item = db.GetUniqueItem();
            L = AprioriAlgorithm.DoApriori(db, minSupp);
            listQuyTat = AprioriAlgorithm.ResultDoApriori(db, L, minConf);
            for(int i=0; i< listQuyTat.Count; i++)
            {
                if(tenSanPham == listQuyTat[i].X.toString())
                {
                    listkq.Add(listQuyTat[i]);
                }    
            }    
            return new ObjectResult(listkq);
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
