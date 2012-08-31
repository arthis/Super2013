using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.bachibouzouk;
using Super.Contabilita.Domain.bachibouzouk;

namespace Super.Contabilita.Handlers.bachiBouzouk
{

    public class CreateBasePriceHandler : CommandHandler<CreateBasePrice>
    {
        public CreateBasePriceHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(CreateBasePrice cmd)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);


            var bachibouzouk = EventRepository.GetById<bachibouzouk>(cmd.Id);

            if (bachibouzouk.IsNull())
                throw new AggregateRootInstanceNotFoundException();


            bachibouzouk.CreateBasePrice(cmd.IdBasePrice, cmd.Value, cmd.IdGruppoOggettoIntervento, cmd.IdTipoIntervento, IntervalOpened.FromMessage(cmd.Intervall));

            EventRepository.Save(bachibouzouk, cmd.CommitId);


            return bachibouzouk.CommandValidationMessages;
        }

    }

 
}

