using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyLearningProject.DAL.Context;
using MyLearningProject.DAL.Entities;
namespace MyLearningProject.Controllers
{
    public class SliderAdminController : Controller
    {
        ELearningContext context = new ELearningContext();


        public ActionResult Index()
        {
            ViewBag.SayfaBasligi = "Slider";
            var values = context.Sliders.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddSlider()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSlider(Slider slider)
        {
            context.Sliders.Add(slider);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSlider(int id)
        {
            var value = context.Sliders.Find(id);
            context.Sliders.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult UpdateSlider(int id)
        {
            var value = context.Sliders.Find(id);
            return View(value);

        }

        [HttpPost]
        public ActionResult UpdateSlider(Slider slider)
        {
            var value = context.Sliders.Find(slider.SliderID);
            value.SliderTitle1 = slider.SliderTitle1;
            value.SliderTitle2 = slider.SliderTitle2;
            value.SliderDescription = slider.SliderDescription;
            value.SliderİmageUrl = slider.SliderİmageUrl;
            
           
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}