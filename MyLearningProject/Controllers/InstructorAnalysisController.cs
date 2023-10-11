using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyLearningProject.DAL.Context;
using MyLearningProject.DAL.Entities;

namespace MyLearningProject.Controllers
{
    public class InstructorAnalysisController : Controller
    {
        // GET: InstructorAnalysis
        ELearningContext context = new ELearningContext();
        public ActionResult Index(int id)
        {
            Session["UserID"] = id;

            ViewBag.SayfaBasligi = "";

            return View();
        }
        public PartialViewResult InstructorPanelPartial()
        {
          //int  id = 2;
            int id = (int)Session["UserID"];

            var values = context.Instructors.Where(x => x.InstructorID == id).ToList();
            var instructor = context.Instructors.FirstOrDefault(x => x.InstructorID == id);
            string name = instructor.Name;
            string surname = instructor.Surname;
            //var v1 = context.Instructors.Where(x => x.Name == "Abdullah" && x.Surname == "Kuş").Select(y => y.InstructorID).FirstOrDefault();
            var v1 = context.Instructors.Where(x => x.Name == name && x.Surname == surname).Select(y => y.InstructorID).FirstOrDefault();

            var v2 = context.Courses.Where(x => x.InstructorID == v1).Select(y => y.CourseID).ToList();
            var v3 = context.Comments.Where(x => v2.Contains(x.CourseID)).ToList();

            ViewBag.commentCount = context.Comments.Where(x => v2.Contains(x.CourseID)).Count();






            ViewBag.courseCount = context.Courses.Where(x => x.InstructorID == id).Count();
            return PartialView(values);


        }
        public PartialViewResult CommentPartial()
        {
            int id = (int)Session["UserID"];
            var instructor = context.Instructors.FirstOrDefault(x => x.InstructorID == id);
            string name = instructor.Name;
            string surname = instructor.Surname;
            var v1 = context.Instructors.Where(x => x.Name == name && x.Surname == surname).Select(y => y.InstructorID).FirstOrDefault();
            var v2 = context.Courses.Where(x => x.InstructorID == v1).Select(y => y.CourseID).ToList();
            var v3 = context.Comments.Where(x=> v2.Contains(x.CourseID)).ToList();





            return PartialView(v3);
        }

        public PartialViewResult CourseListByInstructor()
        {
            int id = (int)Session["UserID"];
          
            var values = context.Courses.Where(x => x.InstructorID == id).ToList();
            return PartialView(values);
            
        }
        [HttpGet]
        public ActionResult AddCourse()
        {
            int id = (int)Session["UserID"];

            List<SelectListItem> categories = (from x in context.Categories.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryID.ToString()
                                               }).ToList();
            ViewBag.v = categories;

            List<SelectListItem> instructors = (from y in context.Instructors.ToList().OrderBy(z => z.Name)
                                                select new SelectListItem
                                                {
                                                    Text = y.Name + " " + y.Surname,
                                                    Value = y.InstructorID.ToString()
                                                }).ToList();
           
            ViewBag.v2 = instructors;
            return View();
        }
        [HttpPost]
        public ActionResult AddCourse(Course course)
        {
            int id = (int)Session["UserID"];
            context.Courses.Add(course);
            context.SaveChanges();
            return RedirectToAction("Index", new { id = id });
        }

     
        [HttpGet]
        public ActionResult profile(int id)
        {
       
            int dene = (int)Session["UserID"];
            var value = context.Instructors.Find(dene);
            return View(value);

        }

        [HttpPost]
        public ActionResult profile(Instructor instructor)
        {
            int id = (int)Session["UserID"];
            var value = context.Instructors.Find(instructor.InstructorID);


            value.Name = instructor.Name;
            value.Surname = instructor.Surname;
            value.ImageUrl = instructor.ImageUrl;
            value.Instagram = instructor.Instagram;
            value.Facebook = instructor.Facebook;
            value.Twitter = instructor.Twitter;
            value.Title = instructor.Title;
            value.ProfileImage = instructor.ProfileImage;
            value.CoverImage = instructor.CoverImage;
            value.Email = instructor.Email;
            value.Password = instructor.Password;

            context.SaveChanges();

            return RedirectToAction("Index", new { id = id });
        }


    }
}