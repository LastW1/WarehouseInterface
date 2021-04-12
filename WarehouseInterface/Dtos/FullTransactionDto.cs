using System.Collections.Generic;
using WarehouseInterface.Db.DbDtos;

namespace WarehouseInterface.Dtos
{
    public class FullTransactionDto
    {
        public string Describe { get; set; }
        public string Type { get; set; }
        public IEnumerable<TransactionItemsDbDto> Items { get; set; }
    }
}
