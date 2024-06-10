using System.ComponentModel;

namespace ProjectManagementMVC.ViewModels
{
    public class ProjectDetailsVM : BaseVM
    {
        public ProjectDetailsVM()
        {
            this.ReportProjects = new List<ReportProjectDetailsVM>();
        }
        [DisplayName("Project name")]
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public string Description { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsCompleted { get; set; }
        public List<UserDetailsVM> Users { get; set; }
        public List<TaskDetailsVM> Tasks { get; set; }

        public virtual List<ReportProjectDetailsVM> ReportProjects { get; set; }

    }
}
