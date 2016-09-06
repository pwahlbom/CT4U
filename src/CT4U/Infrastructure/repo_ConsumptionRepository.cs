using CT4U.Data;
using CT4U.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CT4U.Infrastructure
{

    public class ConsumptionRepository : GenericRepository<Consumption>
    {
        public ConsumptionRepository(ApplicationDbContext db) : base(db)
        {
        }

        public Consumption Find(string applicationuserid, int productid)
        {
            return (from model in _db.Consumptions where model.ApplicationUserId == applicationuserid && model.ProductId == productid select model).FirstOrDefault();
        }

        public void Update(Consumption model)
        {
            var orig = Find(model.ApplicationUserId, model.ProductId);

            // Customize field names as required
            orig.ApplicationUserId = model.ApplicationUserId;
            orig.ProductId = model.ProductId;

            orig.UnitsPurchased = model.UnitsPurchased;
            orig.UnitsConsumed = model.UnitsConsumed;
            orig.ConsumptionDays = model.ConsumptionDays;
            orig.ConsumptionRate = model.ConsumptionRate;

            orig.LastPurchaseDate = model.LastPurchaseDate;
            orig.LastPurchaseUnits = model.LastPurchaseUnits;
            orig.EmptyDate = model.EmptyDate;
            orig.DaysRemaining = model.DaysRemaining;
        }
    }
}