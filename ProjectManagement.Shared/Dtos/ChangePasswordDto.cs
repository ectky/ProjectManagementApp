using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Shared.Dtos
{
    public class ChangePasswordDto
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string NewPassword { get; set; }
    }
}
