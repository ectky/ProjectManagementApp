using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Shared.Dtos
{
    public class ProjectDto : BaseModel
    {
        public ProjectDto()
        {
            this.Users = new List<UserDto>();
            this.Tasks = new List<TaskDto>();
        }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public string Description { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsCompleted { get; set; }
        public ICollection<UserDto> Users { get; set; } = new List<UserDto>();
        public ICollection<TaskDto> Tasks { get; set; } = new List<TaskDto>();
    }
}
