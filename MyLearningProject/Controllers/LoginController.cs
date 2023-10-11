using MyLearningProject.DAL.Context;
using MyLearningProject.DAL.Entities;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace MyLearningProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        ELearningContext context = new ELearningContext();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Student student)
        {
            var values = context.Students.FirstOrDefault(x => x.Email == student.Email && x.Password == student.Password);
            if(values != null)
            {
                FormsAuthentication.SetAuthCookie(values.Email, false);
                Session["CurrentMail"] = values.Email;
               
                Session.Timeout = 60;
                return RedirectToAction("Index", "Web", new { studentid = values.StudentID });
            }
            return View();
        }
    }
}