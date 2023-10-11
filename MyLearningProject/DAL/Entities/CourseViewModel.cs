using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLearningProject.DAL.Entities
{
    public class CourseViewModel
    {
        public Course Course { get; set; }
        public List<Comment> Comments { get; set; }
    }
}