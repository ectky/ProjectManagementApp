using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectManagement.Shared.Enums;

namespace ProjectManagementMVC.ViewModels
{
    public class TaskEditVM : BaseVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public DateTime? Deadline { get; set; }
        public int ProjectId { get; set; }
        public List<int> UserIds { get; set; }

        public IEnumerable<SelectListItem> Projects { get; set; }
        public IEnumerable<SelectListItem> Users { get; set; }
    }
}
