using System.ComponentModel.DataAnnotations.Schema;

namespace WarechouseInterface.Db.DbDtos
{
    [Table("CATEGORY")]
    public class Category
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("NAME")]
        public string Name { get; set; }
    }
}
