﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public bool IsDeleted { get; set; }
    }
}
