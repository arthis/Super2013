using System;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using Super.Appaltatore.Events;
using Super.Appaltatore.Events.Consuntivazione;

namespace Super.Appaltatore.Domain
{
    public abstract class Intervento : AggregateBase
    {
        internal WorkPeriod ProgrammedWorkPeriod;
         
    }
}
