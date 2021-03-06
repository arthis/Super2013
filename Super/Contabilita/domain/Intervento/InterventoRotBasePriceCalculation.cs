//using System;
//using System.Collections.Generic;
//using System.Diagnostics.Contracts;
//using CommonDomain.Core.Super.Domain.ValueObjects;
//using Super.Contabilita.Domain.Pricing;
//using System.Linq;

//namespace Super.Contabilita.Domain.Intervento
//{
//    public class InterventoRotBasePriceCalculation : IBasePriceCalculation
//    {
//        private readonly Guid _idTipoIntervento;
//        private readonly IEnumerable<OggettoRot> _oggetti;
//        private readonly WorkPeriod _workPeriod;

//        public InterventoRotBasePriceCalculation(Guid idTipoIntervento, IEnumerable<OggettoRot> oggetti, WorkPeriod workPeriod)
//        {
//            Contract.Requires(idTipoIntervento!= Guid.Empty);
//            Contract.Requires(oggetti!=null);
//            Contract.Requires(workPeriod!=null);

//            _idTipoIntervento = idTipoIntervento;
//            _oggetti = oggetti;
//            _workPeriod = workPeriod;
//        }

//        public decimal Calculate(List<BasePrice> prices)
//        {
//            var totalPrice = 0M;
//            foreach(var date in _workPeriod.GetDays())
//            {
//                foreach(var oggetto  in _oggetti)
//                {
//                    var price =
//                        prices.SingleOrDefault(x => x.Fits(date, oggetto.IdGruppoOggettoIntervento, _idTipoIntervento));

//                    if (price != null)
//                        totalPrice += price.Value * oggetto.Quantity;
//                }
//            }

//            return totalPrice;
//        }
//    }
//}