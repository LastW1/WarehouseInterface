﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using WarechouseInterface.Db.DbDtos;
using WarechouseInterface.Dtos;
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

        public TransactionDbDto GetTransaction(int transactionId)
        {
            return _databaseContext.Transaction.FirstOrDefault(a => a.Id == transactionId);
        }
        public IEnumerable<TransactionDbDto> GetTransactions()
        {
            return _databaseContext.Transaction.Where(a=>true);
        }

        public int AddTransaction(int transactionType, string describe)
        {
            var transaction = new TransactionDbDto
            {
                TypId = transactionType,
                Describe = describe,
                Date = DateTime.Now
            };

            _databaseContext.Transaction.Add(transaction);
            _databaseContext.SaveChanges();

            return transaction.Id;
        }
    }
}
