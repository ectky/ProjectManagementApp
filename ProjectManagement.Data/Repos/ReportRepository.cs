﻿using AutoMapper;
using ProjectManagement.Data.Entities;
using ProjectManagement.Shared.Dtos;
using ProjectManagement.Shared.Repos.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Shared.Attributes;

namespace ProjectManagement.Data.Repos
{
    [AutoBind]
    public class ReportRepository : BaseRepository<Report, ReportDto>, IReportRepository
    {
        public ReportRepository(ProjectManagementDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
