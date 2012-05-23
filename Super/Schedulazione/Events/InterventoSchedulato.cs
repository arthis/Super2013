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

                               
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public bool Equals(InterventoSchedulato other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.Id.Equals(Id) && other.IdAreaIntervento.Equals(IdAreaIntervento) && other.Start.Equals(Start) && other.End.Equals(End);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = Id.GetHashCode();
                result = (result*397) ^ IdAreaIntervento.GetHashCode();
                result = (result*397) ^ Start.GetHashCode();
                result = (result*397) ^ End.GetHashCode();
                return result;
            }
        }
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
