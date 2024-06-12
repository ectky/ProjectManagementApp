using ProjectManagement.Shared.Dtos;
using ProjectManagement.Shared.Repos.Contacts;
using ProjectManagement.Shared.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Shared.Attributes;

namespace ProjectManagement.Services
{
    [AutoBind]
    public class ProjectsService : BaseCrudService<ProjectDto, IProjectRepository>, IProjectsService
    {
        public IUsersService _userService { get; set; }

        public ProjectsService(IProjectRepository repository, IUsersService userService) : base(repository)
        {
            this._userService = userService;
        }
       
        public async Task CompleteProjectAsync(int projectId )
        {
            
            if (!await ExistsByIdAsync(projectId))
            {
                throw new ArgumentException($"Project with ID {projectId} does not exist.");
            }
            await _repository.CompleteProjectAsync(projectId);
        }

       
        public async System.Threading.Tasks.Task FilterProjectAsync(bool? isCompleted, DateTime? endDate, ProjectDto project)
        {
            var filteredProjects = await GetAllAsync();

            if (isCompleted.HasValue)
            {
                filteredProjects.Where(p => p.IsCompleted == isCompleted.Value).ToList();
            }
            if (endDate.HasValue)
            {
                filteredProjects.Where(p => p.EndDate <= endDate.Value);
            }
        }
        public Task<IEnumerable<ProjectDto>> GetAllActiveAsync()
        {
            return _repository.GetAllActiveAsync();
        }
    }
}