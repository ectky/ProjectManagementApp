using ProjectManagement.Shared.Dtos;
using ProjectManagement.Shared.Repos.Contacts;
using ProjectManagement.Shared.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagament.Services
{
    public class ReportProjectsService : BaseCrudService<ReportProjectDto, IReportProjectRepository>, IReportProjectsService
    {
        public ReportProjectsService(IReportProjectRepository repository) : base(repository)
        {

        }
    }
}