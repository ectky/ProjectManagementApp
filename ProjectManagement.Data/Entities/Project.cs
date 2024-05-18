using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Data.Entities
{
    public class Project
    {
        public string ProjectName { get; set; }

        public string Tasks {  get; set; }

        public string StartDate { get; set; }

        public string Description { get; set; }

        public string EndDate { get; set; }

        public bool IsCompleted { get; set; }

        public int UserId {  get; set; }
    }
}
