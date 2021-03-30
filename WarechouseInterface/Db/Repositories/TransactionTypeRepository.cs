using System.Collections.Generic;
using System.Linq;
using WarechouseInterface.Repositories;

namespace WarechouseInterface.Db.Repositories
{
    public class TransactionTypeRepository
    {
        private readonly DatabaseContext _databaseContext;

        private readonly Dictionary<string, string> TransactionTypeDict = new Dictionary<string, string>
        {
            {"ORDER","Zamówienie"},
            {"SUPPLY", "Dostawa"},
            {"RETURN", "Zwrot" }
        };

        public TransactionTypeRepository(DatabaseContext context)
        {
            _databaseContext = context;
        }

        public string GetStringByTypeId(int typId)
        {
            return TransactionTypeDict.First(dict=>dict.Key == _databaseContext.TransactionType.First(a => a.Id == typId).Name).Value;
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
