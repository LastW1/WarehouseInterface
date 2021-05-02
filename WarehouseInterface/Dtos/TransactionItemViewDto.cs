namespace WarehouseInterface.Dtos
{
    public class TransactionItemViewDto
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int Count { get; set; }
        public decimal? SinglePrice { get; set; }
    }
}
