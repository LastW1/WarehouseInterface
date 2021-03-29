using System.ComponentModel.DataAnnotations.Schema;

namespace WarechouseInterface.Db.DbDtos
{
    [Table("TRANSACTION_ITEMS")]
    public class TransactionItemsDbDto
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("ITEM_ID")]
        public int ItemId { get; set; }
        [Column("TRANSACTION_ID")]
        public int TransactionId { get; set; }
        [Column("COUNT")]
        public int Count { get; set; }
        [Column("SINGLE_PRICE")]
        public decimal? SinglePrice { get; set; }
    }
}
