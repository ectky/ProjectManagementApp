using ProjectManagement.Shared.Enums;

namespace ProjectManagementMVC.ViewModels
{
    public class TaskDetailsVM : BaseVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public DateTime? Deadline { get; set; }
        public int ProjectId { get; set; }

        public ProjectDetailsVM Project { get; set; }
        public List<UserDetailsVM> Users { get; set; }

    }
}
