using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CT4U.Models
{
    public class Item
    {
        [ForeignKey("ReceiptId")]
        public Receipt Receipt { get; set; }
        public int ReceiptId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int ProductId { get; set; }

        public decimal UnitsPurchased { get; set; }
        public string Note { get; set; }
    }

    public class ItemMore : Item
    {
        public string ProductName { get; set; }
        public string MeasurementUnits { get; set; }
    }
}