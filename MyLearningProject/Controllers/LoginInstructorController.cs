using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MyLearningProject.DAL.Context;
using MyLearningProject.DAL.Entities;
namespace MyLearningProject.Controllers
{
    public class LoginInstructorController : Controller
    {
        // GET: LoginInstructor
        ELearningContext context = new ELearningContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Instructor ınstructor)
        {
            var values = context.Instructors.FirstOrDefault(x => x.Email == ınstructor.Email && x.Password == ınstructor.Password);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.Email, false);
                Session["CurrentMail"] = values.Email;

                Session.Timeout = 60;
                //return RedirectToAction("Index", "Web", new { studentid = values.InstructorID });
                return RedirectToAction("Index", "InstructorAnalysis", new { id = values.InstructorID });
            }
            return View();
        }
    }
}