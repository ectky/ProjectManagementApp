using ProjectManagement.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Shared.Repos.Contacts
{
    public interface IProjectRepository : IBaseRepository<ProjectDto>
    {
        public Task<IEnumerable<ProjectDto>> GetAllActiveAsync();

        public Task CompleteProjectAsync(int projectId);

        public Task FilterProjectAsync(bool? isCompleted, DateTime? endDate, ProjectDto project);
    }
}
