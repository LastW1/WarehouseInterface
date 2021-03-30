using System.Collections.Generic;
using WarechouseInterface.Db.DbDtos;

namespace WarechouseInterface.Dtos
{
    public class FullTransactionDto
    {
        public string Describe { get; set; }
        public string Type { get; set; }
        public IEnumerable<TransactionItemsDbDto> Items { get; set; }
    }
}
