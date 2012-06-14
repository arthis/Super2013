using System;
using System.Collections.Generic;
using CommonDomain.Core;
using CommonDomain.Core.Super.ValueObjects;

namespace Super.Appaltatore.Commands
{

    public abstract class ConsuntivareNonResoTrenitalia : CommandBase
    {
        public string IdInterventoAppaltatore { get; set; }
        public DateTime DataConsuntivazione { get; set; }
        public Guid IdCausale { get; set; }
        public string Note { get; set; }


        public bool Equals(ConsuntivareNonResoTrenitalia other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.IdInterventoAppaltatore, IdInterventoAppaltatore) && other.DataConsuntivazione.Equals(DataConsuntivazione) && other.IdCausale.Equals(IdCausale) && Equals(other.Note, Note);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ConsuntivareNonResoTrenitalia);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ (IdInterventoAppaltatore != null ? IdInterventoAppaltatore.GetHashCode() : 0);
                result = (result*397) ^ DataConsuntivazione.GetHashCode();
                result = (result*397) ^ IdCausale.GetHashCode();
                result = (result*397) ^ (Note != null ? Note.GetHashCode() : 0);
                return result;
            }
        }
    }

    
    public class ConsuntivareRotNonResoTrenitalia : ConsuntivareNonResoTrenitalia
    {

        public override string ToDescription()
        {
            return string.Format("Si consuntiva non reso trenitalia il intervento rotabile '{0}' ", Id);
        }

        public bool Equals(ConsuntivareRotNonResoTrenitalia other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ConsuntivareRotNonResoTrenitalia);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    
    public class ConsuntivareRotManNonResoTrenitalia : ConsuntivareNonResoTrenitalia
    {

        public override string ToDescription()
        {
            return string.Format("Si consuntiva non reso trenitalia il intervento rotabile in manutenzione '{0}' ", Id);
        }

        public bool Equals(ConsuntivareRotManNonResoTrenitalia other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ConsuntivareRotManNonResoTrenitalia);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    
    public class ConsuntivareAmbNonResoTrenitalia : ConsuntivareNonResoTrenitalia
    {
       
        public override string ToDescription()
        {
            return string.Format("Si consuntiva non reso trenitalia il intervento ambiente '{0}' ", Id);
        }

        public bool Equals(ConsuntivareAmbNonResoTrenitalia other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ConsuntivareAmbNonResoTrenitalia);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
