using System.ComponentModel.DataAnnotations.Schema;

namespace WarechouseInterface.Db.DbDtos
{
    [Table("ITEM")]
    public class ItemDbDto
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("WARECHOUSE_ID")]
        public int WarechouseId { get; set; }
        [Column("CATEGORY_ID")]
        public int CategoryId { get; set; }
        [Column("PICTURE")]
        public byte[] Picture { get; set; }
        [Column("NAME")]
        public string Name { get; set; }
        [Column("PRICE")]
        public decimal? Price { get; set; }
        [Column("COUNT")]
        public int Count { get; set; }
        [Column("DESCRIBE")]
        public string Describe { get; set; }
        [Column("LOCATION")]
        public string Location { get; set; }
        [Column("ADDITIONAL_INFO")]
        public string AdditionalInfo { get; set; }
        [Column("MIN_ALLERT")]
        public int? MinAllert { get; set; }
        [Column("MAX_ALLERT")]
        public int? MaxAllert { get; set; }
    }
}

