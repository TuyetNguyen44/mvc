using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc.Models;
using mvc.DAO;
using mvc.Buss;

namespace mvc.Controllers
{
    public class ChiTietSPController : Controller
    {
        // GET: ChiTietSP
        SanPhamBUS spb = new SanPhamBUS();
        public ActionResult Index()
        {
            return View();
        }
        //public JsonResult GetProduct()
        //{
        //    CategoryBUS spb = new CategoryBUS();
        //    List<LoaiSP> sp = spb.GetCategory();
        //    return Json(sp, JsonRequestBehavior.AllowGet);
        //}
        public JsonResult GetProduct(string masp)
        {
             Sanpham p= spb.GetSanPhamCT(masp);
             return Json(p, JsonRequestBehavior.AllowGet);
        }
    }
}