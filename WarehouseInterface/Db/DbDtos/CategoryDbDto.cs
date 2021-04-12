using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseInterface.Db.DbDtos
{
    [Table("CATEGORY")]
    public class CategoryDbDto
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("WAREHOUSE_ID")]
        public int WarehouseId { get; set; }
        [Column("NAME")]
        public string Name { get; set; }
    }
}
