using MyLearningProject.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyLearningProject.DAL.Entities;
using System.Web.Security;

namespace MyLearningProject.Controllers
{
    public class LoginAdminController : Controller
    {
        ELearningContext context = new ELearningContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(DenemeAdmin denemeAdmin)
        {
            var values = context.DenemeAdmins.FirstOrDefault(x => x.Email == denemeAdmin.Email && x.Pass == denemeAdmin.Pass);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.Email, false);
                Session["CurrentMail"] = values.Email;

                Session.Timeout = 60;
                //return RedirectToAction("Index", "Web", new { studentid = values.InstructorID });
                return RedirectToAction("Index", "AboutDesign");
            }
            return View();
        }

    }
}