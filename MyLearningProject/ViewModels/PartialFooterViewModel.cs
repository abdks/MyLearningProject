using MyLearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLearningProject.ViewModels
{
    public class PartialFooterViewModel
    {
        public List<Footer> Footers { get; set; }
        public List<ContactAdmin> ContactAdmins { get; set; }
        public List<Course> Courses { get; set; }
    }
}