using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using WarechouseInterface.Db.DbDtos;
using WarechouseInterface.Dtos;
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

        public IEnumerable<ItemDto> GetItems()
        {
            var warechouseId = int.Parse(ConfigurationManager.AppSettings.Get("ActualWarehouseId"));

            var wtf = _databaseContext.Item.Where(a => a.WarechouseId == warechouseId).ToList();
            return _databaseContext.Item.Where(a => a.WarechouseId == warechouseId).Select(a => new ItemDto
            {
                Id = a.Id,
                Category = _databaseContext.Category.FirstOrDefault(c => c.Id == a.CategoryId).Name,
                Picture = a.Picture,
                Name = a.Name,
                Price = a.Price,
                Count = a.Count,
                Describe = a.Describe,
                Location = a.Location,
                AdditionalInfo = a.AdditionalInfo,
                MinAllert = a.MinAllert,
                MaxAllert = a.MaxAllert
            }); //gdy image jest null ładowac jakieś default zdjęcie
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
