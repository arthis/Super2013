using System;
using System.Diagnostics.Contracts;
using CommandService;
using CommonDomain.Core;

namespace Super.Contabilita.Commands.TipoIntervento
{
    
    public class CreateTipoInterventoRotMan : CommandBase
    {
        public Guid IdContract { get; set; }
        public Guid IdMasuringUnit { get; set; }
        public string Description { get; set; }
        public string Mnemo { get; set; }
        public DateTime CreationDate { get; set; }

        public CreateTipoInterventoRotMan()
        {
            
        }

        public CreateTipoInterventoRotMan(Guid id, string mnemo, Guid idMeasuringUnit, Guid idContract, DateTime creationDate, string description)
        {
            Contract.Requires<ArgumentNullException>(id != Guid.Empty);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(mnemo));
            Contract.Requires<ArgumentNullException>(idMeasuringUnit != Guid.Empty);
            Contract.Requires<ArgumentNullException>(idContract != Guid.Empty);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(description));
            Contract.Requires<ArgumentNullException>(creationDate > DateTime.MinValue);

            Mnemo = mnemo;
            IdMasuringUnit = idMeasuringUnit;
            IdContract = idContract;
            Id = id;
            Description = description;
            CreationDate = creationDate;
        }

        public override string ToDescription()
        {
            return string.Format("Creiamo il tipo intervento rotabile in manutenzione '{0}'.", Description);
        }

        public bool Equals(CreateTipoInterventoRotMan other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.IdContract.Equals(IdContract) && other.IdMasuringUnit.Equals(IdMasuringUnit) && Equals(other.Description, Description) && Equals(other.Mnemo, Mnemo) && other.CreationDate.Equals(CreationDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CreateTipoInterventoRotMan);
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
                result = (result*397) ^ CreationDate.GetHashCode();
                return result;
            }
        }
    }
}
