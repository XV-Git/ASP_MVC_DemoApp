using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCJobSearch.Models;
namespace MVCJobSearch.Controllers
{
    public class UserRegCController : Controller
    {
        Vault2Entities dbobj = new Vault2Entities();
        // GET: UserRegC
        public ActionResult UserReg_Pageload()
        {
            List<CheckBoxHelper> chkval = new List<CheckBoxHelper>()
            {
                new CheckBoxHelper {Value=1,Text="SSLC",isChecked=true},
                new CheckBoxHelper {Value=2,Text="PLUS TWO",isChecked=false},
                new CheckBoxHelper {Value=3,Text="BTECH",isChecked=false},
                new CheckBoxHelper {Value=4,Text="MTECH",isChecked=false},
                new CheckBoxHelper {Value=5,Text="MBA",isChecked=false}

            };

            ViewBag.selQual = chkval;

            //skill
            List<CheckBoxHelper> skillset = new List<CheckBoxHelper>()
            {
                new CheckBoxHelper {Value=1,Text="C#",isChecked=true},
                new CheckBoxHelper {Value=2,Text="ASP.NET",isChecked=false},
                new CheckBoxHelper {Value=3,Text="MVC",isChecked=false},
                new CheckBoxHelper {Value=4,Text="JAVASCRIPT",isChecked=false},
                new CheckBoxHelper {Value=5,Text="JQUERY",isChecked=false}

            };

            ViewBag.selSkill = skillset;

            UserRegM ob = new UserRegM();
            return View(ob);
        }


        public ActionResult UserReg_Click(UserRegM clsobj, HttpPostedFileBase[] files)
        {
            if (ModelState.IsValid)
            {
                var retval = dbobj.SP_LoginMaxCount().FirstOrDefault();
                int tempid = Convert.ToInt32(retval);
                int regid = 0;
                if (tempid == 0)
                {
                    regid = 1;
                }
                else
                {
                    regid = tempid + 1;
                }


                //Box
                List<CheckBoxHelper> chkval = new List<CheckBoxHelper>()
            {
                new CheckBoxHelper {Value=1,Text="SSLC",isChecked=true},
                new CheckBoxHelper {Value=2,Text="PLUS TWO",isChecked=false},
                new CheckBoxHelper {Value=3,Text="BTECH",isChecked=false},
                new CheckBoxHelper {Value=4,Text="MTECH",isChecked=false},
                new CheckBoxHelper {Value=5,Text="MBA",isChecked=false}

            };

                ViewBag.selQual = chkval;

                var Qualifi = string.Join(",", clsobj.SelectedQual);
                clsobj.User_Qual = Qualifi;


                //Skill
                List<CheckBoxHelper> skillset = new List<CheckBoxHelper>()
            {
                new CheckBoxHelper {Value=1,Text="C#",isChecked=true},
                new CheckBoxHelper {Value=2,Text="ASP.NET",isChecked=false},
                new CheckBoxHelper {Value=3,Text="MVC",isChecked=false},
                new CheckBoxHelper {Value=4,Text="JAVASCRIPT",isChecked=false},
                new CheckBoxHelper {Value=5,Text="JQUERY",isChecked=false}

            };

                ViewBag.selSkill = skillset;
                var skillz = string.Join(",", clsobj.SelectedSkill);
                clsobj.User_Skills = skillz;

                //Img
                if (files[0].ContentLength > 0)
                {
                    string filena = Path.GetFileName(files[0].FileName);
                    var p = Server.MapPath("~/Image");
                    string pat = Path.Combine(p, filena);
                    files[0].SaveAs(pat);
                    var fullpath = Path.Combine("~\\Image", filena);
                    clsobj.User_Photo = fullpath;
                }

                //Resume
                if (files[1].ContentLength > 0)
                {
                    string filena = Path.GetFileName(files[1].FileName);
                    var p = Server.MapPath("~/Resume");
                    string pat = Path.Combine(p, filena);
                    files[1].SaveAs(pat);
                    var fullpath = Path.Combine("~\\Resume", filena);
                    clsobj.User_CV = fullpath;
                }



                dbobj.SP_UserRegistration(regid, clsobj.User_Name, clsobj.User_Age, clsobj.User_Address,clsobj.User_Phone , clsobj.User_Email, clsobj.User_Gender, clsobj.User_Qual, clsobj.User_Exp, clsobj.User_Skills, clsobj.User_Photo, clsobj.User_CV);
                dbobj.SP_LoginInsert(regid, clsobj.Username, clsobj.CPassword,"User");
                clsobj.usrmsg = "User Registered Successfully";
                return View("UserReg_Pageload", clsobj);

            }
            else
            {
                //Box
                List<CheckBoxHelper> chkval = new List<CheckBoxHelper>()
            {
                new CheckBoxHelper {Value=1,Text="SSLC",isChecked=true},
                new CheckBoxHelper {Value=2,Text="PLUS TWO",isChecked=false},
                new CheckBoxHelper {Value=3,Text="BTECH",isChecked=false},
                new CheckBoxHelper {Value=4,Text="MTECH",isChecked=false},
                new CheckBoxHelper {Value=5,Text="MBA",isChecked=false}

            };

                ViewBag.selQual = chkval;

                var Qualifi = string.Join(",", clsobj.SelectedQual);
                clsobj.User_Qual = Qualifi;


                //Skill
                List<CheckBoxHelper> skillset = new List<CheckBoxHelper>()
            {
                new CheckBoxHelper {Value=1,Text="C#",isChecked=true},
                new CheckBoxHelper {Value=2,Text="ASP.NET",isChecked=false},
                new CheckBoxHelper {Value=3,Text="MVC",isChecked=false},
                new CheckBoxHelper {Value=4,Text="JAVASCRIPT",isChecked=false},
                new CheckBoxHelper {Value=5,Text="JQUERY",isChecked=false}

            };

                ViewBag.selSkill = skillset;
                var skillz = string.Join(",", clsobj.SelectedSkill);
                clsobj.User_Skills = skillz;
                return View("UserReg_Pageload", clsobj);

            }

        }
    }
}