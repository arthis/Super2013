﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using Super.Appaltatore.Events.Consuntivazione;
using Super.Saga.Domain.Intervento;

namespace Super.Saga.Handlers
{

    public class ConsuntivatoRotResoHandler : SagaHandler<ConsuntivatoRotReso>
    {
        public ConsuntivatoRotResoHandler(ISagaRepository repository, IBus bus)
            : base(repository, bus)
        {
        }

        public sealed override ISaga OnHandle(ConsuntivatoRotReso @event)
        {
            var sagaId = @event.Id;

            // purchase correlation 
            var saga = Repository.GetById<InterventoRotSaga>(sagaId);

            saga.ConsuntivareIntervento(@event);

            Repository.Save(saga, @event.GetCommitId(), null);

            return saga;
        }
    }
}
