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
        public Task<IEnumerable<ProjectDto>> GetAllActiveAsync()
        {
            return _repository.GetAllActiveAsync();
        }
        public async Task CompleteProjectAsync(int projectId )
        {
            
            if (!await ExistsByIdAsync(projectId))
            {
                throw new ArgumentException($"Project with ID {projectId} does not exist.");
            }
            await _repository.CompleteProjectAsync(projectId);
        }
    }
}