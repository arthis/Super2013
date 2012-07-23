using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;

namespace Super.Contabilita.Commands.CategoriaCommerciale
{
    
    public class CreateCategoriaCommerciale : CommandBase
    {
        
        public string Description { get;  set; }

        public CreateCategoriaCommerciale()
        {
            
        }

        public CreateCategoriaCommerciale(Guid id, Guid commitId, long version,  string description)
            : base(id, commitId, version)
        {
            Contract.Requires<ArgumentException>(!string.IsNullOrEmpty(description));
            
            this.Description = description;
        }

        public override string ToDescription()
        {
            return string.Format("Creiamo il categoria commerciale '{0}'.", Description);
        }

        public bool Equals(CreateCategoriaCommerciale other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Description, Description);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CreateCategoriaCommerciale);
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
