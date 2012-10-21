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
    public class InterventoRotCreated : EventBase
    {
        public Guid IdTipoIntervento { get; set; }
        public Guid IdPlan { get; set; }
        public OggettoRot[] Oggetti { get; set; }
        public WorkPeriod WorkPeriod { get; set; }

        public InterventoRotCreated(Guid id, Guid commitId, long version, Guid idTipoIntervento, Guid idPlan, OggettoRot[] oggetti, WorkPeriod workPeriod)
            :base(id,commitId,version)
        {
            Contract.Requires(idTipoIntervento!=Guid.Empty);
            Contract.Requires(idPlan != Guid.Empty);
            Contract.Requires(oggetti!=null);
            Contract.Requires(workPeriod != null);

            IdTipoIntervento = idTipoIntervento;
            IdPlan = idPlan;
            Oggetti = oggetti;
            WorkPeriod = workPeriod;
        }

        public override string ToDescription()
        {
            return string.Format("l'intervento rotabile {0} é stato creato", Id);
        }

        public bool Equals(InterventoRotCreated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.IdTipoIntervento.Equals(IdTipoIntervento) && other.IdPlan.Equals(IdPlan) && other.Oggetti.SequenceEqual(Oggetti) && Equals(other.WorkPeriod, WorkPeriod);
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
                result = (result*397) ^ (WorkPeriod != null ? WorkPeriod.GetHashCode() : 0);
                return result;
            }
        }
    }

    
}
