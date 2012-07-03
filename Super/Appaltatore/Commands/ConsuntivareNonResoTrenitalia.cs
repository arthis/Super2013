using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using CommonDomain.Core;

namespace Super.Appaltatore.Commands
{

    public abstract class ConsuntivareNonResoTrenitalia : CommandBase
    {

        public string Note { get; set; }
        public Guid IdCausaleTrenitalia { get; set; }
        public DateTime DataConsuntivazione { get; set; }
        public string IdInterventoAppaltatore { get; set; }

        //for serialization
        public ConsuntivareNonResoTrenitalia()
        {
            
        }

        public ConsuntivareNonResoTrenitalia(Guid id,
                                Guid commitId,
                                long version,
                                string idInterventoAppaltatore,
                                DateTime dataConsuntivazione,
                                Guid idCausaleTrenitalia,
                                string note)
            :base(id,commitId,version)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(idInterventoAppaltatore));
            Contract.Requires<ArgumentNullException>(dataConsuntivazione > DateTime.MinValue);
            Contract.Requires<ArgumentNullException>(idCausaleTrenitalia != Guid.Empty);
            
            IdInterventoAppaltatore = idInterventoAppaltatore;
            DataConsuntivazione = dataConsuntivazione;
            IdCausaleTrenitalia = idCausaleTrenitalia;
            Note = note;
        }


        public override string ToDescription()
        {
            return string.Format("Consuntivare non reso trenitalia il intervento rotabile '{0}' ", Id);
        }

        public bool Equals(ConsuntivareNonResoTrenitalia other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Note, Note) && other.IdCausaleTrenitalia.Equals(IdCausaleTrenitalia) && other.DataConsuntivazione.Equals(DataConsuntivazione) && Equals(other.IdInterventoAppaltatore, IdInterventoAppaltatore);
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
                result = (result*397) ^ (Note != null ? Note.GetHashCode() : 0);
                result = (result*397) ^ IdCausaleTrenitalia.GetHashCode();
                result = (result*397) ^ DataConsuntivazione.GetHashCode();
                result = (result*397) ^ (IdInterventoAppaltatore != null ? IdInterventoAppaltatore.GetHashCode() : 0);
                return result;
            }
        }
    }

    
    public class ConsuntivareRotNonResoTrenitalia : ConsuntivareNonResoTrenitalia
    {
        //for serialization
        public ConsuntivareRotNonResoTrenitalia()
        {
            
        }

        public ConsuntivareRotNonResoTrenitalia(Guid id, Guid commitId,
                                long version, string idInterventoAppaltatore, DateTime dataConsuntivazione, Guid idCausaleTrenitalia, string note)
            : base(id, commitId, version, idInterventoAppaltatore, dataConsuntivazione, idCausaleTrenitalia, note)
        {
        }

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
        //for serialization
        public ConsuntivareRotManNonResoTrenitalia()
        {
            
        }
        public ConsuntivareRotManNonResoTrenitalia(Guid id, Guid commitId,
                                long version, string idInterventoAppaltatore, DateTime dataConsuntivazione, Guid idCausaleTrenitalia, string note)
            : base(id, commitId, version, idInterventoAppaltatore, dataConsuntivazione, idCausaleTrenitalia, note)
        {
        }

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
        //for serialization
        public ConsuntivareAmbNonResoTrenitalia()
        {
            
        }

        public ConsuntivareAmbNonResoTrenitalia(Guid id, Guid commitId,
                                long version, string idInterventoAppaltatore, DateTime dataConsuntivazione, Guid idCausaleTrenitalia, string note)
            : base(id, commitId, version, idInterventoAppaltatore, dataConsuntivazione, idCausaleTrenitalia, note)
        {
        }

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
