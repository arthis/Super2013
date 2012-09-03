using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Contabilita.Events.Intervento
{
    public class InterventoRotCreated : Message,IEvent
    {
        public Guid IdTipoIntervento { get; set; }
        public Guid IdPlan { get; set; }
        public OggettoRot[] Oggetti { get; set; }
        public Period Period { get; set; }

        public InterventoRotCreated(Guid id, Guid commitId, long version, Guid idTipoIntervento, Guid idPlan, OggettoRot[] oggetti, Period period)
            :base(id,commitId,version)
        {
            Contract.Requires(idTipoIntervento!=Guid.Empty);
            Contract.Requires(idPlan != Guid.Empty);
            Contract.Requires(oggetti!=null);
            Contract.Requires(period != null);

            IdTipoIntervento = idTipoIntervento;
            IdPlan = idPlan;
            Oggetti = oggetti;
            Period = period;
        }

        public override string ToDescription()
        {
            return string.Format("l'intervento rotabile {0} é stato creato", Id);
        }

        public bool Equals(InterventoRotCreated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.IdTipoIntervento.Equals(IdTipoIntervento) && other.IdPlan.Equals(IdPlan) && other.Oggetti.SequenceEqual(Oggetti) && Equals(other.Period, Period);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoRotCreated);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ IdTipoIntervento.GetHashCode();
                result = (result*397) ^ IdPlan.GetHashCode();
                result = (result*397) ^ (Oggetti != null ? Oggetti.GetHashCode() : 0);
                result = (result*397) ^ (Period != null ? Period.GetHashCode() : 0);
                return result;
            }
        }
    }

    
}
