using System;
using System.Collections.Generic;
using CommandService;
using CommonDomain;
using Super.Contabilita.Events.Impianto;
using Super.Contabilita.Events.Lotto;

namespace Super.Contabilita.Projection
{
    public class ProjectionHandlerService : IProjectionHandlerService
    {


        public List<Guid> lastCommitIdProcessed= new List<Guid>();

        public void Subscribe(IBus bus)
        {
            string subscriptionId = "Super";

            //Events
            bus.Subscribe<ImpiantoCreated>(subscriptionId, evt => new ReadOnce<ImpiantoCreated>().Handle(evt, new ImpiantoProjection()));
            bus.Subscribe<ImpiantoUpdated>(subscriptionId, evt => new ReadOnce<ImpiantoUpdated>().Handle(evt, new ImpiantoProjection()));
            bus.Subscribe<ImpiantoDeleted>(subscriptionId, evt => new ReadOnce<ImpiantoDeleted>().Handle(evt, new ImpiantoProjection()));

            bus.Subscribe<LottoCreated>(subscriptionId, evt => new ReadOnce<LottoCreated>().Handle(evt, new LottoProjection()));
            bus.Subscribe<LottoUpdated>(subscriptionId, evt => new ReadOnce<LottoUpdated>().Handle(evt, new LottoProjection()));
            bus.Subscribe<LottoDeleted>(subscriptionId, evt => new ReadOnce<LottoDeleted>().Handle(evt, new LottoProjection()));
        }
    }

    
}
