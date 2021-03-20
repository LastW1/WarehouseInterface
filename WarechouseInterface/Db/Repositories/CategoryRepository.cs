using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarechouseInterface.Repositories;

namespace WarechouseInterface.Db.Repositories
{
    class CategoryRepository
    {
        private readonly DatabaseContext _databaseContext;
        public CategoryRepository(DatabaseContext context)
        {
            _databaseContext = context;
        }
    }
}
