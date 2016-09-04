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

        public Item Find(int receiptId, int productId)
        {
            //CHECK ProductId!!! JUNCTION table here
            return (from model in _db.Items where model.ProductId == productId && model.ReceiptId == receiptId select model).FirstOrDefault();
        }

        public void Update(Item model)
        {
            //CHECK ProductId!!! JUNCTION table here
            var orig = Find(model.ReceiptId, model.ProductId);

            // Add aditional updateable fields here
            orig.ReceiptId = model.ReceiptId;
            orig.ProductId = model.ProductId;
            orig.UnitsPurchased = model.UnitsPurchased;
            orig.Note = model.Note;
        }
    }
}
