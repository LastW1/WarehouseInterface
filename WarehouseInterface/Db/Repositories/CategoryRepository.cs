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

        public IEnumerable<CategoryDbDto> GetCategories()
        {
            var warehouseId = int.Parse(ConfigurationManager.AppSettings.Get("ActualWarehouseId"));

            return _databaseContext.Category.Where(a => a.WarehouseId == warehouseId);
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
    }
}
