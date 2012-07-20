using System;
using CommonDomain.Core;

namespace Super.Contabilita.Commands.PeriodoProgrammazione.Rotabile
{

    public class DeletePeriodoProgrammazioneRot : CommandBase
    {
        public long Version { get; private set; }

        public DeletePeriodoProgrammazioneRot()
        {

        }


        public DeletePeriodoProgrammazioneRot(Guid id, Guid commitId, long version)
            : base(id, commitId, version)
        {
        }


        public override string ToDescription()
        {
            return string.Format("Cancelliamo il Periodo Programmazione Rotabile (Id:'{0}')", Id);
        }


        public bool Equals(DeletePeriodoProgrammazioneRot other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.Version == Version;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as DeletePeriodoProgrammazioneRot);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode() * 397) ^ Version.GetHashCode();
            }
        }
    }
}
