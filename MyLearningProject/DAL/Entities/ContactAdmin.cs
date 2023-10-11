using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyLearningProject.DAL.Entities
{
    public class ContactAdmin
    {
        [Key]
        public int ContactID { get; set; }
        public string ContactTitle { get; set; }
        public string ContactDescription { get; set; }
        public string ContactAdress { get; set; }
        public string ContactPhone { get; set; }
        public string ContactMail { get; set; }
        public string ContactTwitter { get; set; }
        public string ContactFacebook { get; set; }
        public string ContactYoutube { get; set; }
        public string ContactLinkedin { get; set; }
    }
}