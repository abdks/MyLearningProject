using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLearningProject.DAL.Entities
{
    public class Service
    {
        public int ServiceID { get; set; }
        public String ServiceTitle { get; set; }
        public String ServiceDescription { get; set; }
    }
}