using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.Pricing;
using Super.Contabilita.Domain.Pricing;

namespace Super.Contabilita.Handlers.Pricing
{

    public class UpdateBasePriceHandler : CommandHandler<UpdateBasePrice>
    {
        public UpdateBasePriceHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(UpdateBasePrice cmd)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);


            var pricing = EventRepository.GetById<Domain.Pricing.Pricing>(cmd.Id);

            if (pricing.IsNull())
                throw new AggregateRootInstanceNotFoundException();


            pricing.UpdateBasePrice(cmd.IdBasePrice, cmd.Value, cmd.IdGruppoOggettoIntervento, cmd.IdTipoIntervento, IntervalOpened.FromMessage(cmd.Intervall));

            EventRepository.Save(pricing, cmd.CommitId);


            return pricing.CommandValidationMessages;
        }

    }

 
}

