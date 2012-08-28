using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
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

            var intervento = EventRepository.GetById<Domain.Intervento>(cmd.Id);

            intervento.CalculatePrice();

            EventRepository.Save(intervento, cmd.CommitId);

            return intervento.CommandValidationMessages;
        }

    }

 
}
