using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
        [DataType(DataType.Date)]
        [DisplayName("Start Date")]
        public DateTime? StartDate { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("End Date")]
        public DateTime? EndDate { get; set; }
        [DisplayName("Is Completed")]
        public bool IsCompleted { get; set; }
        public List<UserDetailsVM> Users { get; set; }
        public List<TaskDetailsVM> Tasks { get; set; }

        public virtual List<ReportProjectDetailsVM> ReportProjects { get; set; }

    }
}
