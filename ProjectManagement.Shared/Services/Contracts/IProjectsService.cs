using ProjectManagement.Shared.Dtos;
using ProjectManagement.Shared.Repos.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Shared.Attributes;

namespace ProjectManagement.Shared.Services.Contracts
{
    public interface IProjectsService : IBaseCrudService<ProjectDto, IProjectRepository>
    {
        public Task<IEnumerable<ProjectDto>> GetAllActiveAsync();

        public Task CompleteProjectAsync(int projectId);

        public Task FilterProjectAsync(bool? isCompleted, DateTime? endDate, ProjectDto project);
    }
}
