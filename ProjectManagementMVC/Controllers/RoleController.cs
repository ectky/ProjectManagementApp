using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using ProjectManagement.Shared.Dtos;
using ProjectManagement.Shared.Repos.Contacts;
using ProjectManagement.Shared.Services.Contracts;
using ProjectManagementMVC.ViewModels;

namespace ProjectManagementMVC.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Admin, Employee")]
    public class RoleController : BaseCrudController<RoleDto, IRoleRepository, IRolesService, RoleEditVM, RoleDetailsVM>
    {
        public RoleController(IRolesService service, IMapper mapper) : base(service, mapper)
        {

        }
    }
}
