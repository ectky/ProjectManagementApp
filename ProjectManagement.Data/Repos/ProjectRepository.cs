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
using Microsoft.Data.SqlClient;
using ProjectManagement.Shared.Services.Contracts;

namespace ProjectManagement.Data.Repos
{
    [AutoBind]
    public class ProjectRepository : BaseRepository<Project, ProjectDto>, IProjectRepository
    {
        private IUsersService _usersService;
        public ProjectRepository(ProjectManagementDbContext context, IMapper mapper, IUsersService _usersService) : base(context, mapper)
        {
            this._usersService = _usersService;
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
        public async Task<IEnumerable<ProjectDto>> FilterProjectAsync(int pageSize, int pageNumber)

        {

            var paginatedRecords = await _dbSet
                .Where(x => x.IsCompleted)
                .OrderBy(d => d.EndDate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return MapToEnumerableOfModel(paginatedRecords);
        }
        public async System.Threading.Tasks.Task AssignProjectAsync(int userId, int projectId)
        {
            var user = await _usersService.GetByIdIfExistsAsync(userId);
            user.ProjectId = projectId;
            await _usersService.SaveAsync(user);
        }


    }
}
