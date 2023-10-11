using MyLearningProject.DAL.Context;
using MyLearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyLearningProject.Controllers
{
    public class ContactAdminController : Controller
    {
        // GET: ContactAdmin
        ELearningContext context = new ELearningContext();
        public ActionResult Index()
        {
            ViewBag.SayfaBasligi = "İletişim";
            var values = context.contactAdmins.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddContactAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddContactAdmin(ContactAdmin contactAdmin)
        {
            context.contactAdmins.Add(contactAdmin);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteContactAdmin(int id)
        {
            var value = context.contactAdmins.Find(id);
            context.contactAdmins.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult UpdateContactAdmin(int id)
        {
            var value = context.contactAdmins.Find(id);
            return View(value);

        }
    
        [HttpPost]
        public ActionResult UpdateContactAdmin(ContactAdmin contactAdmin)
        {
            var value = context.contactAdmins.Find(contactAdmin.ContactID);
            value.ContactTitle = contactAdmin.ContactTitle;
            value.ContactDescription = contactAdmin.ContactDescription;
            value.ContactAdress = contactAdmin.ContactAdress;
            value.ContactPhone = contactAdmin.ContactPhone;
            value.ContactMail = contactAdmin.ContactMail;
            value.ContactTwitter = contactAdmin.ContactTwitter;
            value.ContactFacebook = contactAdmin.ContactFacebook;
            value.ContactYoutube = contactAdmin.ContactYoutube;
            value.ContactLinkedin = contactAdmin.ContactLinkedin;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}