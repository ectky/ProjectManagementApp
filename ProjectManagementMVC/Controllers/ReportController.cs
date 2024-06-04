using ProjectManagementMVC.ViewModels;

namespace ProjectManagementMVC.Controllers
{
    public class ReportController : BaseCrudController<ReportDto, IReportRepository, IReportsService, ReportEditVM, ReportDetailsVM>
    {
        public ReportController(IReportsService service, IMapper mapper) : base(service, mapper)
        {

        }
    }
}
