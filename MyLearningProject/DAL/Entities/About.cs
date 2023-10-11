using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLearningProject.DAL.Entities
{
    public class About
    {
        public int AboutID { get; set; }
        public String AboutTitle { get; set; }
        public String AboutParagraph { get; set; }
        public String AboutService { get; set; }
        public String AboutImage { get; set; }
    }
}