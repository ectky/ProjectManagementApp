namespace ProjectManagementMVC.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Admin, Employee")]
    public class ProjectController : BaseCrudController<ProjectDto, IProjectRepository, IProjectsService, ProjectEditVM, ProjectDetailsVM>
    {
        public ProjectController(IProjectsService service, IMapper mapper) : base(service, mapper)
        {

        }
    }
}
