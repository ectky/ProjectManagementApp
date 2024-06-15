using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectManagement.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagementMVC.ViewModels
{
    public class TaskEditVM : BaseVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Deadline { get; set; }
        public int ProjectId { get; set; }

        public IEnumerable<SelectListItem> StatusList { get; set; }

        public IEnumerable<SelectListItem> ProjectList { get; set; }

        public int UserId { get; set; }

        public IEnumerable<SelectListItem> UserList { get; set; }



    }
}
