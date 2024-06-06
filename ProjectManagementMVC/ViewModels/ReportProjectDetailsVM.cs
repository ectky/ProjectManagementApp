namespace ProjectManagementMVC.ViewModels
{
    public class ReportProjectDetailsVM : BaseVM
    {
        public int ReportId { get; set; }
        public int ProjectId { get; set; }
        public ReportDetailsVM Report { get; set; }
        public ProjectDetailsVM Project { get; set; }
    }
}
