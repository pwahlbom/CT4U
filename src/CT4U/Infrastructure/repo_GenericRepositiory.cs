using CT4U.Data;
using CT4U.Models;
using System;
using System.Linq;

namespace CT4U.Infrastructure
{
    public class GenericRepository<T> : IDisposable where T : class
    {
        protected ApplicationDbContext _db;

        public GenericRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        // CREATE ----------------------------------------------------------------------------------------------------
        public void Add(T entity)
        {
            _db.Set<T>().Add(entity);
        }

        // READ ----------------------------------------------------------------------------------------------------
        public IQueryable<T> List()
        {
            return _db.Set<T>();
        }

        // Read the users table
        public IQueryable<ApplicationUser> GetUsers()
        {
            return _db.Users;
        }

        // DELETE ----------------------------------------------------------------------------------------------------
        public void Delete(T entity)
        {
            _db.Set<T>().Remove(entity);
        }

        // MISCELLANEOUS ----------------------------------------------------------------------------------------------------
        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}