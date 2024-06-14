using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace ProjectManagementMVC.ViewModels
{
    public class ReportProjectEditVM : BaseVM
    {
        //[DisplayName("Reports")]

        public int ReportId { get; set; }
        public int ProjectId { get; set; }

        public IEnumerable<SelectListItem> Reports { get; set; }
        public IEnumerable<SelectListItem> Projects { get; set; }

         

    }
}
