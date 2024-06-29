using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCJobSearch.Models;

namespace MVCJobSearch.Controllers
{
    public class SearchCController : Controller
    {
        Vault2Entities dbobj = new Vault2Entities();
        // GET: SearchC

        public ActionResult Search_PageLoad()
        {
            return View(GetData());
        }

        private SearchQryM GetData()
        {
            DateTime dat = DateTime.Now.Date;
            var joblist = new SearchQryM();
            List<string> lst = new List<string>();
            var job = dbobj.Job_Table.ToList();
            foreach (var e in job)
            {
                if (e.Date >= dat)
                {

                    var jobcls = new jsearch();
                    jobcls.job_id = e.Job_ID;
                    jobcls.company_Id = e.Comp_ID;
                    jobcls.Job_Title = e.Job_Title;
                    jobcls.experience = e.Job_Exp;
                    jobcls.skills = e.Job_Skills;
                    jobcls.vacancy = e.Job_Vacancy;
                    jobcls.job_Status = e.Job_Status;
                    jobcls.last_Date = e.Date;

                    joblist.selectjob.Add(jobcls);

                    var s = jobcls.skills;
                    lst.Add(s);
                    TempData["ski"] = string.Join(" ", lst);
                }
            }
            return joblist;
        }

        public ActionResult Search_Click(SearchQryM clsobj)
        {

            string qry = "";
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.experience))
            {
                qry += " and Job_Exp like '%" + clsobj.insertse.experience + "%'";
            }
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.skills))
            {
                qry += " and Job_Skills like '%" + clsobj.insertse.skills + "%'";
            }
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.Job_Title))
            {
                qry += " and Job_Title like '%" + clsobj.insertse.Job_Title + "%'";
            }
            return View("Search_PageLoad", getdata1(clsobj, qry));

        }
        private SearchQryM getdata1(SearchQryM clsobj, string qry)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SearchConn"].ConnectionString))
            {
                DateTime dat = DateTime.Now.Date;
                SqlCommand cmd = new SqlCommand("SP_JobSearchQry", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@qry", qry);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                var joblist = new SearchQryM();
                while (dr.Read())
                {
                    if ((System.DateTime)dr["Date"] >= dat)
                    {
                        var jobcls = new jsearch();
                        jobcls.company_Id = Convert.ToInt32(dr["Comp_ID"].ToString());
                        jobcls.Job_Title = dr["Job_Title"].ToString();
                        jobcls.experience = dr["Job_Exp"].ToString();
                        jobcls.skills = dr["Job_Skills"].ToString();
                        jobcls.vacancy = Convert.ToInt32(dr["Job_Vacancy"].ToString());
                        jobcls.job_Status = Convert.ToInt32(dr["Job_Status"].ToString());
                        jobcls.last_Date = (System.DateTime)dr["Date"];

                        joblist.selectjob.Add(jobcls);
                    }
                }
                con.Close();
                return joblist;

            }
        }
    }
}