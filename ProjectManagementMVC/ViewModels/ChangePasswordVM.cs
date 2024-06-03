using Microsoft.Build.Framework;

namespace ProjectManagementMVC.ViewModels
{
    public class ChangePasswordVM : BaseVM
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string NewPassword { get; set; }
    }
}
