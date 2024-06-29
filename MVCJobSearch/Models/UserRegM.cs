using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace MVCJobSearch.Models
{

    public class CheckBoxHelper
    {
        public int Value { set; get; }
        public string Text { set; get; }
        public bool isChecked { set; get; }
    }
    public class UserRegM
    {
        public string[] SelectedQual { get; set; }

        public string[] SelectedSkill { get; set; }


        [Required(ErrorMessage = "Enter Your Name")]
        public string User_Name { get; set; }

        [Range(18, 50, ErrorMessage = "Age between 18 and 50")]
        public int User_Age { get; set; }

        [Required(ErrorMessage = "Enter your Address")]
        public string User_Address { get; set; }

        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Enter Valid Phone")]
        public string User_Phone { get; set; }

        [EmailAddress(ErrorMessage = "Enter your Email ID")]
        public string User_Email { get; set; }

        [Required(ErrorMessage = "Select One")]
        public string User_Gender { get; set; }
        public string User_Qual { get; set; }

        [Required(ErrorMessage = "Enter Work Experience")]
        public int User_Exp { get; set; }

        //[Required(ErrorMessage = "Enter Skillset")]
        public string User_Skills { get; set; }

        // [Required(ErrorMessage = "Photo to be Uploaded")]
        public string User_Photo { get; set; }

        // [Required(ErrorMessage = "Resume to be Uploaded")]
        public string User_CV { get; set; }

        [Required(ErrorMessage = "Required Field")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Required Field")]

        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password Mismatch")]
        public string CPassword { get; set; }

        public string usrmsg { get; set; }
    }
}