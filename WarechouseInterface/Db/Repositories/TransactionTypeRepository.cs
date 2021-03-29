using System.Linq;
using WarechouseInterface.Repositories;

namespace WarechouseInterface.Db.Repositories
{
    public class TransactionTypeRepository
    {
        private readonly DatabaseContext _databaseContext;
        public TransactionTypeRepository(DatabaseContext context)
        {
            _databaseContext = context;
        }
        public int GetOrderType()
        {
            return _databaseContext.TransactionType.First(a => a.Name.Equals("ORDER")).Id;
        }

        public int GetSupplyType()
        {
            return _databaseContext.TransactionType.First(a => a.Name.Equals("SUPPLY")).Id;
        }

        public int GetReturnType()
        {
            return _databaseContext.TransactionType.First(a => a.Name.Equals("RETURN")).Id;
        }
    }
}
