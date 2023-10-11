using MyLearningProject.DAL.Context;
using MyLearningProject.DAL.Entities;
using MyLearningProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace MyLearningProject.Controllers
{
    public class WebController : Controller
    {
        // GET: Web
        ELearningContext context = new ELearningContext();

        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                // Eğer id dışardan gelmemişse, kullanıcı girişi yapmışsa sabit bir id kullanabilirsiniz.
                // Örnek olarak, 1 numaralı özel bir kullanıcıyı temsil eden bir id kullanalım.
                id = 0;
            }

            var value = context.Students.Find(id);

            // Geri kalan işlemleri yapabilirsiniz

            return View();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialCarousel()
        {
            var values = context.Sliders.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialSpinner()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult PartialService()
        {
            return PartialView();
        }
        public PartialViewResult PartialAbout()
        {
            return PartialView();
        }
        public PartialViewResult PartialCategories()
        {
            return PartialView();
        }
       
        public PartialViewResult PartialCourses()
        {
            // Tüm kursları al
            var allCourses = context.Courses.ToList();

            // Oturum açmış öğrencinin e-posta adresini al
            string userEmail = Session["CurrentMail"]?.ToString();

            // Öğrenci kimliğini varsayılan olarak "1" olarak ayarla
            int studentId = 0;

            // Eğer kullanıcı oturum açmışsa, öğrenci kimliğini bul
            if (!string.IsNullOrEmpty(userEmail))
            {
                studentId = context.Students
                    .Where(x => x.Email == userEmail)
                    .Select(y => y.StudentID)
                    .FirstOrDefault();
            }

            // Öğrencinin sahip olduğu kursları al
            var studentCourses = context.Processes
                .Where(x => x.StudentID == studentId)
                .Select(y => y.CourseID)
                .ToList();

            // View'e veriyi Tuple olarak dön
            var coursesViewModel = new Tuple<List<Course>, List<int>>(allCourses, studentCourses);
            return PartialView(coursesViewModel);
        }



        public PartialViewResult PartialTeam()
        {
            return PartialView();
        }
        public PartialViewResult PartialTestimonial()
        {
            var values = context.Testimonials.ToList();
            return PartialView(values);
        }
        public ActionResult PartialFooter()
        {
            using (var context = new ELearningContext())
            {
                var footers = context.Footers.ToList();
                var contactAdmins = context.contactAdmins.ToList();
                var courses = context.Courses.ToList();

                var viewModel = new PartialFooterViewModel
                {
                    Footers = footers,
                    ContactAdmins = contactAdmins,
                    Courses = courses
                };

                return PartialView("PartialFooter", viewModel);
            }
        }

        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
       
    }
}