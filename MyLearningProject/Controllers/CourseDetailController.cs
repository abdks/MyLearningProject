using MyLearningProject.DAL.Context;
using MyLearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyLearningProject.Controllers
{
    public class CourseDetailController : Controller
    {
        ELearningContext context = new ELearningContext();
        public ActionResult Index(int id)
        {
            // Kurs bilgilerini çek
            var value = context.Courses.Find(id);

            // Oturum açmış öğrencinin e-posta adresini al
            string userEmail = Session["CurrentMail"]?.ToString();

            // Öğrenci kimliğini varsayılan olarak "0" olarak ayarla
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

            // Kursa sahipse kurs detay sayfasını görüntüle, aksi takdirde öğrenciye uyarı sayfasını göster
            if (studentCourses.Contains(id))
            {
                var comments = context.Comments
       .Where(c => c.CourseID == id)
       .ToList();

                // Kurs ve yorumları bir ViewModel'e aktarın
                var viewModel = new CourseViewModel
                {
                    Course = value,
                    Comments = comments
                };
                ViewBag.IsCourseOwned = true; // Öğrenci kursa sahipse true olarak ayarla
                //return View(value);
                return View(viewModel);
            }
            else
            {
                var comments = context.Comments
       .Where(c => c.CourseID == id)
       .ToList();

                // Kurs ve yorumları bir ViewModel'e aktarın
                var viewModel = new CourseViewModel
                {
                    Course = value,
                    Comments = comments
                };
                ViewBag.IsCourseOwned = false; // Öğrenci kursa sahip değilse false olarak ayarla

                // Kurs bilgilerini Deneme PartialView'ına gönder
                //return PartialView("Deneme", value);
                return View("deneme",viewModel);

            }
        }

        public PartialViewResult Deneme(Course course)
        {
            return PartialView(course);
        }

        [HttpPost]
        //public ActionResult AddComment(int courseId, string commentText, decimal rating)
        public ActionResult AddComment(int courseId, string commentText, decimal rating)

        {
            // Oturum açmış öğrencinin e-posta adresini al
            string userEmail = Session["CurrentMail"]?.ToString();

    // Öğrenci kimliğini varsayılan olarak "0" olarak ayarla
    int studentId = 0;

    // Eğer kullanıcı oturum açmışsa, öğrenci kimliğini bul
    if (!string.IsNullOrEmpty(userEmail))
    {
        studentId = context.Students
            .Where(x => x.Email == userEmail)
            .Select(y => y.StudentID)
            .FirstOrDefault();
    }

            // Yorumu ve puanı veritabanına kaydet
            Comment newComment = new Comment
            {
                CommentText = commentText,
                CommentDate = DateTime.Now,
                CommentStatus = true,
                StudentID = studentId,
                CourseID = courseId,
                Value = rating // JavaScript tarafından gönderilen değeri burada kullanın
            };

            context.Comments.Add(newComment);
    context.SaveChanges();

    // Yorum eklendikten sonra sayfayı yeniden yükle veya başka bir işlem yapabilirsiniz.

    // Örnek olarak, sayfanın aynı kurs detayına yönlendirilmesi:
    return RedirectToAction("Index", new { id = courseId });
          
        }



    }
}