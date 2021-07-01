using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Interop;
using WarehouseInterface.Db.DbDtos;
using WarehouseInterface.Dtos;
using WarehouseInterface.Managers;
using WarehouseInterface.Repositories;

namespace WarehouseInterface.Tests.Managers
{
    [TestFixture]
    class TransactionManagerTest
    {
        private DatabaseContext _databaseContext;

        [TearDown]
        public void TearDown()
        {
            _databaseContext = null;
        }

        [Test]
        public void GetItemsForTransaction_ShouldReturnCorrectItemsCount_Test()
        {
            using (_databaseContext = new DatabaseContext(true))
            {
                var transactionId = _databaseContext.Transaction.FirstOrDefault().Id;
                var itemCount = _databaseContext.TransactionItem.Where(a => a.TransactionId == transactionId).Count();

                var manager = new TransactionManager(_databaseContext);

                Assert.AreEqual(itemCount, manager.GetItemsForTransaction(transactionId).Count());
            }
        }

        [Test]
        public void GetItemsForTransaction_WhenItemWithExistingTransactionGiven_ShouldReturnTransactions_Test()
        {
            using (_databaseContext = new DatabaseContext(true))
            {
                var itemId = _databaseContext.TransactionItem.FirstOrDefault().ItemId;
                var manager = new TransactionManager(_databaseContext);

                Assert.IsNotEmpty(manager.GetItemTransactions(itemId));
            }
        }

        [Test]
        public void GetTransactionView_WhenValidTransactionGiven_DoesNotThrow_Test()
        {
            using (_databaseContext = new DatabaseContext(true))
            {
                var transactionId = _databaseContext.Transaction.FirstOrDefault().Id;
              
                var manager = new TransactionManager(_databaseContext);

                Assert.DoesNotThrow(()=>manager.GetTransactionView(transactionId));
            }
        }

        [Test]
        public void GetAllTransactions_WhenTransactionExist_ShoiuldReturnNotEmpty_Test()
        {
            using (_databaseContext = new DatabaseContext(true))
            {
                var manager = new TransactionManager(_databaseContext);

                Assert.IsNotEmpty(manager.GetAllTransactions());
            }
        }

        [Test]
        public void AddOrderTransaction_WhenValidDataGiven_ShouldCreateOrder_Test()
        {
            using (_databaseContext = new DatabaseContext(true))
            {
                var itemId = _databaseContext.Item.FirstOrDefault(a => a.DataK == null).Id;

                var transaction = new FullTransactionDto
                {
                    Describe = "test",
                    Type = "ORDER",
                    Items = new List<TransactionItemsDbDto>
                    {
                        new TransactionItemsDbDto
                        {
                            ItemId = itemId,
                            Count = 2,
                            SinglePrice = 1.1m
                        }
                    }
                };

                var manager = new TransactionManager(_databaseContext);

                Assert.DoesNotThrow(()=>manager.AddOrderTransaction(transaction));
            }
        }

        [Test]
        public void AddSupplyTransaction_WhenValidDataGiven_ShouldCreateOrder_Test()
        {
            using (_databaseContext = new DatabaseContext(true))
            {
                var itemId = _databaseContext.Item.FirstOrDefault(a => a.DataK == null).Id;

                var transaction = new FullTransactionDto
                {
                    Describe = "test",
                    Type = "SUPPLY",
                    Items = new List<TransactionItemsDbDto>
                    {
                        new TransactionItemsDbDto
                        {
                            ItemId = itemId,
                            Count = 2,
                            SinglePrice = 1.1m
                        }
                    }
                };

                var manager = new TransactionManager(_databaseContext);

                Assert.DoesNotThrow(() => manager.AddSupplyTransaction(transaction));
            }
        }

        [Test]
        public void AddReturnTransaction_WhenValidDataGiven_ShouldCreateOrder_Test()
        {
            using (_databaseContext = new DatabaseContext(true))
            {
                var itemId = _databaseContext.Item.FirstOrDefault(a => a.DataK == null).Id;

                var transaction = new FullTransactionDto
                {
                    Describe = "test",
                    Type = "RETURN",
                    Items = new List<TransactionItemsDbDto>
                    {
                        new TransactionItemsDbDto
                        {
                            ItemId = itemId,
                            Count = 2,
                            SinglePrice = 1.1m
                        }
                    }
                };

                var manager = new TransactionManager(_databaseContext);

                Assert.DoesNotThrow(() => manager.AddReturnTransaction(transaction));
            }
        }
    }
}
