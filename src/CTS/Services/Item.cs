using CTS.Infrastructure;
using CTS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTS.Services
{
    public class ItemService
    {
        private ItemRepository _repo;

        public ItemService(ItemRepository repo)
        {
            _repo = repo;
        }

        public IList<Item> GetItems()
        {
            return _repo.List().ToList();
        }

        public Item FindItem(int id)
        {
            return _repo.Find(id);
        }

        public void AddItem(Item value)
        {
            _repo.Add(value);
            _repo.SaveChanges();
        }

        public void UpdateItem(Item value)
        {
            _repo.Update(value);
            _repo.SaveChanges();
        }

        public void DeleteItem(int id)
        {
            var value = _repo.Find(id);
            _repo.Delete(value);
            _repo.SaveChanges();
        }
    }
}
