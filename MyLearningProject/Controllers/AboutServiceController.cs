using MyLearningProject.DAL.Context;
using MyLearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyLearningProject.Controllers
{
    public class AboutServiceController : Controller
    {

        ELearningContext context = new ELearningContext();

        public ActionResult Index()
        {
            ViewBag.SayfaBasligi = "Hakkında-Servisleri";
               var values = context.Services.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddService()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddService(Service service)
        {
            context.Services.Add(service);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteService(int id)
        {
            var value = context.Services.Find(id);
            context.Services.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var value = context.Services.Find(id);
            return View(value);

        }
        [HttpPost]
        public ActionResult UpdateService(Service service)
        {
            var value = context.Services.Find(service.ServiceID);
            value.ServiceTitle = service.ServiceTitle;
            value.ServiceDescription= service.ServiceDescription;

          
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}