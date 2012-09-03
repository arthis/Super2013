using System.Collections.Generic;

namespace Super.Contabilita.Domain.Pricing
{
    public interface IBasePriceCalculation
    {
        decimal Calculate(List<BasePrice> prices);
    }
}
