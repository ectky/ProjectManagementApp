using AutoMapper;
using ProjectManagement.Data.Entities;
using ProjectManagement.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = ProjectManagement.Data.Entities.Task;

namespace ProjectManagement.Data.Repos
{
    public class TaskRepository : BaseRepository<Task, TaskDto>
    {
        public TaskRepository(ProjectManagementDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
