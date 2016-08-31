using CT4U.Infrastructure;
using CT4U.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CT4U.Services
{

    public class UserService
    {
        private UserRepository _repo;

        public UserService(UserRepository repo)
        {
            _repo = repo;
        }

        public IList<ApplicationUser> GetUsers()
        {
            return _repo.List().ToList();
        }

        public ApplicationUser FindLoggedInUser(string UserName)
        {
            if (UserName.Length > 0)
            {
                var Users = _repo.List();
                return (from u in Users
                        where u.UserName == UserName
                        select u).FirstOrDefault();
            }
            else
            {
                return _repo.List().FirstOrDefault();
            }
        }

        public ApplicationUser FindUser(string id)
        {
            return _repo.Find(id);
        }

        public void AddUser(ApplicationUser value)
        {
            _repo.Add(value);
            _repo.SaveChanges();
        }

        public void UpdateUser(ApplicationUser value)
        {
            _repo.Update(value);
            _repo.SaveChanges();
        }

        public void DeleteUser(string id)
        {
            var value = _repo.Find(id);
            _repo.Delete(value);
            _repo.SaveChanges();
        }
    }
}
