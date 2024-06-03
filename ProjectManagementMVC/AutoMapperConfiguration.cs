using AutoMapper;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using ProjectManagement.Data.Entities;
using ProjectManagement.Shared.Dtos;
using ProjectManagementMVC.ViewModels;
using Task = ProjectManagement.Data.Entities.Task;

namespace ProjectManagementMVC
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Project, ProjectDto>().ReverseMap();
            CreateMap<ProjectDto, ProjectEditVM>().ReverseMap();
            CreateMap<ProjectDto, ProjectDetailsVM>().ReverseMap();
            CreateMap<Report, ReportDto>().ReverseMap();
            CreateMap<ReportDto, ReportEditVM>().ReverseMap();
            CreateMap<ReportDto, ReportDetailsVM>().ReverseMap();
            CreateMap<ReportProject, ReportProjectDto>().ReverseMap();
            CreateMap<ReportProjectDto, ReportProjectEditVM>().ReverseMap();
            CreateMap<ReportProjectDto, ReportProjectDetailsVM>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<RoleDto, RoleEditVM>().ReverseMap();
            CreateMap<RoleDto, RoleDetailsVM>().ReverseMap();
            CreateMap<Task, TaskDto>().ReverseMap();
            CreateMap<TaskDto, TaskEditVM>().ReverseMap();
            CreateMap<TaskDto, TaskDetailsVM>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserDto, UserEditVM>().ReverseMap();
            CreateMap<UserDto, UserDetailsVM>().ReverseMap();
            CreateMap<ChangePasswordDto, ChangePasswordVM>().ReverseMap();
            CreateMap<LoginDto, LoginVM>().ReverseMap();
            CreateMap<RegisterVM, UserDto>();
        }
    }
}
