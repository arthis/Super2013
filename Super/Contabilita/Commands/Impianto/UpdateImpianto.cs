using System;
using System.Diagnostics.Contracts;
using CommandService;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Contabilita.Commands.Impianto
{

    public class UpdateImpianto : CommandBase
    {

        public Interval Interval { get; set; }
        public string Description { get;  set; }

        public UpdateImpianto()
        {}

        public UpdateImpianto(Guid id, Guid commitId, long version,  Interval period,  string description)
            :base(id,commitId,version)
        {
            Contract.Requires(!string.IsNullOrEmpty(description));
            Contract.Requires(period != null);

            Interval = period;
            Description = description;
        }

        public override string ToDescription()
        {
            return string.Format("Aggiorniamo il impianto '{0}')", Description);
        }

        public bool Equals(UpdateImpianto other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Interval, Interval) && Equals(other.Description, Description);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as UpdateImpianto);
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
