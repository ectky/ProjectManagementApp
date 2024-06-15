using AutoMapper;
using ProjectManagement.Data.Entities;
using ProjectManagement.Shared.Dtos;
using ProjectManagement.Shared.Repos.Contacts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Shared;
using ProjectManagement.Shared.Attributes;
using Task = System.Threading.Tasks.Task;
using Microsoft.EntityFrameworkCore;

namespace ProjectManagement.Data.Repos
{
    [AutoBind]
    public class RoleRepository : BaseRepository<Role, RoleDto>, IRoleRepository
    {
        public RoleRepository(ProjectManagementDbContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public async Task<RoleDto> GetByNameIfExistsAsync(string roleName)
        {
            var role = await _context.Roles
                .FirstOrDefaultAsync(r => r.Name == roleName);

            return mapper.Map<RoleDto>(role);
        }
    }
}
