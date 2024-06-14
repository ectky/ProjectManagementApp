using AutoMapper;
using ProjectManagement.Data.Entities;
using ProjectManagement.Shared.Dtos;
using ProjectManagement.Shared.Repos.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Shared.Attributes;

namespace ProjectManagement.Data.Repos
{
    [AutoBind]
    public class ReportProjectRepository : BaseRepository<ReportProject, ReportProjectDto>, IReportProjectRepository
    {
        public ReportProjectRepository(ProjectManagementDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public async System.Threading.Tasks.Task ReportProjectAsync(int reportId, int projectId)
        {
            var reportProject = new ReportProjectDto(reportId, projectId);
            await SaveAsync(reportProject);
        }
    }
}
