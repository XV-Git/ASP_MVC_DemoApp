using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVCJobSearch.Controllers
{
    public class ApplyJobCController : Controller
    {
        Vault2Entities dbobj = new Vault2Entities();
        // GET: ApplyJobC
        public ActionResult ApplyJobC_PageLoad(int cid, int jid)
        {
            Session["cid"] = cid;
            Session["jid"] = jid;
            return View();
        }

        public ActionResult ApplyJobC_Click()
        {
            int cid = Convert.ToInt32(Session["cid"]);
            int jid = Convert.ToInt32(Session["jid"]);
            int uid = Convert.ToInt32(Session["uid"]);
            var cvitae = dbobj.SP_GetCVDetails(uid).FirstOrDefault();
            DateTime dat = DateTime.Now.Date;
            dbobj.SP_ApplicationInsert(uid, cid, jid, cvitae, dat, 1);
            TempData["msg"] = "Application Submitted Successfully";
            return View("ApplyJobC_PageLoad");
        }
    }
}