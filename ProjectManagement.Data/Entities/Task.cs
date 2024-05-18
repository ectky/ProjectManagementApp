using ProjectManagement.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Data.Entities
{
    public class Task : BaseEntity
    { 
        public string Description { get; set; }

        public string Name { get; set; }

        public Status Status { get; set; }
        public DateTime? Deadline {  get; set; }
        
        public virtual List<User> Users {  get; set; }

        public virtual Project Project {  get; set; }

        public int ProjectId {  get; set; }

    }
}
