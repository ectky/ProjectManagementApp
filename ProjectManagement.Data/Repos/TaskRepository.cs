using AutoMapper;
using ProjectManagement.Data.Entities;
using ProjectManagement.Shared.Dtos;
using ProjectManagement.Shared.Repos.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Shared.Attributes;
using Task = ProjectManagement.Data.Entities.Task;
using Microsoft.EntityFrameworkCore;

namespace ProjectManagement.Data.Repos
{
    [AutoBind]
    public class TaskRepository : BaseRepository<Task, TaskDto>, ITaskRepository
    {
        public TaskRepository(ProjectManagementDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public async Task<IEnumerable<TaskDto>> GetAllActiveAsync()
        {
            return MapToEnumerableOfModel(await _dbSet.Where(s => s.Status == null).ToListAsync());
        }
    }
}
