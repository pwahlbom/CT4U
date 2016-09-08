using CT4U.Infrastructure;
using CT4U.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CT4U.Services
{

    public class ConsumptionService
    {
        private ConsumptionRepository _crepo;
        private ReceiptRepository _rrepo;
        private ItemRepository _irepo;
        
        public ConsumptionService(ConsumptionRepository crepo, ReceiptRepository rrepo, ItemRepository irepo)
        {
            _crepo = crepo;
            _rrepo = rrepo;
            _irepo = irepo;
        }

        // CREATE ----------------------------------------------------------------------------------------------------
        public void AddConsumption(Consumption model)
        {
            _crepo.Add(model);
            _crepo.SaveChanges();
        }

        // READ ----------------------------------------------------------------------------------------------------
        // Read all
        public IList<Consumption> GetConsumptions()
        {
            return _crepo.List().ToList();
        }

        // Read one
        public Consumption FindConsumption(string username, int productid)
        {
            var UserId = _rrepo.GetUser(username).Id;
            return _crepo.Find(UserId, productid);
        }

        // UPDATE ----------------------------------------------------------------------------------------------------
        public void UpdateConsumption(Consumption model)
        {
            _crepo.Update(model);
            _crepo.SaveChanges();
        }

        // DELETE ----------------------------------------------------------------------------------------------------
        public void DeleteConsumption(string username, int productid)
        {
            var UserId = _rrepo.GetUser(username).Id;

            var model = _crepo.Find(UserId, productid);
            _crepo.Delete(model);
            _crepo.SaveChanges();
        }

        // MISCELLANEOUS ----------------------------------------------------------------------------------------------------
        public IList<ConsumptionMore> GetUsersConsumptions(string UserName)
        {
            var consumptions = _crepo.List();

            return (from c 
                    in consumptions
                    where c.ApplicationUser.UserName == UserName
                    select  new ConsumptionMore
                    {
                        ApplicationUserId = c.ApplicationUserId,
                        ProductId = c.ProductId,
                        ProductName = c.Product.Name,

                        UnitsPurchased = c.UnitsPurchased,
                        UnitsConsumed = c.UnitsConsumed,
                        ConsumptionDays = c.ConsumptionDays,
                        ConsumptionRate = c.ConsumptionRate,

                        LastPurchaseDate = c.LastPurchaseDate,
                        LastPurchaseUnits = c.LastPurchaseUnits,
                        EmptyDate = c.EmptyDate,
                        DaysRemaining = c.DaysRemaining
                    }).ToList();

        }

        public void AddUsersConsumptions(string username)
        {
            var receipts = _rrepo.List().ToList();
            var items = _irepo.List().ToList();
            var receiptid = 0;
            var productid = 0;
            var UserId = _rrepo.GetUser(username).Id;

            // Loop through the reciepts and find all the receipts for this userid
            foreach (var receipt in receipts)
            {
                if (receipt.ApplicationUserId == UserId)
                {
                    receiptid = receipt.Id;

                    // Loop through the items and find all the items for this itemid
                    foreach (var item in items)
                    {
                        // Only consider items belonging to this receipt
                        if (item.ReceiptId == receiptid)
                        {
                            productid = item.ProductId;

                            // See if there is alread a consumption in the Db for this userid / productid key
                            var WorkingConsumption = _crepo.Find(UserId, productid);

                            // If we didn't return a Consumption with that Uid / Pid key, then we need to create one
                            // Otherwise, we'll do some checks and update the existing Consumption in the else below
                            if (WorkingConsumption == null)
                            {
                                var emptydate = Convert.ToDateTime("7/7/7777");

                                WorkingConsumption = new Consumption
                                {
                                    ApplicationUserId = UserId,
                                    ProductId = item.ProductId,
                                    UnitsPurchased = item.UnitsPurchased,
                                    UnitsConsumed = 0,
                                    ConsumptionDays = 0,
                                    ConsumptionRate = 0,

                                    LastPurchaseDate = item.Receipt.PurchaseDate,
                                    LastPurchaseUnits = item.UnitsPurchased,
                                    EmptyDate = emptydate,
                                    DaysRemaining = Convert.ToDecimal((emptydate - DateTime.Now).TotalDays)
                                };

                                // Add the new Consumption and drive on...
                                _crepo.Add(WorkingConsumption);
                                _crepo.SaveChanges();
                            }
                            else
                            {

                                WorkingConsumption.UnitsPurchased = WorkingConsumption.UnitsPurchased + item.UnitsPurchased;

                                // Item is newer than WorkingConsumption
                                if (item.Receipt.PurchaseDate > WorkingConsumption.LastPurchaseDate)
                                {
                                    WorkingConsumption.UnitsConsumed = WorkingConsumption.UnitsConsumed + WorkingConsumption.LastPurchaseUnits;
                                    WorkingConsumption.ConsumptionDays = Convert.ToDecimal((item.Receipt.PurchaseDate - WorkingConsumption.LastPurchaseDate).TotalDays) + WorkingConsumption.ConsumptionDays;
                                    WorkingConsumption.ConsumptionRate = WorkingConsumption.UnitsConsumed / WorkingConsumption.ConsumptionDays;

                                    WorkingConsumption.LastPurchaseDate = item.Receipt.PurchaseDate;
                                    WorkingConsumption.LastPurchaseUnits = item.UnitsPurchased;
                                }

                                // WorkingConsumption is newer than Item
                                if (WorkingConsumption.LastPurchaseDate > item.Receipt.PurchaseDate)
                                {
                                    WorkingConsumption.UnitsConsumed = WorkingConsumption.UnitsConsumed + item.UnitsPurchased;
                                    WorkingConsumption.ConsumptionDays = Convert.ToDecimal((WorkingConsumption.LastPurchaseDate - item.Receipt.PurchaseDate).TotalDays);
                                    WorkingConsumption.ConsumptionRate = WorkingConsumption.UnitsConsumed / WorkingConsumption.ConsumptionDays;

                                    WorkingConsumption.LastPurchaseDate = WorkingConsumption.LastPurchaseDate;
                                    WorkingConsumption.LastPurchaseUnits = WorkingConsumption.LastPurchaseUnits;
                                }

                                WorkingConsumption.EmptyDate = WorkingConsumption.LastPurchaseDate.AddDays(Convert.ToDouble(WorkingConsumption.LastPurchaseUnits / WorkingConsumption.ConsumptionRate));
                                WorkingConsumption.DaysRemaining = Convert.ToDecimal((WorkingConsumption.EmptyDate - DateTime.Now).TotalDays);

                                // Update the existing Consumption and drive on
                                _crepo.Update(WorkingConsumption);
                                _crepo.SaveChanges();
                            }
                        }
                    }
                }
            }
        }

        public void DeleteUsersConsumptions(string username)
        {
            var UserId = _rrepo.GetUser(username).Id;

            // Loop through the consumptions table a delete each of the logged user's consumptions
            var usersconsumptions = _crepo.List().ToList();

            foreach (var consumption in usersconsumptions)
            {
                if (consumption.ApplicationUserId == UserId)
                {
                    _crepo.Delete(consumption);
                    _crepo.SaveChanges();
                }
            }
        }
    }
}