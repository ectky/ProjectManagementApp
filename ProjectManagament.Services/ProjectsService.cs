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


        public Task<IEnumerable<ProjectDto>> FilterProjectAsync(int pageSize, int pageNumber)
        {
            return _repository.FilterProjectAsync(pageSize,pageNumber);
        }
        public Task<IEnumerable<ProjectDto>> GetAllActiveAsync()
        {
            return _repository.GetAllActiveAsync();
        }

        public async Task AssignProjectAsync(int userId, int projectId)
        {
            if (!await _userService.ExistsByIdAsync(userId))
            {
                throw new ArgumentException($"User with ID {userId} does not exist.");
            }
            if (!await ExistsByIdAsync(projectId))
            {
                throw new ArgumentException($"Project with ID {projectId} does not exist.");
            }

            await _repository.AssignProjectAsync(userId, projectId);
        }

    }
}