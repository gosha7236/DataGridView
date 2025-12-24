using DataBase;
using Entities;
using Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class EFStorageManager : IStorageManager
    {
        public IReadOnlyCollection<Item> GetAll()
        {
            using var db = new AppDbContext();
            return db.Items
                     .AsNoTracking()
                     .ToList();
        }

        public void AddItem(Item item)
        {
            using var db = new AppDbContext();
            db.Items.Add(item);
            db.SaveChanges();
        }

        public void UpdateItem(Item item)
        {
            using var db = new AppDbContext();
            db.Items.Update(item);
            db.SaveChanges();
        }

        public void RemoveItem(Guid id)
        {
            using var db = new AppDbContext();
            var item = db.Items.FirstOrDefault(x => x.Id == id);
            if (item == null) return;

            db.Items.Remove(item);
            db.SaveChanges();
        }
    }
}
