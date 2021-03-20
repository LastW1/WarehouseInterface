using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using WarechouseInterface.DbDtos;
using WarechouseInterface.Repositories;

namespace WarechouseInterface.Db.Repositories
{
    public class ItemRepository
    {
        private readonly DatabaseContext _databaseContext;
        public ItemRepository(DatabaseContext context)
        {
            _databaseContext = context;
        }

        public IEnumerable<ItemDbDto> GetItems()
        {
            var warechouseId = int.Parse(ConfigurationManager.AppSettings.Get("ActualWarehouseId"));

            return _databaseContext.Item.Where(a => a.WarechouseId == warechouseId);
        }

        public void SetImage()
        {
            var lol = File.ReadAllBytes(@"C:\Users\User\Desktop\yang.jpg");

            var item = _databaseContext.Item.FirstOrDefault(a => a.Id == 1);
            item.Picture = lol;
            _databaseContext.SaveChanges();
        }
    }
}
