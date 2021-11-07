using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using mvc.Models;
namespace mvc.DAO
{
     public class CategoryDAO
    {
        Datahelper dh = new Datahelper();
        public List<LoaiSP> GetCategory()
        {
            DataTable dt = dh.GetDataTable("Select*from LoaiSP");
            return ToList(dt);
        }
        public List<LoaiSP> GetLoaiSP()
        {
            DataTable dt = dh.GetDataTable("Select*from LoaiSP");
            List<LoaiSP> L = new List<LoaiSP>();
            foreach (DataRow r in dt.Rows)
            {
                LoaiSP fd = new LoaiSP(r[0].ToString(), r[1].ToString());
                L.Add(fd);
            }
            return L;
        }
        public List<LoaiSP> ToList(DataTable dt)
        {
            List<LoaiSP> ll = new List<LoaiSP>();
            foreach (DataRow dr in dt.Rows)
            {
                LoaiSP l = new LoaiSP(dr[0].ToString(),
               dr[1].ToString());
                ll.Add(l);

            }
            return ll;
        }
    }
}