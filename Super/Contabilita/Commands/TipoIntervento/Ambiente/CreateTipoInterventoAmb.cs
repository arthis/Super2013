using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;

namespace Super.Contabilita.Commands.TipoIntervento.Ambiente
{
    
    public class CreateTipoInterventoAmb : CommandBase
    {
        
        public Guid IdMeasuringUnit { get; set; }
        public string Description { get; set; }
        public string Mnemo { get; set; }
        public DateTime CreationDate { get; set; }
        

   

        public CreateTipoInterventoAmb()
        {
            
        }

        public CreateTipoInterventoAmb(Guid id, string mnemo, Guid idMeasuringUnit, DateTime creationDate, string description)
        {
            Contract.Requires<ArgumentNullException>(id != Guid.Empty);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(mnemo));
            Contract.Requires<ArgumentNullException>(idMeasuringUnit != Guid.Empty);
            
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(description));
            Contract.Requires<ArgumentNullException>(creationDate > DateTime.MinValue);

            Mnemo = mnemo;
            IdMeasuringUnit = idMeasuringUnit;
            
            Id = id;
            Description = description;
            CreationDate = creationDate;
        }

        public override string ToDescription()
        {
            return string.Format("Creiamo il tipo intervento ambiente '{0}'.", Description);
        }

        public bool Equals(CreateTipoInterventoAmb other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.IdMeasuringUnit.Equals(IdMeasuringUnit) && Equals(other.Description, Description) && Equals(other.Mnemo, Mnemo) && other.CreationDate.Equals(CreationDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CreateTipoInterventoAmb);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ IdMeasuringUnit.GetHashCode();
                result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
                result = (result*397) ^ (Mnemo != null ? Mnemo.GetHashCode() : 0);
                result = (result*397) ^ CreationDate.GetHashCode();
                return result;
            }
        }
    }
}
