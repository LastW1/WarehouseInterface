using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarechouseInterface.DbDtos
{
    [Table("PASSWORD")]
    public class PasswordDbDto
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("PASSWORD")]
        public string Hash { get; set; }
        [Column("DATA_K")]
        public DateTime? DataK { get; set; }
    }
}
