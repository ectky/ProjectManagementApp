using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Shared.Dtos
{
    public class RoleDto : BaseModel
    {
        public RoleDto()
        {
            this.Users = new List<UserDto>();
        }
        public string Name { get; set; }

        public ICollection<UserDto> Users { get; set; } = new List<UserDto>();
    }
}
