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
        public ReportProjectsService(IReportProjectRepository repository) : base(repository)
        {

        }
    }
}