using SeliseExamApp.Core.DTO;
using SeliseExamApp.Core.Repository;
using SeliseExamApp.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var course = new CourseItem() { Id=1, Name = "Bangla 1", Code = "1001", IsDelete = false };
            CourseService courseCreateService = new CourseService();
            //courseCreateService.Create(course);

            var courseITem = courseCreateService.Find(4);

            var courses = courseCreateService.GetAll();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}