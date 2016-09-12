using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CT4U.Models
{
    public class Product
    {
        // Primary key
        public int Id { get; set; }

        // Foreign keys
        // none

        // Fields
        public string Name { get; set; }
        public string MeasurementUnits{ get; set; }
        public string Note { get; set; }

        // Foreign collections
        public ICollection<Item> Items { get; set; }
        public ICollection<Consumption> Consumptions { get; set; }
    }
}