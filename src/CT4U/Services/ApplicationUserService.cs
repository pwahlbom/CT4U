using CT4U.Infrastructure;
using CT4U.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CT4U.Services
{

    public class ApplicationUserService
    {
        private ApplicationUserRepository _repo;

        public ApplicationUserService(ApplicationUserRepository repo)
        {
            _repo = repo;
        }

        public IList<ApplicationUser> GetApplicationUsers()
        {
            return _repo.List().ToList();
        }

        public ApplicationUser FindApplicationUser(string id)
        {
            return _repo.Find(id);
        }

        public void AddApplicationUser(ApplicationUser value)
        {
            _repo.Add(value);
            _repo.SaveChanges();
        }

        public void UpdateApplicationUser(ApplicationUser value)
        {
            _repo.Update(value);
            _repo.SaveChanges();
        }

        public void DeleteApplicationUser(string id)
        {
            var value = _repo.Find(id);
            _repo.Delete(value);
            _repo.SaveChanges();
        }
    }
}
