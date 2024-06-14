using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
using ProjectManagement.Services;
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
        public IReportProjectsService _reportProjectsService { get; set; }
        public IReportsService _reportsService { get; set; }
        public ProjectController(IProjectsService service, IUsersService _usersService, IReportProjectsService _reportProjectsService, IReportsService _reportsService, IMapper mapper) : base(service, mapper)
        {
            this._reportProjectsService = _reportProjectsService;
            this._usersService = _usersService;
            this._reportsService = _reportsService;
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

            await this._service.CompleteProjectAsync(editVM.ProjectId);
            return await List();
        }


        [HttpGet]
        public async Task<IActionResult> FilterProjectAsync(int pageSize = DefaultPageSize,
            int pageNumber = DefaultPageNumber)
        {
            if (pageSize <= 0 || pageSize > MaxPageSize || pageNumber <= 0)
            {
                return BadRequest(Constants.InvalidPagination);
            }
            var models = await this._service.FilterProjectAsync(pageSize, pageNumber);
            var mappedModels = _mapper.Map<IEnumerable<ProjectDetailsVM>>(models);
            return View(nameof(List), mappedModels);
        }

        protected virtual async Task<ReportProjectEditVM> PrePopulateVMAsync(ReportProjectEditVM editVM)
        {

            editVM.Reports = (await _reportsService.GetAllAsync()).Select(x => new SelectListItem($"{x.Name}", x.Id.ToString()));
            editVM.Projects = (await _service.GetAllAsync()).Select(x => new SelectListItem($"{x.Name}", x.Id.ToString()));
            return editVM;
        }
        [HttpGet]
        public async Task<IActionResult> ReportProjectAsync()
        {
            var editVM = await PrePopulateVMAsync(new ReportProjectEditVM());
            return View(editVM);
        }
        [HttpPost]
        public async Task<IActionResult> ReportProjectAsync(ReportProjectEditVM editVM)
        {
            string loggedUsername = User.FindFirst(ClaimTypes.Name)?.Value;
            var user = await this._usersService.GetByUsernameAsync(loggedUsername);
            await this._reportProjectsService.ReportProjectAsync(editVM.ReportId, editVM.ProjectId);
            return await List();
        }


        protected virtual async Task<AssignProjectEditVM> PrePopulateVMAsync(AssignProjectEditVM editVM)
        {

            editVM.ProjectList = (await _service.GetAllActiveAsync()).Select(x => new SelectListItem($"{x.Name}", x.Id.ToString()));

            return editVM;
        }
        [HttpGet]
        public async Task<IActionResult> AssignProjectAsync()
        {
            var editVM = await PrePopulateVMAsync(new AssignProjectEditVM());
            return View(editVM);
        }
        [HttpPost]
        public async Task<IActionResult> AssignProjectAsync(AssignProjectEditVM editVM)
        {
            string loggedUsername = User.FindFirst(ClaimTypes.Name)?.Value;
            var user = await this._usersService.GetByUsernameAsync(loggedUsername);
            await this._service.AssignProjectAsync(user.Id, editVM.ProjectId);
            return await List();
        }


    }

}

