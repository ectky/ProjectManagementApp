using ProjectManagement.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Data.Entities
{
    public class Project:BaseEntity
    {
        public Project()
        {
            this.ReportProjects = new List<ReportProject>();
        }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public string Description { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsCompleted { get; set; }


        public virtual ICollection<User> Users { get; set; } = new List<User>();
        public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();

        public virtual List<ReportProject> ReportProjects { get; set; }
    }
    
}
