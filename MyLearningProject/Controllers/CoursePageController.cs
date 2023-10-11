using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyLearningProject.DAL.Context;
using PagedList;
using PagedList.Mvc;
namespace MyLearningProject.Controllers
{
    public class CoursePageController : Controller
    {
        // GET: CoursePage
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
        public PartialViewResult PartialCategories()
        {
            //var deneme = context.Categories.ToList();
            //var values = context.Courses.ToList();
            //ViewBag.CourseCount = context.Courses.Where(x => x.CategoryID == 1).Count();
            //ViewBag.CourseCount2 = context.Courses.Where(x => x.CategoryID == 2).Count();
            //ViewBag.CourseCount3 = context.Courses.Where(x => x.CategoryID == 3).Count();
            //ViewBag.CourseCount4 = context.Courses.Where(x => x.CategoryID == 4).Count();
            //    return PartialView(deneme);

            //var allCategories = context.Categories.ToList();
            //var activeCategories = allCategories.Where(c => c.CategoryFilter).ToList();

            //var boolCategory1 = allCategories.Where(c => c.CategoryFilter).ToList();
            //var boolCategory2 = allCategories.Where(c => c.CategoryFilter).ToList();
            //var boolCategory3 = allCategories.Where(c => c.CategoryFilter).ToList();
            //var boolCategory4 = allCategories.Where(c => c.CategoryFilter).ToList();

            //ViewBag.ActiveCategories = activeCategories;
            //ViewBag.BoolCategory1 = boolCategory1;
            //ViewBag.BoolCategory2 = boolCategory2;
            //ViewBag.BoolCategory3 = boolCategory3;
            //ViewBag.BoolCategory4 = boolCategory4;

            //return PartialView(allCategories);
            var allCategories = context.Categories.ToList();
            var boolCategory1 = allCategories.Where(c => c.CategoryFilter).Take(1).ToList();
            var boolCategory2 = allCategories.Where(c => c.CategoryFilter).Skip(1).Take(1).ToList();
            var boolCategory3 = allCategories.Where(c => c.CategoryFilter).Skip(2).Take(1).ToList();
            var boolCategory4 = allCategories.Where(c => c.CategoryFilter).Skip(3).Take(1).ToList();

            ViewBag.BoolCategory1 = boolCategory1;
            ViewBag.BoolCategory2 = boolCategory2;
            ViewBag.BoolCategory3 = boolCategory3;
            ViewBag.BoolCategory4 = boolCategory4;

            return PartialView(allCategories);


        }
        public PartialViewResult PartialCourse(int? page)
        {
            int pageNumber = page ?? 1; // Sayfa numarasını belirleyin, varsayılan olarak 1
            int pageSize = 9; // Sayfa başına öğe sayısı

            var values = context.Courses.ToList().ToPagedList(pageNumber, pageSize);

            return PartialView(values);
        }
       
        public PartialViewResult PartialLibrary()
        {
            return PartialView();
        }
    }
}