using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Data.Entities
{
    public class User: BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int? ProjectId { get; set; }
        public int RoleId { get; set; }

        public virtual Project Project { get; set; }
        public virtual Role Role { get; set; }
        public virtual List<Task> Tasks { get; set; }
    }
}
