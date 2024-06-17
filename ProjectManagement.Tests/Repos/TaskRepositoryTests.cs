using ProjectManagement.Data.Entities;
using ProjectManagement.Data.Repos;
using ProjectManagement.Shared.Dtos;
using ProjectManagement.Test.Repos;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = ProjectManagement.Data.Entities.Task;

namespace ProjectManagement.Tests.Repos
{
    public class TaskRepositoryTests : BaseRepositoryTests<TaskRepository, Task, TaskDto>
    {
    }
}
