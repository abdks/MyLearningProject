using MyLearningProject.DAL.Context;
using MyLearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyLearningProject.Controllers
{
    public class InstructorController : Controller
    {
        ELearningContext context = new ELearningContext();
        public ActionResult Index()
        {
            ViewBag.SayfaBasligi = "Eğitmenler";
            var values = context.Instructors.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddInstructors()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddInstructors(Instructor ınstructor)
        {
            context.Instructors.Add(ınstructor);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteInstructors(int id)
        {
            var value = context.Instructors.Find(id);
            context.Instructors.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult UpdateInstructors(int id)
        {
            var value = context.Instructors.Find(id);
            return View(value);

        }
        [HttpPost]
        public ActionResult UpdateInstructors(Instructor instructor)
        {
            var value = context.Instructors.Find(instructor.InstructorID);
            value.Name = instructor.Name;
            value.Surname = instructor.Surname;
           
            value.Facebook = instructor.Facebook;
            value.Instagram = instructor.Instagram;
            value.Twitter = instructor.Twitter;
            value.ImageUrl = instructor.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}