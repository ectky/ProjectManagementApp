using ProjectManagement.Data.Entities;
using System.ComponentModel;

namespace ProjectManagementMVC.ViewModels
{
    public class ReportProjectDetailsVM : BaseVM
    {
        public int ReportId { get; set; }
        public int ProjectId { get; set; }
        public ReportDetailsVM Report { get; set; }

        [DisplayName("Project name")]
        public ProjectDetailsVM Project { get; set; }

    }
}
