using ProjectManagement.Shared.Dtos;
using ProjectManagement.Shared.Repos.Contacts;
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
    public class RolesService : BaseCrudService<RoleDto, IRoleRepository>, IRolesService
    {
        private readonly IRoleRepository roleRepository;

        public RolesService(IRoleRepository roleRepository) : base(roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        public Task<RoleDto> GetByNameIfExistsAsync(string roleName)
        {
            return roleRepository.GetByNameIfExistsAsync(roleName);
        }
    }
}