using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarechouseInterface.Db.Repositories;
using WarechouseInterface.Dtos;
using WarechouseInterface.Repositories;

namespace WarechouseInterface.Managers
{
    public class TransactionManager
    {
        private TransactionRepository _transactionRepository;
        private TransactionItemsRepository _transactionItemsRepository;
        private TransactionTypeRepository _transactionTypeRepository;
        private ItemRepository _itemRepository;
        public TransactionManager(DatabaseContext context)
        {
            _transactionRepository = new TransactionRepository(context);
            _transactionItemsRepository = new TransactionItemsRepository(context);
            _transactionTypeRepository = new TransactionTypeRepository(context);
            _itemRepository = new ItemRepository(context);
        }

        public void AddTransaction(FullTransactionDto transaction)
        {
            // odejmować liczbę produktów
            var transactionType = _transactionTypeRepository.GetOrderType();

            var transactionId = _transactionRepository.AddTransaction(transactionType , transaction.Describe);

            foreach(var transactionItem in transaction.Items)
            {
                _itemRepository.DecrementItem(transactionItem.ItemId, transactionItem.Count);

                transactionItem.TransactionId = transactionId;
                _transactionItemsRepository.AddItemForTransaction(transactionItem);
            }
        }
    }
}
