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
    [ExportMetadata("ComponentID", "2B32B1A2-AB24-4F93-B592-53FAAD5A758F")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PercentageMarkupCalc : BaseComponent, IComponent<PriceItem>
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

            Parallel.ForEach(items, (currentItem =>
            {
                DoCalculation(currentItem, valueContext);
            }));
        }

        private void DoCalculation(PriceItem item, ValueContext valueContext)
        {
            var percentage = 1 + (valueContext.Value / 100);
            item.Price = item.Price * percentage;
        }
    }
}
