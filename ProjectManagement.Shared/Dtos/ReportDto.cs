using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Shared.Dtos
{
    public class ReportDto : BaseModel
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
