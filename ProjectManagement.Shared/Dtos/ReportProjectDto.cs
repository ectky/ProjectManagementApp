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
        public ReportProjectDto(int reportId, int projectId)
        {
            this.ReportId = reportId;
            this.ProjectId = projectId;
        }
        public int ReportId { get; set; }
        public ReportDto Report { get; set; }

        public int ProjectId { get; set; }

        public ProjectDto Project { get; set; }

    }
}
