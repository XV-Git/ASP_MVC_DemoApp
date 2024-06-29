using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCJobSearch.Models
{
    public class LoginM
    {
        [Required(ErrorMessage = "Enter Username")]
        public string username { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        public string password { get; set; }

        public string msg { get; set; }


    }
}