using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseInterface.Db.DbDtos
{
    [Table("TRANSACTION")]
    public class TransactionDbDto
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("TYP_ID")]
        public int TypId { get; set; }
        [Column("DESCRIBE")]
        public string Describe { get; set; }
        [Column("DATE")]
        public DateTime Date { get; set; }
    }
}
