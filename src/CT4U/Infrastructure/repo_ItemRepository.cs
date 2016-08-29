using CT4U.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CT4U.Infrastructure
{

    public class ItemRepository : GenericRepository<Item>
    {
        public ItemRepository(Data.ApplicationDbContext db) : base(db)
        {
        }

        public Item Find(int id)
        {
            return (from model in _db.Items where model.Id == id select model).FirstOrDefault();
        }

        public void Update(Item model)
        {
            var orig = Find(model.Id);

            // Add aditional updateable fields here
            orig.ReceiptId = model.ReceiptId;
            orig.ProductId = model.ProductId;
            orig.Id = model.Id;
            orig.UnitsPurchased = model.UnitsPurchased;
        }
    }
}
