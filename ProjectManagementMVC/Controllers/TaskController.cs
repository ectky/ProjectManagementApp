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
