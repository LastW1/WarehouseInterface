using System.Collections.Generic;
using System.Linq;
using WarehouseInterface.Db.Repositories;
using WarehouseInterface.Dtos;
using WarehouseInterface.Repositories;

namespace WarehouseInterface.Managers
{
    public class TransactionManager
    {
        private TransactionRepository _transactionRepository;
        private TransactionItemsRepository _transactionItemsRepository;
        private TransactionTypeRepository _transactionTypeRepository;
        private ItemRepository _itemRepository;
        private CategoryRepository _categoryRepository;
        public TransactionManager(DatabaseContext context)
        {
            _transactionRepository = new TransactionRepository(context);
            _transactionItemsRepository = new TransactionItemsRepository(context);
            _transactionTypeRepository = new TransactionTypeRepository(context);
            _itemRepository = new ItemRepository(context);
            _categoryRepository = new CategoryRepository(context);
        }

        public IEnumerable<TransactionItemViewDto> GetItemsForTransaction(int transactionId)
        {
            var transactionitems = _transactionItemsRepository.GetTransactionItems(transactionId);

            var result = new List<TransactionItemViewDto>();

            foreach (var transactionitem in transactionitems)
            {
                var item = _itemRepository.GetItemById(transactionitem.ItemId);

                result.Add(new TransactionItemViewDto
                {
                    ItemId = item.Id,
                    Name = item.Name,
                    Category = _categoryRepository.GetCategory(item.CategoryId).Name,
                    Count = transactionitem.Count,
                    SinglePrice = transactionitem.SinglePrice
                });
            }

            return result;
        }

        public IEnumerable<ItemTransactionViewDto> GetItemTransactions(int itemId)
        {
            var result = new List<ItemTransactionViewDto>();

            var transactionItems = _transactionItemsRepository.GetItem(itemId);

            foreach (var transactionItem in transactionItems)
            {
                var transaction = _transactionRepository.GetTransaction(transactionItem.TransactionId);

                result.Add(new ItemTransactionViewDto
                {
                    TransactionId = transactionItem.TransactionId,
                    Date = transaction.Date,
                    Type = _transactionTypeRepository.GetStringByTypeId(transaction.TypId),
                    Count = transactionItem.Count,
                    SinglePrice = transactionItem.SinglePrice
                });
            }

            return result;
        }

        public TransactionViewDto GetTransactionView(int transactionId)
        {
            var result = new List<TransactionViewDto>();

            var transaction = _transactionRepository.GetTransaction(transactionId);

            return new TransactionViewDto
            {
                Id = transaction.Id,
                Date = transaction.Date,
                Type = _transactionTypeRepository.GetStringByTypeId(transaction.TypId),
                Describe = transaction.Describe,
                Worth = _transactionItemsRepository.GetTransactionItems(transaction.Id).Select(a => a.SinglePrice * a.Count).Sum().Value
            };
        }

        public IEnumerable<TransactionViewDto> GetAllTransactions()
        {
            var result = new List<TransactionViewDto>();

            var transactions = _transactionRepository.GetTransactions();

            foreach (var transaction in transactions)
            {
                result.Add(new TransactionViewDto
                {
                    Id = transaction.Id,
                    Date = transaction.Date,
                    Type = _transactionTypeRepository.GetStringByTypeId(transaction.TypId),
                    Describe = transaction.Describe,
                    Worth = _transactionItemsRepository.GetTransactionItems(transaction.Id).Select(a => a.SinglePrice * a.Count).Sum().Value
                });
            }

            return result;
        }

        public void AddOrderTransaction(FullTransactionDto transaction)
        {
            var transactionType = _transactionTypeRepository.GetOrderType();

            var transactionId = _transactionRepository.AddTransaction(transactionType , transaction.Describe);

            foreach(var transactionItem in transaction.Items)
            {
                _itemRepository.DecrementItem(transactionItem.ItemId, transactionItem.Count);

                transactionItem.TransactionId = transactionId;
                _transactionItemsRepository.AddItemForTransaction(transactionItem);
            }
        }

        public void AddSupplyTransaction(FullTransactionDto transaction)
        {
            var transactionType = _transactionTypeRepository.GetSupplyType();

            var transactionId = _transactionRepository.AddTransaction(transactionType, transaction.Describe);

            foreach (var transactionItem in transaction.Items)
            {
                _itemRepository.IncrementItem(transactionItem.ItemId, transactionItem.Count);

                transactionItem.TransactionId = transactionId;
                _transactionItemsRepository.AddItemForTransaction(transactionItem);
            }
        }

        public void AddReturnTransaction(FullTransactionDto transaction)
        {
            var transactionType = _transactionTypeRepository.GetReturnType();

            var transactionId = _transactionRepository.AddTransaction(transactionType, transaction.Describe);

            foreach (var transactionItem in transaction.Items)
            {
                _itemRepository.IncrementItem(transactionItem.ItemId, transactionItem.Count);

                transactionItem.TransactionId = transactionId;
                _transactionItemsRepository.AddItemForTransaction(transactionItem);
            }
        }
    }
}
