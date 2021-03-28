using WarechouseInterface.Db.DbDtos;
using WarechouseInterface.Repositories;

namespace WarechouseInterface.Db.Repositories
{
    public class TransactionRepository
    {
        private readonly DatabaseContext _databaseContext;
        public TransactionRepository(DatabaseContext context)
        {
            _databaseContext = context;
        }

        public int AddTransaction(int transactionType, string describe)
        {
            var transaction = new TransactionDbDto
            {
                TypId = transactionType,
                Describe = describe
            };

            _databaseContext.Transaction.Add(transaction);
            _databaseContext.SaveChanges();

            return transaction.Id;
        }
    }
}
