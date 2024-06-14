using ProjectManagement.Shared.Dtos;

namespace ProjectManagement.Shared.Repos.Contacts
{
    public interface IReportProjectRepository : IBaseRepository<ReportProjectDto>
    {
        public  Task ReportProjectAsync(int userId, int projectId)
;

    }
}
