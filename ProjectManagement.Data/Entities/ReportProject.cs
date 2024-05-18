using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Data.Entities
{
    public class ReportProject : BaseEntity
    {
        public int ReportId {  get; set; }
        public virtual Report Report {  get; set; }

        public int ProjectId { get; set; }

        public virtual Project Project {  get; set; }
    }
}
