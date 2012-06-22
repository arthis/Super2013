using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;

namespace Super.Appaltatore.Commands
{
    public abstract class ConsuntivareNonReso : CommandBase
    {
        private readonly string _idInterventoAppaltatore;
        private readonly DateTime _dataConsuntivazione;
        private readonly Guid _idCausaleAppaltatore;
        private readonly string _note;

        public string Note
        {
            get { return _note; }
        }
        public Guid IdCausaleAppaltatore
        {
            get { return _idCausaleAppaltatore; }
        }
        public DateTime DataConsuntivazione
        {
            get { return _dataConsuntivazione; }
        }
        public string IdInterventoAppaltatore
        {
            get { return _idInterventoAppaltatore; }
        }

        public ConsuntivareNonReso(Guid id,
                                string idInterventoAppaltatore,
                                DateTime dataConsuntivazione,
                                Guid idCausaleAppaltatore,
                                string note)
        {
            Contract.Requires<ArgumentNullException>(id==null || id == Guid.Empty);
            Contract.Requires<ArgumentNullException>(string.IsNullOrEmpty(idInterventoAppaltatore));
            Contract.Requires<ArgumentNullException>(dataConsuntivazione== DateTime.MinValue);
            Contract.Requires<ArgumentNullException>(idCausaleAppaltatore == null || idCausaleAppaltatore == Guid.Empty);

            Id = id;
            _idInterventoAppaltatore = idInterventoAppaltatore;
            _dataConsuntivazione = dataConsuntivazione;
            _idCausaleAppaltatore = idCausaleAppaltatore;
            _note = note;
        }

        public bool Equals(ConsuntivareNonReso other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other._idInterventoAppaltatore, _idInterventoAppaltatore) && other._dataConsuntivazione.Equals(_dataConsuntivazione) && other._idCausaleAppaltatore.Equals(_idCausaleAppaltatore) && Equals(other._note, _note);
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
                result = (result*397) ^ (_idInterventoAppaltatore != null ? _idInterventoAppaltatore.GetHashCode() : 0);
                result = (result*397) ^ _dataConsuntivazione.GetHashCode();
                result = (result*397) ^ _idCausaleAppaltatore.GetHashCode();
                result = (result*397) ^ (_note != null ? _note.GetHashCode() : 0);
                return result;
            }
        }
    }

    
    public class ConsuntivareRotNonReso : ConsuntivareNonReso
    {

        public ConsuntivareRotNonReso(Guid id,
                                string idInterventoAppaltatore,
                                DateTime dataConsuntivazione,
                                Guid idCausaleAppaltatore,
                                string note)
            : base (id,idInterventoAppaltatore,dataConsuntivazione, idCausaleAppaltatore, note)
        {
            
        }

        public override string ToDescription()
        {
            return string.Format("Si consuntiva non reso il intervento rotabile '{0}' ", Id);
        }


        
    }

    
    public class ConsuntivareRotManNonReso : ConsuntivareNonReso
    {
        public ConsuntivareRotManNonReso(Guid id,
                                string idInterventoAppaltatore,
                                DateTime dataConsuntivazione,
                                Guid idCausaleAppaltatore,
                                string note)
            : base (id,idInterventoAppaltatore,dataConsuntivazione, idCausaleAppaltatore, note)
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
        public ConsuntivareAmbNonReso(Guid id,
                                string idInterventoAppaltatore,
                                DateTime dataConsuntivazione,
                                Guid idCausaleAppaltatore,
                                string note)
            : base (id,idInterventoAppaltatore,dataConsuntivazione, idCausaleAppaltatore, note)
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
