using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Axerrio.Jonottaa.Data;
using Axerrio.Jonottaa.Data.CalculationContext;
using Axerrio.Jonottaa.Data.Interface;

namespace Axerrio.Jonottaa.Component.Calculations
{
    [Export(typeof(IComponent))]
    [ExportMetadata("ComponentID", "A8C99032-18A9-4CF0-A4FB-0E1A34889939")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class FixedMarkupCalc : BaseComponent, IComponent<PriceItem>
    {
        public void CalculateItem(PriceItem item, ICalculationContext context)
        {
            ValueContext valueContext = context as ValueContext;

            if (valueContext == null)
                throw new InvalidCastException("The supplied ICalculationContext is not of type ValueContext");

            DoCalculation(item, valueContext);
        }

        public void CalculateItems(List<PriceItem> items, ICalculationContext context)
        {
            ValueContext valueContext = context as ValueContext;

            if (valueContext == null)
                throw new InvalidCastException("The supplied ICalculationContext is not of type ValueContext");

            Parallel.ForEach(items , (currentItem =>
            {
                DoCalculation(currentItem, valueContext);
            }));
        }

        private void DoCalculation(PriceItem item, ValueContext valueContext)
        {
            item.Price = item.Price + valueContext.Value;
        }
    }
}
