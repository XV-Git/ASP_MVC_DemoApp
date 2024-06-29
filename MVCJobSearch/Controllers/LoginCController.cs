using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCJobSearch.Models;

namespace MVCJobSearch.Controllers
{

    public class LoginCController : Controller
    {
        Vault2Entities dbobj = new Vault2Entities();

        // GET: LoginC
        public ActionResult Login_PageLoad() // username pass disp
        {
            return View();
        }

        public ActionResult CompHome() //company homepage to enter job listing
        {
            List<CheckBoxJobHelper> jobskill = new List<CheckBoxJobHelper>()
            {
                new CheckBoxJobHelper {Value=1,Text="C#",isChecked=true},
                new CheckBoxJobHelper {Value=2,Text="ASP.NET",isChecked=false},
                new CheckBoxJobHelper {Value=3,Text="MVC",isChecked=false},
                new CheckBoxJobHelper {Value=4,Text="JAVASCRIPT",isChecked=false},
                new CheckBoxJobHelper {Value=5,Text="JQUERY",isChecked=false}

            };

            ViewBag.seljoblist = jobskill;
            return View();
        }

        public ActionResult Comp_Click(JobInsertM clsobj) // job entry click action
        {
            if (ModelState.IsValid)
            {
                List<CheckBoxJobHelper> jobskill = new List<CheckBoxJobHelper>()
            {
                new CheckBoxJobHelper {Value=1,Text="C#",isChecked=true},
                new CheckBoxJobHelper {Value=2,Text="ASP.NET",isChecked=false},
                new CheckBoxJobHelper {Value=3,Text="MVC",isChecked=false},
                new CheckBoxJobHelper {Value=4,Text="JAVASCRIPT",isChecked=false},
                new CheckBoxJobHelper {Value=5,Text="JQUERY",isChecked=false}

            };

                ViewBag.seljoblist = jobskill;
                var tmp = string.Join(",", clsobj.selectskkillset);
                clsobj.Job_Skills = tmp;

                int cid = Convert.ToInt32(Session["uid"]);
                DateTime dat = DateTime.Now.AddDays(4);

                dbobj.SP_JobInsert(cid, clsobj.Job_Title, clsobj.Job_Exp, clsobj.Job_Skills, clsobj.Job_Vacancy, dat, 1);
                clsobj.Jmsg = "Job Posted Successfully";
                return View("CompHome", clsobj);
            }
            else
            {
                List<CheckBoxJobHelper> jobskill = new List<CheckBoxJobHelper>()
            {
                new CheckBoxJobHelper {Value=1,Text="C#",isChecked=true},
                new CheckBoxJobHelper {Value=2,Text="ASP.NET",isChecked=false},
                new CheckBoxJobHelper {Value=3,Text="MVC",isChecked=false},
                new CheckBoxJobHelper {Value=4,Text="JAVASCRIPT",isChecked=false},
                new CheckBoxJobHelper {Value=5,Text="JQUERY",isChecked=false}

            };

                ViewBag.seljoblist = jobskill;
                return View("CompHome", clsobj);
            }

        }


        public ActionResult UserHome_PageLoad() // search and apply jobs
        {
            return View();
        }

        public ActionResult Login_Click(LoginM clsobj) // login click action
        {
            if (ModelState.IsValid)
            {
                var ret = dbobj.SP_LoginCount(clsobj.username, clsobj.password).FirstOrDefault();
                int retval = Convert.ToInt32(ret);

                if (retval == 1)
                {
                    var id = dbobj.SP_LoginIDGet(clsobj.username, clsobj.password).FirstOrDefault();
                    Session["uid"] = id;

                    var type = dbobj.SP_LogType(clsobj.username, clsobj.password).FirstOrDefault();

                    if (type == "Comp")
                    {
                        return RedirectToAction("CompHome");
                    }
                    else if (type == "User")
                    {
                        return RedirectToAction("UserHome_PageLoad");
                    }


                }
                else
                {
                    ModelState.Clear();
                    clsobj.msg = "Invalid Credentials";
                    return View("Login_PageLoad", clsobj);
                }

            }
            return View("Login_PageLoad", clsobj);
        }
    }
}