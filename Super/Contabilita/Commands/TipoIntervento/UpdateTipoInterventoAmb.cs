using System;
using System.Diagnostics.Contracts;
using CommandService;
using CommonDomain.Core;

namespace Super.Contabilita.Commands.TipoIntervento
{

    public class UpdateTipoInterventoAmb : CommandBase
    {
        public Guid IdContract { get; set; }
        public Guid IdMasuringUnit { get; set; }
        public string Description { get; set; }
        public string Mnemo { get; set; }
 
        public UpdateTipoInterventoAmb()
        {}

        public UpdateTipoInterventoAmb(Guid id, string mnemo, Guid idMeasuringUnit, Guid idContract, string description)
        {
            Contract.Requires<ArgumentNullException>(id != Guid.Empty);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(mnemo));
            Contract.Requires<ArgumentNullException>(idMeasuringUnit != Guid.Empty);
            Contract.Requires<ArgumentNullException>(idContract != Guid.Empty);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(description));

            Mnemo = mnemo;
            IdMasuringUnit = idMeasuringUnit;
            IdContract = idContract;
            Id = id;
            Description = description;
        }

        public override string ToDescription()
        {
            return string.Format("Aggiorniamo il tipo intervento ambiente '{0}')", Description);
        }

        public bool Equals(UpdateTipoInterventoAmb other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.IdContract.Equals(IdContract) && other.IdMasuringUnit.Equals(IdMasuringUnit) && Equals(other.Description, Description) && Equals(other.Mnemo, Mnemo);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as UpdateTipoInterventoAmb);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ IdContract.GetHashCode();
                result = (result*397) ^ IdMasuringUnit.GetHashCode();
                result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
                result = (result*397) ^ (Mnemo != null ? Mnemo.GetHashCode() : 0);
                return result;
            }
        }
    }
}
