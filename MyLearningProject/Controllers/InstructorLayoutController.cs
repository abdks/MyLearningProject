using MyLearningProject.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyLearningProject.Controllers
{
    public class InstructorLayoutController : Controller
    {
        // GET: InstructorLayout
        ELearningContext context = new ELearningContext();

        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialSidebar()
        {

            return PartialView();
        }
    }
}