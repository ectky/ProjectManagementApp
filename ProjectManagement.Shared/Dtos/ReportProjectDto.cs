using Microsoft.Build.Evaluation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Shared.Dtos
{
    public class ReportProjectDto : BaseModel
    {
        public ReportProjectDto()
        {

        }
        public int ReportId { get; set; }
        public ReportDto Report { get; set; }

        public int ProjectId { get; set; }

        public ProjectDto Project { get; set; }

        public virtual List<ReportProjectDto> ReportProjects { get; set; }
    }
}
