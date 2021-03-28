using System.Collections.Generic;
using WarechouseInterface.Db.DbDtos;

namespace WarechouseInterface.Dtos
{
    public class FullTransactionDto
    {
        public string Describe { get; set; } //do tranzakcji dorobić pole z datą
        public IEnumerable<TransactionItemsDbDto> Items { get; set; }
    }
}
