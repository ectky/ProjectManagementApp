using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProjectManagementMVC.ViewModels
{
    public class ReportProjectEditVM : BaseVM
    {
        public int ReportId { get; set; }
        public int ProjectId { get; set; }

        public IEnumerable<SelectListItem> Reports { get; set; }
        public IEnumerable<SelectListItem> Projects { get; set; }
    }
}
