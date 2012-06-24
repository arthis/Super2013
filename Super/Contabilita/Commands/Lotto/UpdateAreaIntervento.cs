using System;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Contabilita.Commands.Lotto
{

    public class UpdateLotto : CommandBase
    {

        public Intervall Period { get; private set; }
        public string Description { get; private set; }
        public long Version { get; private set; }

        public UpdateLotto()
        {}

        public UpdateLotto(Guid id, long version, Intervall period,  string description)
        {
            this.Id = id;
            this.Version = version;
            this.Period = period;
            this.Description = description;
        }

        public override string ToDescription()
        {
            return string.Format("Aggiorniamo il lotto '{0}')", Description);
        }

        public bool Equals(UpdateLotto other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Period, Period) && Equals(other.Description, Description) && other.Version == Version;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as UpdateLotto);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ (Period != null ? Period.GetHashCode() : 0);
                result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
                result = (result*397) ^ Version.GetHashCode();
                return result;
            }
        }
    }
}
