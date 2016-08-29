using CT4U.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CT4U.Infrastructure
{
    public class ApplicationUserRepository : GenericRepository<ApplicationUser>
    {
        public ApplicationUserRepository(Data.ApplicationDbContext db) : base(db)
        {
        }

        public ApplicationUser Find(string id)
        {
            return (from model in _db.Users where model.Id == id select model).FirstOrDefault();
        }

        public void Update(ApplicationUser model)
        {
            var orig = Find(model.Id);

            // Add aditional updateable fields here
            orig.FirstName = model.FirstName;
            orig.LastName = model.LastName;
            orig.Nickname = model.Nickname;
            orig.Birthday = model.Birthday;

            orig.MailStreet1 = model.MailStreet1;
            orig.MailStreet2 = model.MailStreet2;
            orig.MailCity = model.MailCity;
            orig.MailState = model.MailState;
            orig.MailZip = model.MailZip;

            orig.PhysicalStreet1 = model.PhysicalStreet1;
            orig.PhysicalStreet2 = model.PhysicalStreet2;
            orig.PhysicalCity = model.PhysicalCity;
            orig.PhysicalState = model.PhysicalState;
            orig.PhysicalZip = model.PhysicalZip;
        }
    }
}