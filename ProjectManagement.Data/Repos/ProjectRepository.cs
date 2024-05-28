using AutoMapper;
using ProjectManagement.Data.Entities;
using ProjectManagement.Shared.Dtos;
using ProjectManagement.Shared.Repos.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Data.Repos
{
    public class ProjectRepository : BaseRepository<Project, ProjectDto>, IProjectRepository
    {
        public ProjectRepository(ProjectManagementDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
