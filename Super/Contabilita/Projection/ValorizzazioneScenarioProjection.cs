using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core.Handlers;
using Super.Contabilita.Events.Schedulazione;

namespace Super.Contabilita.Projection
{
    public class ValorizzazioneScenarioProjection: IEventHandler<SchedulazionePriceOfScenarioCalculated>
    {
        public void Handle(SchedulazionePriceOfScenarioCalculated @event)
        {
             using (var container = Container.GetEntities())
            {
                 //call to stored procedure

                
            }
        }
    }
}
