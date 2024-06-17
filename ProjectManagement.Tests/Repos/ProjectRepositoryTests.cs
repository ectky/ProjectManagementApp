using Microsoft.CodeAnalysis.Elfie.Serialization;
using ProjectManagement.Shared.Dtos;
using ProjectManagement.Test.Repos;
using ProjectManagement.Data.Repos;
using ProjectManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Tests.Repos
{
    public class ProjectRepositoryTests : BaseRepositoryTests<ProjectRepository, Project, ProjectDto>
    {
    }
}
