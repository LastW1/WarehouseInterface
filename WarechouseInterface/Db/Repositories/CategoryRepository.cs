using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            // var warechouseId = int.Parse(ConfigurationManager.AppSettings.Get("ActualWarehouseId"));
            // dodać warechouse Id do category

            return _databaseContext.Category.Where(a=>true);
        }
    }
}
