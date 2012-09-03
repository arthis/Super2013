using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.Intervento;
using Super.Contabilita.Domain;
using Super.Contabilita.Domain.Intervento;
using Super.Contabilita.Domain.TipoOggettoIntervento;

namespace Super.Contabilita.Handlers.Intervento
{

    public class CalculateInterventoRotPriceOfPlanHandler : CommandHandler<CalculateInterventoRotPriceOfPlan>
    {
        public CalculateInterventoRotPriceOfPlanHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(CalculateInterventoRotPriceOfPlan cmd)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);

            var intervento = EventRepository.GetById<Domain.Intervento.InterventoRot>(cmd.Id);

            if (intervento.IsNull())
            {
                intervento = new Domain.Intervento.InterventoRot(cmd.Id, cmd.IdTipoIntervento, cmd.IdPlan, cmd.Oggetti.ToDomainObjects(), Period.FromMessage(cmd.Period));
            }

            var bachibousouk = EventRepository.GetById<Domain.Pricing.Pricing>(cmd.IdBachBouzouk);
            
            intervento.CalculatePrice(bachibousouk);

            EventRepository.Save(intervento, cmd.CommitId);

            return intervento.CommandValidationMessages;
        }

    }

 
}
