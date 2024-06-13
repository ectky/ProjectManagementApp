using System.ComponentModel.DataAnnotations;

namespace ProjectManagementMVC.ViewModels
{
    public class ProjectEditVM : BaseVM
    {
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
        public bool IsCompleted { get; set; }

    }
}
