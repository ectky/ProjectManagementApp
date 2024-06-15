namespace ProjectManagementMVC.ViewModels
{
    public class ReportDetailsVM : BaseVM
    {
        public ReportDetailsVM() 
        {
            this.ReportProjects = new List<ReportProjectDetailsVM>();
        }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual List<ReportProjectDetailsVM> ReportProjects { get; set; }
    }
}
