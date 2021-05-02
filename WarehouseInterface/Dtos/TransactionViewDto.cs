using System;

namespace WarehouseInterface.Dtos
{
    public class TransactionViewDto
    {
        public int Id { get; set; }
        public string Describe { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public decimal Worth { get; set; }
    }
}
