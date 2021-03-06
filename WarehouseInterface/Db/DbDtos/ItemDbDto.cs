using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseInterface.Db.DbDtos
{
    [Table("ITEM")]
    public class ItemDbDto
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("WAREHOUSE_ID")]
        public int WarehouseId { get; set; }
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
        [Column("DATA_K")]
        public DateTime? DataK { get; set; }
    }
}

