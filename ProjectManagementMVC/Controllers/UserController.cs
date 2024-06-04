using ProjectManagementMVC.ViewModels;

namespace ProjectManagementMVC.Controllers
{
    public class UserController : BaseCrudController<UserDto, IUserRepository, IUsersService, UserEditVM, UserDetailsVM>
    {
        public UserController(IUsersService service, IMapper mapper) : base(service, mapper)
        {

        }
    }
}
