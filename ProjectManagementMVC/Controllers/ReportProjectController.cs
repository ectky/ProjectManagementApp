using AutoMapper;
using ProjectManagement.Shared.Dtos;
using ProjectManagement.Shared.Repos.Contacts;
using ProjectManagement.Shared.Services.Contracts;
using ProjectManagementMVC.ViewModels;

namespace ProjectManagementMVC.Controllers
{
    public class ReportProjectController : BaseCrudController<ReportProjectDto, IReportProjectRepository, IReportProjectsService, ReportProjectEditVM, ReportProjectDetailsVM>
    {
        public ReportProjectController(IReportProjectsService service, IMapper mapper) : base(service, mapper)
        {

        }
    }
}
