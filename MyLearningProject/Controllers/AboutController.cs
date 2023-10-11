using MyLearningProject.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyLearningProject.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        ELearningContext context = new ELearningContext();

        public ActionResult Index()
        {
           
            return View();
        }
        public PartialViewResult PartialServices()
        {
            var values = context.Services.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialAbout()
        {
            var values = context.Abouts.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialTestimonial()
        {
            var values = context.Instructors.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        //public PartialViewResult PartialFooter()
        //{
        //    return PartialView();
        //}
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
    }
}