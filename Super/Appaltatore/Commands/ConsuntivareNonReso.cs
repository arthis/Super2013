using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;

namespace Super.Appaltatore.Commands
{
    public abstract class ConsuntivareNonReso : CommandBase
    {

        public string Note { get; set; }
        public Guid IdCausaleAppaltatore { get; set; }
        public DateTime DataConsuntivazione { get; set; }
        public string IdInterventoAppaltatore { get; set; }

        //for serialization
        public ConsuntivareNonReso()
        {
            
        }

        public ConsuntivareNonReso(Guid id,
                                Guid commitId,
                                long version,
                                string idInterventoAppaltatore,
                                DateTime dataConsuntivazione,
                                Guid idCausaleAppaltatore,
                                string note)
            :base (id,commitId, version)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(idInterventoAppaltatore));
            Contract.Requires<ArgumentNullException>(dataConsuntivazione > DateTime.MinValue);
            Contract.Requires<ArgumentNullException>(idCausaleAppaltatore != Guid.Empty);

            IdInterventoAppaltatore = idInterventoAppaltatore;
            DataConsuntivazione = dataConsuntivazione;
            IdCausaleAppaltatore = idCausaleAppaltatore;
            Note = note;
        }


        public override string ToDescription()
        {
            return string.Format("Consuntivare non reso il intervento rotabile '{0}' ", Id);
        }

        public bool Equals(ConsuntivareNonReso other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Note, Note) && other.IdCausaleAppaltatore.Equals(IdCausaleAppaltatore) && other.DataConsuntivazione.Equals(DataConsuntivazione) && Equals(other.IdInterventoAppaltatore, IdInterventoAppaltatore);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ConsuntivareNonReso);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ (Note != null ? Note.GetHashCode() : 0);
                result = (result*397) ^ IdCausaleAppaltatore.GetHashCode();
                result = (result*397) ^ DataConsuntivazione.GetHashCode();
                result = (result*397) ^ (IdInterventoAppaltatore != null ? IdInterventoAppaltatore.GetHashCode() : 0);
                return result;
            }
        }
    }

    
    public class ConsuntivareRotNonReso : ConsuntivareNonReso
    {

        //for serialization
        public ConsuntivareRotNonReso()
        {
            
        }

        public ConsuntivareRotNonReso(Guid id,
                                Guid commitId,
                                long version,
                                string idInterventoAppaltatore,
                                DateTime dataConsuntivazione,
                                Guid idCausaleAppaltatore,
                                string note)
            : base (id,commitId,version, idInterventoAppaltatore,dataConsuntivazione, idCausaleAppaltatore, note)
        {
            
        }

        public override string ToDescription()
        {
            return string.Format("Si consuntiva non reso il intervento rotabile '{0}' ", Id);
        }


        
    }

    
    public class ConsuntivareRotManNonReso : ConsuntivareNonReso
    {
        //for serialization
        public ConsuntivareRotManNonReso()
        {
            
        }

        public ConsuntivareRotManNonReso(Guid id,
                                Guid commitId,
                                long version,
                                string idInterventoAppaltatore,
                                DateTime dataConsuntivazione,
                                Guid idCausaleAppaltatore,
                                string note)
            : base(id, commitId, version, idInterventoAppaltatore, dataConsuntivazione, idCausaleAppaltatore, note)
        {
            
        }
       
        public override string ToDescription()
        {
            return string.Format("Si consuntiva non reso il intervento rotabile in manutenzione '{0}' ", Id);
        }

        public bool Equals(ConsuntivareRotManNonReso other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ConsuntivareRotManNonReso);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    
    public class ConsuntivareAmbNonReso : ConsuntivareNonReso
    {
        //for serialization
        public ConsuntivareAmbNonReso()
        {
            
        }

        public ConsuntivareAmbNonReso(Guid id,
                                Guid commitId,
                                long version,
                                string idInterventoAppaltatore,
                                DateTime dataConsuntivazione,
                                Guid idCausaleAppaltatore,
                                string note)
            : base(id, commitId, version, idInterventoAppaltatore, dataConsuntivazione, idCausaleAppaltatore, note)
        {
            
        }

        public override string ToDescription()
        {
            return string.Format("Si consuntiva non reso il intervento ambiente '{0}' ", Id);
        }


        public bool Equals(ConsuntivareAmbNonReso other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ConsuntivareAmbNonReso);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

}
