namespace ProjectManagementMVC.ViewModels
{
    public class ProjectEditVM : BaseVM
    {
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public string Description { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsCompleted { get; set; }

    }
}
