using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyLearningProject.DAL.Context;
namespace MyLearningProject.Controllers
{
	public class ProfileController : Controller
	{
		ELearningContext context = new ELearningContext();
		public ActionResult Index()
		{
			string values = Session["CurrentMail"].ToString();
			ViewBag.mail = Session["CurrentMail"];
			//string password = Session["Password"].ToString();
			//         ViewBag.password = Session["Password"];
			ViewBag.pass = context.Students.Where(x => x.Email == values).Select(y => y.Password).FirstOrDefault();
			ViewBag.ımg = context.Students.Where(x => x.Email == values).Select(y => y.Img).FirstOrDefault();
            ViewBag.name = context.Students.Where(x => x.Email == values).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
			return View();
		}

		public ActionResult MyCourseList()
		{
			string values = Session["CurrentMail"].ToString();
			int id = context.Students.Where(x => x.Email == values).Select(y => y.StudentID).FirstOrDefault();
			var courseList = context.Processes.Where(x => x.StudentID == id).ToList();
			return View(courseList);
		}

	}

}