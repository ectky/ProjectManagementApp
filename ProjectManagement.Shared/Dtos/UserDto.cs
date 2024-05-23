using Microsoft.Build.Evaluation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Shared.Dtos
{
    public class UserDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int? ProjectId { get; set; }
        public int RoleId { get; set; }

        public  ProjectDto Project { get; set; }
        public  RoleDto Role { get; set; }
    }
}
