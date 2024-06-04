using ProjectManagementMVC.ViewModels;

namespace ProjectManagementMVC.Controllers
{
    public class RoleController : BaseCrudController<RoleDto, IRoleRepository, IRolesService, RoleEditVM, RoleDetailsVM>
    {
        public RoleController(IRolesService service, IMapper mapper) : base(service, mapper)
        {

        }
    }
}
