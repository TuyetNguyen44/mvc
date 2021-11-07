using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc.Models;

namespace mvc.Controllers
{
    public class SinhVienController : Controller
    {
        // GET: sinhvien
        //public ActionResult Index()
        //{
        //    return View();
        //}
        //public JsonResult GetJsonNew()
        //{
        //    var gv = new { ma = "M01", hoten = "Nguyen Thi Tuyet" };
        //    return Json(gv, JsonRequestBehavior.AllowGet);
        //}
        //public JavaScriptResult WarningMessage()
        //{
        //    var ms = "alert('co lay san pham')";
        //    return new JavaScriptResult() { Script = ms };

        //}
        //public RedirectToRouteResult Index()
        //{
        //    return RedirectToRoute(new { controller = "Home", action = "About" });

        //}
        public ActionResult Index()
        {
            List<Student> ls = new List<Student>();
            var student1 = new Student(1, "Nguyễn Văn A", 19);
            var student2 = new Student(2, "Nguyễn Văn B", 19);
            var student3 = new Student(3, "Nguyễn Văn C", 19);
            var student4 = new Student(4, "Nguyễn Văn D", 19);
            ls.Add(student1);
            ls.Add(student2);
            ls.Add(student3);
            ls.Add(student4);
            return View(ls);
        }

    }
}

