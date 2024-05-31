using ProjectManagement.Shared.Dtos;
using ProjectManagement.Shared.Repos.Contacts;
using ProjectManagement.Shared.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagament.Services
{
    public class ProjectsService : BaseCrudService<ProjectDto, IProjectRepository>, IProjectsService
    {
        public ProjectsService(IProjectRepository repository) : base(repository)
        {

        }
    }
}