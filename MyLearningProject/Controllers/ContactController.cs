using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyLearningProject.DAL.Context;
using MyLearningProject.DAL.Entities;

namespace MyLearningProject.Controllers
   
{
    public class ContactController : Controller
    {
        // GET: Contact
        ELearningContext context = new ELearningContext();

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult PartialHeader()
        {
            return PartialView();
        }
        public PartialViewResult PartialContact()
        {
            var values = context.contactAdmins.ToList();
            return PartialView(values);
        }
        //public PartialViewResult PartialFooter()
        //{
        //    return PartialView();
        //}
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }

       
        [HttpGet]
        public PartialViewResult PartialContactForm()
        {
            TempData["FormSubmitted"] = false; // Başlangıçta formun gönderilmediğini varsayalım
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult PartialContactForm(Message message)
        {
            bool formSubmitted = TempData["FormSubmitted"] as bool? ?? false;

            if (ModelState.IsValid && !formSubmitted)
            {
                context.Messages.Add(message);
                context.SaveChanges();
                TempData["FormSubmitted"] = true; // Formun gönderildiğini işaretleyin
                ModelState.Clear(); // Form verilerini temizle
            }
            return PartialView("PartialContactForm");
        }


    }
}