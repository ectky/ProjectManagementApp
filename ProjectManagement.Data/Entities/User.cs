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

        public string Email {  get; set; }

        public string Password { get; set; }

        public virtual Project ProjectId { get; set; }

        public string FirstName {  get; set; }

        public string LastName { get; set; }

        public virtual Role RoleId {  get; set; }
    }
}
