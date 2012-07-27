using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core.Handlers;
using Super.Contabilita.Events.Schedulation;

namespace Super.Contabilita.Projection
{
    public class ValorizzazioneScenarioProjection: IEventHandler<SchedulationPriceOfScenarioCalculated>
    {
        public void Handle(SchedulationPriceOfScenarioCalculated @event)
        {
             using (var container = Container.GetEntities())
            {
                 //call to stored procedure

                
            }
        }
    }
}
