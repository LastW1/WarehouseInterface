using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using WarechouseInterface.Db.DbDtos;
using WarechouseInterface.Repositories;

namespace WarechouseInterface.Db.Repositories
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
            var warechouseId = int.Parse(ConfigurationManager.AppSettings.Get("ActualWarehouseId"));

            return _databaseContext.Category.Where(a => a.WarechouseId == warechouseId);
        }

        public int? AddCategory(string categoryName)
        {
            if (_databaseContext.Category.Any(a => a.Name.ToLower().Equals(categoryName.ToLower())))
            {
                return null;
            }

            var warechouseId = int.Parse(ConfigurationManager.AppSettings.Get("ActualWarehouseId"));

            var category = new CategoryDbDto
            {
                Name = categoryName,
                WarechouseId = warechouseId
            };

            _databaseContext.Category.Add(category);
            _databaseContext.SaveChanges();

            return category.Id;
        }
    }
}
