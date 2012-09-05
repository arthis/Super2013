using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;

namespace Super.Programmazione.Commands.Schedulazione
{
    public class CancelSchedulazioneFromPlan : CommandBase
    {
        public Guid IdUser { get; set; }
        public bool DeleteGeneratedIntervento { get; set; }

        public CancelSchedulazioneFromPlan()
        {

        }

        public CancelSchedulazioneFromPlan(Guid id, Guid commitId, long version, Guid idUser, bool deleteGeneratedIntervento)
            : base(id, commitId, version)
        {
            Contract.Requires(idUser!= Guid.Empty);

            IdUser = idUser;
            DeleteGeneratedIntervento = deleteGeneratedIntervento;
        }

        public override string ToDescription()
        {
            return string.Format("Cancellare schedulazione {0} dal piano ", Id);
        }

        public bool Equals(CancelSchedulazioneFromPlan other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CancelSchedulazioneFromPlan);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}