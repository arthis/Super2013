using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;

namespace Super.Contabilita.Commands.TipoIntervento.Ambiente
{

    public class TipoInterventoAmbUpdated : CommandBase
    {
        
        public Guid IdMeasuringUnit { get; set; }
        public string Description { get; set; }
        public string Mnemo { get; set; }
 
        public TipoInterventoAmbUpdated()
        {}

        public TipoInterventoAmbUpdated(Guid id, Guid commitId, long version, string mnemo, Guid idMeasuringUnit, string description)
            : base(id, commitId, version)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(mnemo));
            Contract.Requires<ArgumentNullException>(idMeasuringUnit != Guid.Empty);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(description));

            Mnemo = mnemo;
            IdMeasuringUnit = idMeasuringUnit;
            Description = description;
        }

        public override string ToDescription()
        {
            return string.Format("Il tipo intervento ambiente é stato aggiornato '{0}')", Description);
        }

        public bool Equals(TipoInterventoAmbUpdated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.IdMeasuringUnit.Equals(IdMeasuringUnit) && Equals(other.Description, Description) && Equals(other.Mnemo, Mnemo);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as TipoInterventoAmbUpdated);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ IdMeasuringUnit.GetHashCode();
                result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
                result = (result*397) ^ (Mnemo != null ? Mnemo.GetHashCode() : 0);
                return result;
            }
        }
    }
}
