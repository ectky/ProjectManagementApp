using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
using ProjectManagement.Shared;
using ProjectManagement.Shared.Dtos;
using ProjectManagement.Shared.Enums;
using ProjectManagement.Shared.Repos.Contacts;
using ProjectManagement.Shared.Services.Contracts;
using ProjectManagementMVC.ViewModels;
using System.Security.Claims;

namespace ProjectManagementMVC.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Admin, Employee, Manager")]
    public class ProjectController : BaseCrudController<ProjectDto, IProjectRepository, IProjectsService, ProjectEditVM, ProjectDetailsVM>
    {
        public IUsersService _usersService { get; set; }
        public ProjectController(IProjectsService service, IUsersService _usersService, IMapper mapper) : base(service, mapper)
        {

        }

        protected virtual async Task<CompleteProjectEditVM> PrePopulateVMAsync(CompleteProjectEditVM editVM)
        {

            editVM.ProjectList = (await _service.GetAllActiveAsync()).Select(x => new SelectListItem($"{x.Name}", x.Id.ToString()));

            return editVM;
        }

        [HttpGet]
        public async Task<IActionResult> CompleteProjectAsync()
        {
            var editVM = await PrePopulateVMAsync(new CompleteProjectEditVM());
            return View(editVM);
        }
        [HttpPost]
        public async Task<IActionResult> CompleteProjectAsync(CompleteProjectEditVM editVM)
        {
            string loggedUsername = User.FindFirst(ClaimTypes.Name)?.Value;

            await this._service.CompleteProjectAsync(editVM.ProjectId);
            return await List();
        }

        [HttpGet]
        public async Task<IActionResult> FilterProjectAsync()
        {
            var editVM = await _service.FilterProjectAsync()
        }

    }
}
