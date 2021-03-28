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

        public void AddItemForTransaction(TransactionItemsDbDto item)
        {
            _databaseContext.TransactionItem.Add(item);
            _databaseContext.SaveChanges();
        }
    }
}
