using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Axerrio.Jonottaa.Data.Interface;

namespace Axerrio.Jonottaa.Data.CalculationContext
{
    public class ValueContext : ICalculationContext
    {
        public decimal Value{ get; set; }
    }
}
