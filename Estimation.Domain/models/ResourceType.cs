﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Estimation.Domain.models
{
    
    public class ResourceType
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
       // public ApplicationUser ApplicationUser { get; set; }
    }
}
