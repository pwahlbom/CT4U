using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CTS.Models
{
    public class Receipt
    {
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }

        public string ApplicationUserId { get; set; }

        public int Id { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string Note{ get; set; }
        public ICollection<Item> Items { get; set; }
    }
}