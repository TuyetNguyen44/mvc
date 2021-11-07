using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc.Buss;
using mvc.Models;
using mvc.DAO;
namespace mvc.Controllers
{
    public class SanPhamController : Controller
    {
        SanPhamBUS pb = new SanPhamBUS();
        // GET: SanPham
        public ActionResult Index()
        {
            
           // List<Sanpham> lp = pb.GetSanPhams();
            return View();
        }
        public ActionResult Product()
        {
            return View();
        }
        [Route("/GetSanPham")]
        public JsonResult GetSanPham(string maloai)
        {
            List<Sanpham> lsp = pb.LaySPTheoLoai(maloai);
            return Json(lsp, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetSanPhamTheoLoai(string maloai)
        {
            List<Sanpham> lsp = pb.GetProductCategory(maloai);
            return Json(lsp, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetProduct()
        {
            List<Sanpham> lp = pb.GetSanPhams();
            @ViewBag.SoSanPham = lp.Count;
            return Json(new { sp = lp }, JsonRequestBehavior.AllowGet);
        }
        //public JsonResult GetSanPhamTL(string maloai, int pageIndex, int pageSize, string productName)
        //{
        //    SanPhamList spl = pb.GetSanPham(maloai, pageIndex, pageSize, productName);

        //    return Json(spl, JsonRequestBehavior.AllowGet);
        //}

    }
}