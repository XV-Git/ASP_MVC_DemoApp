using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCJobSearch.Models;

namespace MVCJobSearch.Controllers
{
    public class CompanyRegCController : Controller
    {
        Vault2Entities dbobj = new Vault2Entities();
        // GET: CompanyRegC
        public ActionResult CompanyReg_Pageload() // company reg form
        {
            return View();
        }

        public ActionResult CompanyReg_Click(CompanyRegM clsobj) // company click action
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

                dbobj.SP_CompanyRegistration(regid, clsobj.Comp_Name, clsobj.Comp_Address, clsobj.Comp_Phone, clsobj.Comp_Website);
                dbobj.SP_LoginInsert(regid, clsobj.Username, clsobj.CPassword, "Comp");
                clsobj.compmsg = "Company Registered Successfully";
                return View("CompanyReg_Pageload", clsobj);
            }
            else
            {
                return View("CompanyReg_Pageload", clsobj);
            }
        }
    }
}