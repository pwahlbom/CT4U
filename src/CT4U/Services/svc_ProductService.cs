using CT4U.Infrastructure;
using CT4U.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CT4U.Services
{

    public class ProductService
    {
        private ProductRepository _repo;

        public ProductService(ProductRepository repo)
        {
            _repo = repo;
        }

        public IList<Product> GetProducts()
        {
            return _repo.List().ToList();
        }

        public Product FindProduct(int id)
        {
            return _repo.Find(id);
        }

        public void AddProduct(Product model)
        {
            _repo.Add(model);
            _repo.SaveChanges();
        }

        public void UpdateProduct(Product model)
        {
            _repo.Update(model);
            _repo.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var model = _repo.Find(id);
            _repo.Delete(model);
            _repo.SaveChanges();
        }
    }
}
