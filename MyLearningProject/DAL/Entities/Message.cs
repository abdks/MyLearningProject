using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLearningProject.DAL.Entities
{
    public class Message
    {
        public int MessageID { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}