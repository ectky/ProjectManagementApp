using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace ProjectManagementMVC.ViewModels
{
    public class AssignProjectEditVM
    {
        [DisplayName("Project")]
        public int ProjectId { get; set; }
        public IEnumerable<SelectListItem> ProjectList { get; set; }
    }
}
