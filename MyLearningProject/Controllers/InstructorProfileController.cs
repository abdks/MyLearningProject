using MyLearningProject.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyLearningProject.Controllers
{
    public class InstructorProfileController : Controller
    {
        // GET: InstructorProfile
        ELearningContext context = new ELearningContext();

        public ActionResult Index()
        {
            string values = Session["CurrentMail"].ToString();
            ViewBag.mail = Session["CurrentMail"];
            //string password = Session["Password"].ToString();
            //         ViewBag.password = Session["Password"];
            ViewBag.pass = context.Instructors.Where(x => x.Email == values).Select(y => y.Password).FirstOrDefault();
            ViewBag.ımg = context.Instructors.Where(x => x.Email == values).Select(y => y.ProfileImage).FirstOrDefault();
            ViewBag.name = context.Instructors.Where(x => x.Email == values).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            return View();
        }
        public ActionResult MyCourseList()
        {
            string values = Session["CurrentMail"].ToString();
            int id = context.Instructors.Where(x => x.Email == values).Select(y => y.InstructorID).FirstOrDefault();
            var courseList = context.Courses.Where(x => x.InstructorID == id).ToList();
            return View(courseList);
        }
    }
}