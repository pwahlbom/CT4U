using CT4U.Models;
using System.Linq;

namespace CT4U.Infrastructure
{

    public class ProductRepository : GenericRepository<Product>
    {
        public ProductRepository(Data.ApplicationDbContext db) : base(db)
        {
        }

        public Product Find(int id)
        {
            return (from model in _db.Products where model.Id == id select model).FirstOrDefault();
        }

        public void Update(Product model)
        {
            var orig = Find(model.Id);

            // Add aditional updateable fields here
            orig.Name = model.Name;
            orig.MeasurementUnits = model.MeasurementUnits;
            orig.Notes = model.Notes;
        }
    }
}
