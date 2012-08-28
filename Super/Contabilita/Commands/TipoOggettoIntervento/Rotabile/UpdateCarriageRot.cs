using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;

namespace Super.Contabilita.Commands.TipoOggettoIntervento.Rotabile
{

    public class UpdateCarriageRot : CommandBase
    {
        public string Description { get; set; }
        public string Sign { get; set; }
        public bool IsInternational { get; set; }

        public UpdateCarriageRot()
        {}

        public UpdateCarriageRot(Guid id, Guid commitId, long version, string sign, string description, bool isInternational)
            : base(id, commitId, version)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(sign));
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(description));

            Sign = sign;
            Description = description;
            IsInternational = isInternational;
        }

        public override string ToDescription()
        {
            return string.Format("Aggiorniamo la carrozza rotabile '{0}')", Description);
        }

        public bool Equals(UpdateCarriageRot other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Description, Description) && Equals(other.Sign, Sign) && other.IsInternational.Equals(IsInternational);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as UpdateCarriageRot);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
                result = (result*397) ^ (Sign != null ? Sign.GetHashCode() : 0);
                result = (result*397) ^ IsInternational.GetHashCode();
                return result;
            }
        }
    }
}
