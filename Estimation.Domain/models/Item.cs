using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Estimation.Domain.models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string ItemDescription { get; set; }
        public string Description { get; set; }
        public string UOM { get; set; }
        public int EstimatedQuantity { get; set; }
        public int RevisedQuantity { get; set; }
        public int EstimatedUnitPrice { get; set; }
        public int EstimatedPrice { get; set; }
        public int BidUnitPrice { get; set; }
        public string ProductivtyFactor { get; set; }
        public string MHRFactor { get; set; }
        public string TotalMHR { get; set; }
        //public int Catagory_Id { get; set; }

        [ForeignKey("ResourceType")]
        public int ResourceTypeId { get; set; }
        public ResourceType ResourceType { get; set; }
        //public ApplicationUser ApplicationUser { get; set; }


    }
}
