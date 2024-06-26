﻿using ProjectManagement.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Shared.Repos.Contacts
{
    public interface IUserRepository : IBaseRepository<UserDto>
    {
        public Task<UserDto> GetByUsernameAsync(string username);


    }
}
