using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Axerrio.Jonottaa.Data.Interface;

namespace Axerrio.Jonottaa.Data
{
    public interface IComponent<T> : IDisposable
    {
        void CalculateItem(T item, ICalculationContext context);
        void CalculateItems(List<T> items, ICalculationContext context);
    }
}
