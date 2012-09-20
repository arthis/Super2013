using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;

namespace Super.Contabilita.Commands.TipoOggettoIntervento.RotabileInManutenzione
{

    public class UpdateLocomotiveRotMan : CommandBase
    {
        public string Description { get; set; }
        public Guid IdGruppoOggettoIntervento { get; set; }
        public string Sign { get; set; }
 

        public UpdateLocomotiveRotMan()
        {}

        public UpdateLocomotiveRotMan(Guid id, Guid commitId, long version, string sign, string description, Guid idGruppoOggettoIntervento)
            : base(id, commitId, version)
        {
            Contract.Requires(!string.IsNullOrEmpty(sign));
            Contract.Requires(!string.IsNullOrEmpty(description));
            Contract.Requires(idGruppoOggettoIntervento != Guid.Empty);

            Sign = sign;
            Description = description;
            IdGruppoOggettoIntervento = idGruppoOggettoIntervento;
        }

        public override string ToDescription()
        {
            return string.Format("Aggiorniamo la locomotiva rotabile '{0}')", Description);
        }

        public bool Equals(UpdateLocomotiveRotMan other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Description, Description) && Equals(other.Sign, Sign);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as UpdateLocomotiveRotMan);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
                result = (result*397) ^ (Sign != null ? Sign.GetHashCode() : 0);
                return result;
            }
        }
    }
}
