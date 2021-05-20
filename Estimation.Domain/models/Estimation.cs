using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estimation.Domain.models
{
    public class EstimationProject
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        [ForeignKey("Descipline")]
        public int DesciplineId { get; set; }
        public Descipline Descipline { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }
        public string MHRFactor{get;set;}
        public string TotalMHR { get; set; }
        public string EstimatedHourRate { get; set; }

        [ForeignKey("CostCode")]
        public int CostCodeId { get; set; }
        public CostCode CostCode { get; set; }
        public double Rounded { get; set; }
        public double Contingency { get; set; }
        //public ApplicationUser ApplicationUser { get; set; }


    }
}
