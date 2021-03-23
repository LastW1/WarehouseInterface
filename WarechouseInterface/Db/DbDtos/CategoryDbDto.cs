using System.ComponentModel.DataAnnotations.Schema;

namespace WarechouseInterface.Db.DbDtos
{
    [Table("CATEGORY")]
    public class CategoryDbDto
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("WARECHOUSE_ID")]
        public int WarechouseId { get; set; }
        [Column("NAME")]
        public string Name { get; set; }
    }
}
