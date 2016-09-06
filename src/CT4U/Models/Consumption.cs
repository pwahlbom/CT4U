using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CT4U.Models
{
    public class Consumption
    {
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int ProductId { get; set; }

        public decimal UnitsPurchased { get; set; }
        public decimal UnitsConsumed { get; set; }
        public decimal ConsumptionDays { get; set; }
        public decimal ConsumptionRate { get; set; }

        public DateTime LastPurchaseDate { get; set; }
        public decimal LastPurchaseUnits { get; set; }
        public DateTime EmptyDate { get; set; }
        public decimal DaysRemaining { get; set; }
    }

    public class ConsumptionMore : Consumption
    {
        public string ProductName { get; set; }
    }
}
