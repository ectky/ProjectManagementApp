using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Shared.Dtos
{
    public class ReportDto : BaseModel
    {
        public ReportDto() 
        {
            this.ReportProjects = new List<ReportProjectDto>();
        }
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual List<ReportProjectDto> ReportProjects { get; set; }
    }
}
