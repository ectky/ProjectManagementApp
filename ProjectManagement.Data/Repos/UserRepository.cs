using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Data.Entities;
using ProjectManagement.Shared.Dtos;
using ProjectManagement.Shared.Repos.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Shared.Attributes;

namespace ProjectManagement.Data.Repos
{
    [AutoBind]
    public class UserRepository : BaseRepository<User, UserDto>, IUserRepository
    {
        public UserRepository(ProjectManagementDbContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public async Task<UserDto> GetByUsernameAsync(string username)
        {
            return MapToModel(await _dbSet.FirstOrDefaultAsync(u => u.Username == username));
        }

        

    }
}
