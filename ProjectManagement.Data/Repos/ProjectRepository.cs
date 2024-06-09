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
using Microsoft.EntityFrameworkCore;

namespace ProjectManagement.Data.Repos
{
    [AutoBind]
    public class ProjectRepository : BaseRepository<Project, ProjectDto>, IProjectRepository
    {
        public ProjectRepository(ProjectManagementDbContext context, IMapper mapper) : base(context, mapper)
        {

        }
        public async Task<IEnumerable<ProjectDto>> GetAllActiveAsync()
        {
            return MapToEnumerableOfModel(await _dbSet.Where(p => !p.IsCompleted).ToListAsync());
        }

        public async System.Threading.Tasks.Task CompleteProjectAsync(int projectId)
        {
            var project = await GetByIdAsync(projectId);
            project.IsCompleted = true;
            await SaveAsync(project);
        }

    }
}
