using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;

namespace Super.Contabilita.Commands.PeriodoProgrammazione
{
    
    public class ClosePeriodoProgrammazioneRot: CommandBase
    {
        public DateTime ClosingDate { get;  set; }
        public Guid IdUser { get; set; }

        public ClosePeriodoProgrammazioneRot()
        {
            
        }

        public ClosePeriodoProgrammazioneRot(Guid id, Guid commitId, long version, DateTime closingDate, Guid idUser)
            : base(id, commitId, version)
        {
            Contract.Requires<ArgumentOutOfRangeException>(closingDate > DateTime.MinValue);
            Contract.Requires<ArgumentException>(idUser!= Guid.Empty);

            this.ClosingDate = closingDate;
            this.IdUser = idUser;
        }

        public override string ToDescription()
        {
            return string.Format("Chiudiamo il periodo programmazione rotabile '{0}'.", Id);
        }

        public bool Equals(ClosePeriodoProgrammazioneRot other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.ClosingDate.Equals(ClosingDate) && other.IdUser.Equals(IdUser);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ClosePeriodoProgrammazioneRot);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ ClosingDate.GetHashCode();
                result = (result*397) ^ IdUser.GetHashCode();
                return result;
            }
        }
    }
}
