using MyLearningProject.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyLearningProject.Controllers
{
    public class CommentAdminController : Controller
    {

        ELearningContext context = new ELearningContext();
        public ActionResult Index()
        {
            ViewBag.SayfaBasligi = "Yorumlar-Sayfası";
            var values = context.Comments.ToList();
            return View(values);
        }
       
        public ActionResult DeleteComments(int id)
        {
            var value = context.Comments.Find(id);
            context.Comments.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
       
    }
}