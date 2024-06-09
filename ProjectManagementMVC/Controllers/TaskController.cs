using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Data.Entities;
using ProjectManagement.Shared;
using ProjectManagement.Shared.Dtos;
using ProjectManagement.Shared.Enums;
using ProjectManagement.Shared.Repos.Contacts;
using ProjectManagement.Shared.Services.Contracts;
using ProjectManagementMVC.ViewModels;
using System.Data;
using System.Linq;
using System.Reflection.Emit;

namespace ProjectManagementMVC.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Admin, Employee, Manager")]
    public class TaskController : BaseCrudController<TaskDto, ITaskRepository, ITasksService, TaskEditVM, TaskDetailsVM>
    {
        public IProjectsService _projectsService { get; set; }
        public ITaskRepository _taskRepository { get; set; }
        public TaskController(ITasksService service, IProjectsService _projectsService, ITaskRepository _taskRepository, IMapper mapper) : base(service, mapper)
        {
            this._projectsService = _projectsService;
            this._taskRepository = _taskRepository;
        }
        protected override Task<TaskEditVM> PrePopulateVMAsync(TaskEditVM editVM)
        {
            editVM.StatusList = Enum.GetValues(typeof(Status)).Cast<Status>().Select(s => new SelectListItem(s.ToString(), ((int)s).ToString()));


            return System.Threading.Tasks.Task.FromResult(editVM);
        }

    }
}
