using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.Intervento;

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

            var intervento = EventRepository.GetById<Domain.Intervento.Intervento>(cmd.Id);

            var bachibousouk = EventRepository.GetById<Domain.bachibouzouk.bachibouzouk>(cmd.IdBachBouzouk);

            intervento.CalculatePrice(bachibousouk, cmd.IdPlan, cmd.IdTipoIntervento, cmd.Oggetti.ToValueObject(), Period.FromMessage(cmd.Period));

            EventRepository.Save(intervento, cmd.CommitId);

            return intervento.CommandValidationMessages;
        }

    }

 
}
