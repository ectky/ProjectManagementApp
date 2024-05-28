using AutoMapper;
using ProjectManagement.Data.Entities;
using ProjectManagement.Shared.Dtos;
using ProjectManagement.Shared.Repos.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = ProjectManagement.Data.Entities.Task;

namespace ProjectManagement.Data.Repos
{
    public class TaskRepository : BaseRepository<Task, TaskDto>, ITaskRepository
    {
        public TaskRepository(ProjectManagementDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
