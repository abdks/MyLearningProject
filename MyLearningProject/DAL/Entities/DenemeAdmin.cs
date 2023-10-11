using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MyLearningProject.DAL.Entities;
namespace MyLearningProject.DAL.Entities
{
    public class DenemeAdmin
    {
        public int DenemeAdminID { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }

    }
}