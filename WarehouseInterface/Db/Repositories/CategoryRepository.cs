using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using WarehouseInterface.Db.DbDtos;
using WarehouseInterface.Repositories;

namespace WarehouseInterface.Db.Repositories
{
    public class CategoryRepository
    {
        private readonly DatabaseContext _databaseContext;
        public CategoryRepository(DatabaseContext context)
        {
            _databaseContext = context;
        }

        public CategoryDbDto GetCategory(int categoryId)
        {

            return _databaseContext.Category.FirstOrDefault(a => a.Id == categoryId);
        }

        public IEnumerable<CategoryDbDto> GetCategories()
        {
            var warehouseId = int.Parse(ConfigurationManager.AppSettings.Get("ActualWarehouseId"));

            return _databaseContext.Category.Where(a => a.WarehouseId == warehouseId && a.DataK == null);
        }

        public IEnumerable<string> GetItemsAssignedToCategory(int categoryId)
        {
            return _databaseContext.Item.Where(a => a.CategoryId == categoryId && a.DataK == null).Select(a => a.Name);
        }

        public int? AddCategory(string categoryName)
        {
            if (_databaseContext.Category.Any(a => a.Name.ToLower().Equals(categoryName.ToLower())))
            {
                return null;
            }

            var warehouseId = int.Parse(ConfigurationManager.AppSettings.Get("ActualWarehouseId"));

            var category = new CategoryDbDto
            {
                Name = categoryName,
                WarehouseId = warehouseId
            };

            _databaseContext.Category.Add(category);
            _databaseContext.SaveChanges();

            return category.Id;
        }

        public void ChangeCategoryName(int categoryId, string name)
        {
            var category = GetCategory(categoryId);
            category.Name = name;

            _databaseContext.SaveChanges();
        }

        public void RemoveCategory(int categoryId)
        {
            var category = GetCategory(categoryId);
            category.DataK = DateTime.Now;
            _databaseContext.SaveChanges();
        }
    }
}
