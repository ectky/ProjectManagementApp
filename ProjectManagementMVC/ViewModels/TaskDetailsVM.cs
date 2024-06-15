using ProjectManagement.Data.Entities;
using ProjectManagement.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagementMVC.ViewModels
{
    public class TaskDetailsVM : BaseVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Deadline { get; set; }
        public int ProjectId { get; set; }

        public ProjectDetailsVM Project { get; set; }
        public int UserId { get; set; }

        public UserDetailsVM User { get; set; }

    }
}
