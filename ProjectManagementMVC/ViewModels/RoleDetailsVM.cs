namespace ProjectManagementMVC.ViewModels
{
    public class RoleDetailsVM : BaseVM
    {
        public string Name { get; set; }
        public IEnumerable<UserDetailsVM> Users { get; set; }
    }
}
