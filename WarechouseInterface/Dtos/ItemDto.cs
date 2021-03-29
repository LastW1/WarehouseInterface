using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarechouseInterface.Dtos
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public byte[] Picture { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public int Count { get; set; }
        public string Describe { get; set; }
        public string Location { get; set; }
        public string AdditionalInfo { get; set; }
        public int? MinAllert { get; set; }
        public int? MaxAllert { get; set; }
        public bool Allert { get; set; }
    }
}
