using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MyLearningProject.DAL.Entities
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryImageUrl { get; set; }
        public bool CategoryFilter { get; set; }
        public List<Course> Courses { get; set; }

    }
}