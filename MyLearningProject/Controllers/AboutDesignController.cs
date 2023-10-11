using MyLearningProject.DAL.Context;
using MyLearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyLearningProject.Controllers
{
    public class AboutDesignController : Controller
    {
        ELearningContext context = new ELearningContext();

        public ActionResult Index()
        {
            ViewBag.SayfaBasligi = "Hakkında";

            var values = context.Abouts.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            context.Abouts.Add(about);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAbout(int id)
        {
            var value = context.Abouts.Find(id);
            context.Abouts.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var value = context.Abouts.Find(id);
            return View(value);

        }
        [HttpPost]
        public ActionResult UpdateAbout(About about)
        {
            var value = context.Abouts.Find(about.AboutID);
            value.AboutTitle = about.AboutTitle;
            value.AboutParagraph = about.AboutParagraph;

            value.AboutService = about.AboutService;
            value.AboutImage = about.AboutImage;
           
            context.SaveChanges();
            return RedirectToAction("Index");
        }




    }
}