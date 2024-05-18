using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Data.Entities
{
    public class Task
    {
        public string Description { get; set; }

        public string TaskName { get; set; }

        public enum Status {NotStarted, InProgress, Completed, OnHold, Cancelled}

        public int Deadline {  get; set; }
        
        public int AssignedUsers {  get; set; }

        public int ProjectId {  get; set; }

    }
}
