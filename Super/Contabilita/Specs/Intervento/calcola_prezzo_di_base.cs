using System;
using System.Collections.Generic;
using CommonDomain.Core.Super.Domain.ValueObjects;
//using Machine.Specifications;
using Super.Contabilita.Domain.Intervento;
using Super.Contabilita.Domain.Pricing;

namespace Super.Contabilita.Specs.Intervento
{
    //public class calcola_prezzo_di_base
    //{
    //    private static InterventoBasePriceCalculation _priceCalculation;
    //    private static Guid _idTipoIntervento = Guid.NewGuid();
    //    private static Guid _IdTipoOggettoIntervento = Guid.NewGuid();
    //    private static Guid _IdGruppoOggettoIntervento = Guid.NewGuid();
    //    private static  IEnumerable<OggettoRot> _oggetti = new List<OggettoRot>(){ new OggettoRot("description",2,_IdTipoOggettoIntervento,)};
    //    public static WorkPeriod period = new WorkPeriod(DateTime.Today,DateTime.Today.AddDays(1));
    //    public static List<BasePrice> basePrices = new List<BasePrice>(){ new BasePrice(10,_IdGruppoOggettoIntervento,_idTipoIntervento,new IntervalOpened(null,null))};


    //    private Establish context = () =>
    //                                    {
    //                                        _priceCalculation = new InterventoBasePriceCalculation(_idTipoIntervento,
    //                                                                                               _oggetti, period);
    //                                    };

    //    private Cleanup after = () => _priceCalculation = null;

    //    private Because of = () => _priceCalculation.Calculate(basePrices);

    //    private It should_give_the_correct_base_price = () => _priceCalculation.GetValue();

    //}
}
