using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain;
using CommonDomain.Core;


namespace Super.Schedulazione.Events
{
    public class InterventoSchedulato : Message,IEvent
    {
        public Guid Id { get; set; }
        public Guid IdAreaIntervento { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public string ToDescription()
        {
            return string.Format("The Intervento {0} is Schedulato.", Id);
        }

        
    }
}
