using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain;
using CommonDomain.Core;


namespace Super.Schedulazione.Events
{
    public abstract class InterventoSchedulato : Message,IEvent
    {
        public Guid Id { get; set; }
        public Guid IdAreaIntervento { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public abstract string ToDescription();

    }

    public class InterventoRotSchedulato : InterventoSchedulato
    {
        public override string ToDescription()
        {
            return string.Format("The Intervento rotabile {0} is Schedulato.", Id);
        }
    }

    public class InterventoRotManSchedulato : InterventoSchedulato
    {
        public override string ToDescription()
        {
            return string.Format("The Intervento rotabile in manutenzione {0} is Schedulato.", Id);
        }
    }

    public class InterventoAmbSchedulato : InterventoSchedulato
    {
        public override string ToDescription()
        {
            return string.Format("The Intervento ambiente {0} is Schedulato.", Id);
        }
    }
}
