using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Services;
using ProjectManagement.Shared;
using ProjectManagement.Shared.Dtos;
using ProjectManagement.Shared.Security;
using ProjectManagement.Shared.Services.Contracts;
using ProjectManagementMVC.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace ProjectManagementMVC.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly IUsersService usersService;
        private readonly IRolesService rolesService;
        private readonly IMapper mapper;

        public AuthController(
            IUsersService usersService,
            IRolesService rolesService,
            IMapper mapper)
        {
            this.usersService = usersService;
            this.rolesService = rolesService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginVM model)
        {
            string loggedUsername = User.FindFirst(ClaimTypes.Name)?.Value;

            if (loggedUsername != null)
            {
                return Forbid();
            }

            if (!await this.usersService.CanUserLoginAsync(model.Username, model.Password))
            {
                return BadRequest(Constants.InvalidCredentials);
            }

            await LoginUser(model.Username);

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public async Task<IActionResult> LoginUser(string username)
        {
            var user = await this.usersService.GetByUsernameAsync(username);

            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    user.Role != null ? new Claim(ClaimTypes.Role, user.Role.Name) : null
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    principal);

                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            else
            {
                return BadRequest(Constants.UserNotFound);
            }
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm] RegisterVM userCreateModel)
        {
            string loggedUsername = User.FindFirst(ClaimTypes.Name)?.Value;

            if (loggedUsername != null)
            {
                return Forbid();
            }

            if (await this.usersService.GetByUsernameAsync(userCreateModel.Username) != default)
            {
                return BadRequest(Constants.UserAlreadyExists);

            }

            var hashedPassword = PasswordHasher.HashPassword(userCreateModel.Password);
            userCreateModel.Password = hashedPassword;

            var userDto = this.mapper.Map<UserDto>(userCreateModel);
            var roleId = (await rolesService.GetByNameIfExistsAsync(UserRole.Employee.ToString()))?.Id;
            if (roleId != null)
            {
                userDto.RoleId = roleId.Value;
            }
            else
            {
                return BadRequest(Constants.RoleDoesNotExists);
            }

            await LoginUser(userDto.Username);

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            string loggedUsername = User.FindFirst(ClaimTypes.Name)?.Value;

            if (loggedUsername != null)
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }


            return RedirectToAction(nameof(HomeController.Index), "Home");

        }

        [HttpGet]
        public IActionResult ConfirmLogout()
        {
            return View();
        }
    }
}
