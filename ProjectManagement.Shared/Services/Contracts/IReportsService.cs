using ProjectManagement.Shared.Dtos;
using ProjectManagement.Shared.Repos.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Shared.Services.Contracts
{
    public interface IReportsService : IBaseCrudService<ReportDto, IReportRepository>
    {
    }
}
