using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Contabilita.Commands.PeriodoProgrammazione.Rotabile
{
    public class UpdatePeriodoProgrammazioneRot : CommandBase
    {
        public Intervall Intervall { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }

        public UpdatePeriodoProgrammazioneRot()
        {

        }

        public UpdatePeriodoProgrammazioneRot(Guid id, Guid commitId, long version, Intervall period, DateTime creationDate, string description)
            : base(id, commitId, version)
        {
            Contract.Requires<ArgumentNullException>(period != null);
            Contract.Requires<ArgumentOutOfRangeException>(creationDate > DateTime.MinValue);
            Contract.Requires<ArgumentException>(!string.IsNullOrEmpty(description));

            this.Intervall = period;
            this.Description = description;
            this.CreationDate = creationDate;
        }

        public override string ToDescription()
        {
            return string.Format("Aggiornamo il periodo programmazione rotabile '{0}'.", Description);
        }

        public bool Equals(UpdatePeriodoProgrammazioneRot other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Intervall, Intervall) && Equals(other.Description, Description) && other.CreationDate.Equals(CreationDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as UpdatePeriodoProgrammazioneRot);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result * 397) ^ (Intervall != null ? Intervall.GetHashCode() : 0);
                result = (result * 397) ^ (Description != null ? Description.GetHashCode() : 0);
                result = (result * 397) ^ CreationDate.GetHashCode();
                return result;
            }
        }
    }
}