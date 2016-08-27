using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTS.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MeasurementUnits{ get; set; }
        public string Notes { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}