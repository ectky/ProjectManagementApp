﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Data.Entities
{
    public class Role : BaseEntity
    {
        public Role()
        {
            this.Users = new List<BaseEntity>();
        }
        public string Name {  get; set; }

        public virtual List<BaseEntity> Users { get; set; }
    }
}
