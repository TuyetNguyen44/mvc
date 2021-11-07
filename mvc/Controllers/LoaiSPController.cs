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
    public class LoaiSPController : Controller
    {
        // GET: LoaiSP
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetLoaiSP()
        {
            CategoryBUS bl = new CategoryBUS();
            List<LoaiSP> l = bl.GetLoaiSP();
            return Json(l, JsonRequestBehavior.AllowGet);
        }
    }
}