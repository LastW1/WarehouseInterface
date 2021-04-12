using System;

namespace WarehouseInterface.Dtos
{
    public class ItemTransactionViewDto
    {
        public int TransactionId { get; set; }
        public string Type { get; set; }
        public int Count { get; set; }
        public decimal? SinglePrice { get; set; }
        public DateTime Date { get; set; }
    }
}
