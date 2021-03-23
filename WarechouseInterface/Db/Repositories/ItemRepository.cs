using System;
using System.Collections.Generic;
using System.Configuration;
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

        public ItemDbDto GetItemById(int itemId)
        {
            var warechouseId = int.Parse(ConfigurationManager.AppSettings.Get("ActualWarehouseId"));

            return _databaseContext.Item.FirstOrDefault(a => a.WarechouseId == warechouseId && a.Id == itemId);
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
            });
        }

        public IEnumerable<ItemDto> GetItemsByNameAndCategory(string category, string name)
        {
            var items = GetItems();

            if (category != null && !category.Equals(""))
            {
                items = items.Where(a => a.Category.ToLower().Contains(category.ToLower()));
            }
            if (name != null && !name.Equals(""))
            {
                items = items.Where(a => a.Name.ToLower().Contains(name.ToLower()));
            }

            return items;
        }

        public bool AddItem(ItemDbDto item)
        {
            var warechouseId = int.Parse(ConfigurationManager.AppSettings.Get("ActualWarehouseId"));
            item.WarechouseId = warechouseId;

            try
            {
                _databaseContext.Item.Add(item);
                _databaseContext.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public bool EditItem(ItemDbDto item, bool isImageEdited)
        {
            var dbItem = _databaseContext.Item.First(a => a.Id == item.Id);

            dbItem.CategoryId = item.CategoryId;
            dbItem.Name = item.Name;
            dbItem.Price = item.Price;
            dbItem.Count = item.Count;
            dbItem.Describe = item.Describe;
            dbItem.Location = item.Location;
            dbItem.AdditionalInfo = item.AdditionalInfo;
            dbItem.MinAllert = item.MinAllert;
            dbItem.MaxAllert = item.MaxAllert;

            if (isImageEdited)
            {
                dbItem.Picture = item.Picture;
            }

            try
            {
                _databaseContext.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public void RemoveItem(int itemId)
        {
            var item = _databaseContext.Item.First(a => a.Id == itemId);
            _databaseContext.Remove(item);
            _databaseContext.SaveChanges();
        }
    }
}
