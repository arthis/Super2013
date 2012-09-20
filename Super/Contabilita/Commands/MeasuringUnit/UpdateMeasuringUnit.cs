using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Commands.Lotto;

namespace Super.Contabilita.Commands.MeasuringUnit
{

    public class UpdateMeasuringUnit : CommandBase
    {

        public string Description { get; set; }

        public UpdateMeasuringUnit()
        {}

        public UpdateMeasuringUnit(Guid id, Guid commitId, long version, string description)
            :base (id,commitId,version)
        {
            
            Contract.Requires(!string.IsNullOrEmpty(description));
            
            Description = description;
        }

        public override string ToDescription()
        {
            return string.Format("Aggiorniamo l'unità di misura '{0}')", Description);
        }

        public bool Equals(UpdateMeasuringUnit other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Description, Description);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as UpdateMeasuringUnit);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ (Description != null ? Description.GetHashCode() : 0);
            }
        }
    }
}
