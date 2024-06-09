namespace ProjectManagementMVC.ViewModels
{
    public class UserDetailsVM : BaseVM
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? ProjectId { get; set; }
        public int RoleId { get; set; }
        public ProjectDetailsVM Project { get; set; }
        public RoleDetailsVM Role { get; set; }
    }
}
