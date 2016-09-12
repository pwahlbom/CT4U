using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CT4U.Models
{
    public class Item
    {
        // Primary key
        // Foreign keys
        // this table is junction table with a compound primary key
        [ForeignKey("ReceiptId")]
        public int ReceiptId { get; set; }
        public Receipt Receipt { get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        // Fields
        public decimal UnitsPurchased { get; set; }
        public string Note { get; set; }

        // Foreign collections
        // none
    }

    public class ItemMore : Item
    {
        public string ProductName { get; set; }
        public string MeasurementUnits { get; set; }
    }
}