using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using mvc.Models;
using System.Web;
using System.Web.Mvc;

namespace mvc.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }
        [HttpPost]
        //public ActionResult Addstudent2(Student s)
        //{
        //    StreamWriter fs = System.IO.File.CreateText(Server.MapPath("~") + "App_Data/StudentInfo.txt");
        //    fs.WriteLine(s.ID + "#" +s.Name);
        //    s.Name = s.Name.ToUpper();
           
        //    fs.Close();
        //    return View("Index",s);


        //}
        //[HttpPost]
        public ActionResult Addstudent(FormCollection f)
        {
            StreamWriter fs =System.IO.File.CreateText(Server.MapPath("~") + "App_Data/StudentInfo.txt");
            fs.WriteLine(f["id"] + "\t" + f["name"]);
            fs.Close();
            return View("Index");
               

        }
       public PartialViewResult Footer()
        {
            return PartialView("_PartialViewExam");
        }
        //public FileResult Index()
        //{
        //    return File("Web.config", "text");
        //}
        public ContentResult GetContent()
        {
            return Content("<h1>Xin chao cac bạn</h1>");
        }
        [HttpGet]
        public JsonResult GetJsonNew()
        {
            var gv = new { ma = "M01", hoten = "Nguyen Thi Tuyet" };
            return Json(gv, JsonRequestBehavior.AllowGet);
        }
        public JavaScriptResult WarningMessage()
        {
            var ms = "alert('co lay san pham')";
            return new JavaScriptResult() { Script = ms };
        }
        //public RedirectToRouteResult Index()
        //{
        //    return RedirectToRoute(new { controller = "Home", action = "About" });

        //}
        public HttpStatusCodeResult ErrorMessage()
        {
            return new HttpStatusCodeResult(HttpStatusCode.Unauthorized, "you are not anthorized to access this controller action");
        }
     

    }

}