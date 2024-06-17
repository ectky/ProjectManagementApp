using ProjectManagement.Data.Entities;
using ProjectManagement.Data.Repos;
using ProjectManagement.Shared.Dtos;
using ProjectManagement.Test.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Tests.Repos
{
    public class UserRepositoryTests : BaseRepositoryTests<UserRepository, User, UserDto>
    {
    }
}
