using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Estimation.Domain.models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("BusinessUnit")]
        public int BusinessUnitId { get; set; }
        public BusinessUnit BusinessUnit { get; set; }

        [ForeignKey("CostCode")]
        public int CostCodeId { get; set; }
        public CostCode CostCode { get; set; }
        public int EstimatedPrice { get; set; }

        [ForeignKey("ProjectStatus")]
        public int ProjectStatusId { get; set; }
        public ProjectStatus ProjectStatus  { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int EstimatedDuration { get; set; }
        public string ClientName { get; set; }
        public string Location { get; set; }
        //public ApplicationUser ApplicationUser { get; set; }


    }
}
