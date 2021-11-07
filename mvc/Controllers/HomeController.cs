using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc.Buss;
using mvc.DAO;
using mvc.Models;

namespace mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public JsonResult GetProduct()
        {
            SanPhamBUS pb = new SanPhamBUS();
            List<Sanpham> lp = pb.GetSanPhams();
            @ViewBag.SoSanPham = lp.Count;
            return Json(new { sp = lp }, JsonRequestBehavior.AllowGet);
        }

        SanPhamBUS sb = new SanPhamBUS();
        CategoryBUS cab = new CategoryBUS();
        [HttpGet]
        public JsonResult GetSanPham(string maloai)
        {
            List<Sanpham> lsp = sb.LaySPTheoLoai(maloai);
            return Json(lsp, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCategory()
        {          
            List<LoaiSP> l = cab.GetCategory();
            return Json(l, JsonRequestBehavior.AllowGet);
        }
       
        //public PartialViewResult GetMenu()
        //{
        //    var language = 0;
        //    if (language == 1)
        //        return PartialView("_Menu");
        //    else
        //        return PartialView("_MenuView");
        //}

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}