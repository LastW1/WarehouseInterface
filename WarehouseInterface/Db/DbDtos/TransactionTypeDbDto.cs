using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseInterface.Db.DbDtos
{
    [Table("TRANSACTION_TYPE")]
    public class TransactionTypeDbDto
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("NAME")]
        public string Name { get; set; }
    }
}
