using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;

namespace ProjectManagementMVC.ViewModels
{
    public class UserEditVM : BaseVM
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        public int? ProjectId { get; set; }

        [Required]
        public int RoleId { get; set; }

        public IEnumerable<SelectListItem> Projects { get; set; }
        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}
