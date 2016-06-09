using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axerrio.Jonottaa.Data
{
    public class PriceItem
    {
        public decimal Price{ get; set; }
        public int MinimalAmount{ get; set; }
        public string Article{ get; set; }
        public int PackedPer{ get; set; }
        public int InStock{ get; set; }
    }
}
