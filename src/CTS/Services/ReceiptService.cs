using CTS.Infrastructure;
using CTS.Models;
using System.Collections.Generic;
using System.Linq;

namespace CTS.Services
{
    public class ReceiptService
    {
        private ReceiptRepository _repo;

        public ReceiptService(ReceiptRepository repo)
        {
            _repo = repo;
        }

        // CREATE ----------------------------------------------------------------------------------------------------
        public void AddReceipt(Receipt rcpt)
        {
            _repo.Add(rcpt);
            _repo.SaveChanges();
        }

        // READ ----------------------------------------------------------------------------------------------------
        // Read all
        public IList<Receipt> GetReceipts()
        {
            return _repo.List().ToList();
        }

        // Read one
        public Receipt FindReceipt(int id)
        {
            return _repo.Find(id);
        }

        // UPDATE ----------------------------------------------------------------------------------------------------
        public void UpdateReceipt(Receipt rcpt)
        {
            _repo.Update(rcpt);
            _repo.SaveChanges();
        }

        // DELETE ----------------------------------------------------------------------------------------------------
        public void DeleteReceipt(int id)
        {
            var rcpt = _repo.Find(id);
            _repo.Delete(rcpt);
            _repo.SaveChanges();
        }
    }
}