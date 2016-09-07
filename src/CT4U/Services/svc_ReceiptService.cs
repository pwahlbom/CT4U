using CT4U.Infrastructure;
using CT4U.Models;
using System.Collections.Generic;
using System.Linq;

namespace CT4U.Services
{
    public class ReceiptService
    {
        private ReceiptRepository _repo;

        public ReceiptService(ReceiptRepository repo)
        {
            _repo = repo;
        }

        // CREATE ----------------------------------------------------------------------------------------------------
        public void AddReceipt(Receipt rcpt, string username)
        {
            var UserId = _repo.GetUser(username).Id;
            rcpt.ApplicationUserId = UserId;
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

        // MISCELLANEOUS ----------------------------------------------------------------------------------------------------
        public IList<Receipt> GetUsersReceipts(string username)
        {
            var receipts = _repo.List();
            return (from r in receipts
                    where r.ApplicationUser.UserName == username
                    select r).ToList();
        }
    }
}