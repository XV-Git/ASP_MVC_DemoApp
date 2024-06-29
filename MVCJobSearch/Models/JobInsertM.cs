using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCJobSearch.Models
{

    public class CheckBoxJobHelper
    {
        public int Value { set; get; }
        public string Text { set; get; }
        public bool isChecked { set; get; }
    }
    public class JobInsertM
    {
        public string[] selectskkillset { get; set; }
        public int Comp_ID { get; set; }

        [Required(ErrorMessage = "Enter Job Title")]
        public string Job_Title { get; set; }

        [Required(ErrorMessage = "Enter Experience Needed")]
        public string Job_Exp { get; set; }

        //[Required(ErrorMessage = "Enter Skills Needed")]
        public string Job_Skills { get; set; }

        [Required(ErrorMessage = "Enter No of Vacany")]
        public int Job_Vacancy { get; set; }
        public System.DateTime Date { get; set; }

        public int Job_Status { get; set; }
        public string Jmsg { get; set; }
    }
}