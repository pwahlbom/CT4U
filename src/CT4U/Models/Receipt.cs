using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CT4U.Models
{
    public class Receipt
    {
        // Primary key
        public int Id { get; set; }
       
        // Foreign keys
        [ForeignKey("ApplicationUserId")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        // Fields
        public DateTime PurchaseDate { get; set; }
        public string Note{ get; set; }

        // Foreign collections
        public ICollection<Item> Items { get; set; }
    }
}