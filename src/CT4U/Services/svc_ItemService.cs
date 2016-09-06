using CT4U.Infrastructure;
using CT4U.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CT4U.Services
{
    public class ItemService
    {
        private ItemRepository _irepo;
        //private ProductRepository _prepo;

        public ItemService(ItemRepository irepo)
        {
            _irepo = irepo;
        }

        public IList<Item> GetItems()
        {
            return _irepo.List().ToList();
        }

        public Item FindItem(int productId, int receiptId)
        {
            return _irepo.Find(productId, receiptId);
        }

        public IList<ItemMore> GetReceiptsItems(int receiptId)
        {
            var items = _irepo.List();
            //var products = _prepo.List();

            return (from i in items
                    where i.ReceiptId == receiptId
                    select new ItemMore
                    {
                        Receipt = i.Receipt,
                        ReceiptId = i.ReceiptId,
                        Product = i.Product,
                        ProductId = i.ProductId,
                        UnitsPurchased = i.UnitsPurchased,
                        Note = i.Note,
                        ProductName = i.Product.Name,
                        MeasurementUnits = i.Product.MeasurementUnits
                    }).ToList();

            //return (from i in items
            //        join p in products
            //        on i.ProductId equals p.Id
            //        where i.ReceiptId == receiptId
            //        select new ItemMore
            //        {
            //            Receipt = i.Receipt,
            //            ReceiptId = i.ReceiptId,
            //            Product = i.Product,
            //            ProductId = i.ProductId,
            //            UnitsPurchased = i.UnitsPurchased,
            //            Note = i.Note,
            //            ProductName = p.Name,
            //            MeasurementUnits = p.MeasurementUnits
            //        }).ToList();
        }

        public void AddItem(Item model)
        {
            _irepo.Add(model);
            _irepo.SaveChanges();
        }

        public void UpdateItem(Item model)
        {
            _irepo.Update(model);
            _irepo.SaveChanges();
        }

        //public void DeleteItem(int receiptId, int productId)
        public void DeleteItem(int receiptid, int productId)
        {
            var orig = _irepo.Find(receiptid, productId);
            _irepo.Delete(orig);
            _irepo.SaveChanges();
        }
    }
}