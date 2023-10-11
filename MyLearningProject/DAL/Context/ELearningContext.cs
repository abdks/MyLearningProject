using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MyLearningProject.DAL.Entities;
namespace MyLearningProject.DAL.Context
{
    public class ELearningContext : DbContext
    {
        internal readonly object AdminTables;

        public DbSet<Category> Categories{get; set;}
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<ContactAdmin> contactAdmins { get; set; }
        public DbSet<CourseRegister> CourseRegisters { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<About> Abouts { get; set; }

        public DbSet<Review> Reviews { get; set; }
        public DbSet<Process> Processes { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Footer> Footers { get; set; }
        public DbSet<DenemeAdmin> DenemeAdmins { get; set; }

    }
}