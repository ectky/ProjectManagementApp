using AutoMapper;
using ProjectManagement.Shared.Dtos;
using ProjectManagement.Shared.Repos.Contacts;
using ProjectManagement.Shared.Services.Contracts;
using ProjectManagementMVC.ViewModels;

namespace ProjectManagementMVC.Controllers
{
    public class TaskController : BaseCrudController<TaskDto, ITaskRepository, ITasksService, TaskEditVM, TaskDetailsVM>
    {
        public TaskController(ITasksService service, IMapper mapper) : base(service, mapper)
        {

        }
    }
}
