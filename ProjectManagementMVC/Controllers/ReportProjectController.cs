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
