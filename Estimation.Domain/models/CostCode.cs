using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Estimation.Domain.models
{
    public class CostCode
    {
        [Key]
        public int Id { get; set; }
        public string Value { get; set; }
        public string Level { get; set; }
        public string Catagory { get; set; }
        public string Description { get; set; }
        public string UOMMeasure { get; set; }
       // public ApplicationUser ApplicationUser { get; set; }

    }
}
