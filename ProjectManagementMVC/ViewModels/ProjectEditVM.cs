using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagementMVC.ViewModels
{
    public class ProjectEditVM : BaseVM
    {
        public string Name { get; set; }
        [DisplayName("Start Date")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("End Date")]
        public DateTime? EndDate { get; set; }
        [DisplayName("Is Completed")]
        public bool IsCompleted { get; set; }

    }
}
