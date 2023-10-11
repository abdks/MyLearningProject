using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLearningProject.DAL.Entities
{
    public class Comment
    {
        public int CommentID { get; set; }
        public String CommentText { get; set; }
        public DateTime CommentDate { get; set; }
        public decimal Value { get; set; }
        public bool CommentStatus { get; set; }
        public int StudentID { get; set; }
        public virtual Student Student{ get; set; }
        public int CourseID { get; set; }
        public virtual Course Course { get; set; }
    }
}