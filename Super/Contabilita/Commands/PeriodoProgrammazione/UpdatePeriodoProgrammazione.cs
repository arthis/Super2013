using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Contabilita.Commands.PeriodoProgrammazione
{
    public class UpdatePeriodoProgrammazione : CommandBase
    {
        public Interval Interval { get; set; }
        public string Description { get; set; }

        public UpdatePeriodoProgrammazione()
        {

        }

        public UpdatePeriodoProgrammazione(Guid id, Guid commitId, long version, Interval period,  string description)
            : base(id, commitId, version)
        {
            Contract.Requires(period != null);
            Contract.Requires(!string.IsNullOrEmpty(description));

            this.Interval = period;
            this.Description = description;
        }

        public override string ToDescription()
        {
            return string.Format("Aggiornamo il periodo programmazione  '{0}'.", Description);
        }

        public bool Equals(UpdatePeriodoProgrammazione other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Interval, Interval) && Equals(other.Description, Description);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as UpdatePeriodoProgrammazione);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ (Interval != null ? Interval.GetHashCode() : 0);
                result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
                return result;
            }
        }
    }
}