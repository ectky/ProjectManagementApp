using ProjectManagement.Shared.Dtos;
using ProjectManagement.Shared.Repos.Contacts;
using ProjectManagement.Shared.Security;
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
    public class UsersService : BaseCrudService<UserDto, IUserRepository>, IUsersService
    {
        private readonly IUserRepository userRepository;

        public UsersService(IUserRepository repository) : base(repository)
        {
            userRepository = repository;
        }

        public async Task<bool> CanUserLoginAsync(string username, string password)
        {
            var user = await _repository.GetByUsernameAsync(username);

            if (user == null)
            {
                return false;
            }

            bool passwordMatches = PasswordHasher.VerifyPassword(password, user.Password);

            return passwordMatches;
        }

        public async Task<UserDto> GetByUsernameAsync(string username)
        {
            return await userRepository.GetByUsernameAsync(username);
        }
    }
}