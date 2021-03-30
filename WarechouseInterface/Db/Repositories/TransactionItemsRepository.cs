using System.Collections.Generic;
using System.Linq;
using WarechouseInterface.Db.DbDtos;
using WarechouseInterface.Repositories;

namespace WarechouseInterface.Db.Repositories
{
    class TransactionItemsRepository
    {
        private readonly DatabaseContext _databaseContext;
        public TransactionItemsRepository(DatabaseContext contex)
        {
            _databaseContext = contex;
        }

        public IEnumerable<TransactionItemsDbDto> GetItem(int itemId)
        {
            return _databaseContext.TransactionItem.Where(a => a.ItemId == itemId);
        }
        public IEnumerable<TransactionItemsDbDto> GetTransactionItems(int transactionId)
        {
            return _databaseContext.TransactionItem.Where(a => a.TransactionId == transactionId);
        }
        public void AddItemForTransaction(TransactionItemsDbDto item)
        {
            _databaseContext.TransactionItem.Add(item);
            _databaseContext.SaveChanges();
        }
    }
}
