using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Commands.Lotto;

namespace Super.Contabilita.Commands.CategoriaCommerciale
{

    public class UpdateCategoriaCommerciale : CommandBase
    {

        public string Description { get; set; }


        public UpdateCategoriaCommerciale()
        {}

        public UpdateCategoriaCommerciale(Guid id, Guid commitId, long version, string description)
            :base (id,commitId,version)
        {
            
            Contract.Requires(!string.IsNullOrEmpty(description));
            
            Description = description;
        }

        public override string ToDescription()
        {
            return string.Format("Aggiorniamo il categoria commerciale '{0}')", Description);
        }

        public bool Equals(UpdateCategoriaCommerciale other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Description, Description) ;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as UpdateCategoriaCommerciale);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
                return result;
            }
        }
    }
}
