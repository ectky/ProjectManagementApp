using ProjectManagement.Shared.Dtos;
using ProjectManagement.Shared.Repos.Contacts;
using ProjectManagement.Shared.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Shared.Attributes;

namespace ProjectManagement.Services
{
    [AutoBind]

    public class ReportProjectsService : BaseCrudService<ReportProjectDto, IReportProjectRepository>, IReportProjectsService
    {
        public IReportsService _reportsService;
        public IProjectsService _projectsService;
        public ReportProjectsService(IReportProjectRepository repository, IReportsService reportsService, IProjectsService projectsService) : base(repository)
        {
            _reportsService = reportsService;
            _projectsService = projectsService;
        }
        public async Task ReportProjectAsync(int reportId, int projectId)
        {
            if (!await _reportsService.ExistsByIdAsync(reportId))
            {
                throw new ArgumentException($"Report with ID {reportId} does not exist.");
            }
            if (!await _projectsService.ExistsByIdAsync(projectId))
            {
                throw new ArgumentException($"Project with ID {projectId} does not exist.");
            }

            await _repository.ReportProjectAsync(reportId, projectId);
        }

    }
}