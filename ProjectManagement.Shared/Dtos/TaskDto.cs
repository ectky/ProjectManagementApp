﻿using Microsoft.Build.Evaluation;
using ProjectManagement.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Shared.Dtos
{
    public class TaskDto : BaseModel
    {
        
        public string Description { get; set; }
        public string Name { get; set; }
        public Status Status { get; set; }
        public DateTime? Deadline { get; set; }

        public int ProjectId { get; set; }
        public ProjectDto Project { get; set; }
        public int UserId { get; set; }

        public  UserDto User { get; set; }
    }
}
