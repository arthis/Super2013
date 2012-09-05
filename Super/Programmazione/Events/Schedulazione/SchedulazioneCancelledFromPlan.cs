using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;

namespace Super.Programmazione.Events.Schedulazione
{
    public class SchedulazioneCancelledFromPlan : CommandBase
    {
        public Guid IdUser { get; set; }
        public bool DeleteGeneratedIntervento { get; set; }

        public SchedulazioneCancelledFromPlan()
        {

        }

        public SchedulazioneCancelledFromPlan(Guid id, Guid commitId, long version, Guid idUser, bool deleteGeneratedIntervento)
            : base(id, commitId, version)
        {
            Contract.Requires(idUser!= Guid.Empty);     

            IdUser = idUser;
            DeleteGeneratedIntervento = deleteGeneratedIntervento;
        }

        public override string ToDescription()
        {
            return string.Format("Schedulazione {0} é stat cancellata dal piano", Id);
        }

        public bool Equals(SchedulazioneCancelledFromPlan other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.IdUser.Equals(IdUser) && other.DeleteGeneratedIntervento.Equals(DeleteGeneratedIntervento);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as SchedulazioneCancelledFromPlan);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ IdUser.GetHashCode();
                result = (result*397) ^ DeleteGeneratedIntervento.GetHashCode();
                return result;
            }
        }
    }
}