using CT4U.Models;
using System.Linq;

namespace CT4U.Infrastructure
{
    public class ReceiptRepository : GenericRepository<Receipt>
    {
        public ReceiptRepository(Data.ApplicationDbContext db) : base(db)
        {
        }

        // READ ----------------------------------------------------------------------------------------------------
        // Read one
        public Receipt Find(int id)
        {
            return (from r in _db.Receipts where r.Id == id select r).FirstOrDefault();
        }

        // UPDATE ----------------------------------------------------------------------------------------------------
        public void Update(Receipt rcpt)
        {
            var orig = Find(rcpt.Id);

            // Add aditional updateable fields here
            orig.PurchaseDate = rcpt.PurchaseDate;
            orig.Note = rcpt.Note;
        }
    }
}