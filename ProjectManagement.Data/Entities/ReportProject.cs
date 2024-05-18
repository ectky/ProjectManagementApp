using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Data.Entities
{
    public class ReportProject : BaseEntity
    {
        public Report ReportId {  get; set; }

        public Project ProjectId {  get; set; }
    }
}
