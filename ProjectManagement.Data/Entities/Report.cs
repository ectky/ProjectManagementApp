using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Data.Entities
{
    public class Report: BaseEntity
    {

        public Report() 
        {
            this.ReportProjects = new List<ReportProject>();
        }
        public string Name {  get; set; }

        public string Description { get; set; }

        public virtual List<ReportProject> ReportProjects { get; set; }
    }
}
