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
    public interface IUsersService : IBaseCrudService<UserDto, IUserRepository>
    {
        public Task<UserDto> GetByUsernameAsync(string username);
        public Task<bool> CanUserLoginAsync(string username, string password);


    }
}
