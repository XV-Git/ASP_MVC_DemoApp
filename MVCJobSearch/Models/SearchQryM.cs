using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCJobSearch.Models
{
    public class SearchQryM
    {
        public SearchQryM()
        {
            selectjob = new List<jsearch>();
            insertse = new jsearch();
        }
        public jsearch insertse { set; get; }
        public List<jsearch> selectjob { set; get; }
    }

    public class jsearch
    {
        public int job_id { get; set; }
        public int company_Id { get; set; }

        public string Job_Title { get; set; }
        public string experience { get; set; }
        public string skills { get; set; }
        public int vacancy { get; set; }
        public System.DateTime last_Date { get; set; }
        public int job_Status { get; set; }
        public string jobmsg { get; set; }

    }
}
