using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCJobSearch.Models
{
    public class CompanyRegM
    {
        [Required(ErrorMessage ="Enter Company Name")]
        public string Comp_Name { get; set; }

        [Required(ErrorMessage = "Enter Company Address")]
        public string Comp_Address { get; set; }

        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Enter Valid Phone")]
        public string Comp_Phone { get; set; }
        public string Comp_Website { get; set; }

        [Required(ErrorMessage = "Required Field")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Required Field")]

        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password Mismatch")]
        public string CPassword { get; set; }

        public string compmsg { get; set; }
    }
}