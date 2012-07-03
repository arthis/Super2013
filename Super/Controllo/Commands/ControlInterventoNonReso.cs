using System;
using System.Diagnostics.Contracts;
using System.Linq;
using CommandService;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Controllo.Commands
{

    public class ControlInterventoNonReso : CommandBase
    {
        
        private readonly Guid _idUtente;
        private readonly DateTime _controlDate;
        private readonly Guid _idCausale;
        private readonly string _note;

        public string Note
        {
            get { return _note; }
        }
        public Guid IdCausale
        {
            get { return _idCausale; }
        }
        public DateTime ControlDate
        {
            get { return _controlDate; }
        }
        public Guid IdUtente
        {
            get { return _idUtente; }
        }

        //for serialization
        public ControlInterventoNonReso()
        {
            
        }
        
        public ControlInterventoNonReso(Guid id, Guid commitId, long version, Guid idUtente, DateTime controlDate, Guid idCausale, string note)
            : base(id, commitId, version)
        {
            Contract.Requires<ArgumentNullException>( idUtente != Guid.Empty);
            Contract.Requires<ArgumentOutOfRangeException>(controlDate > DateTime.MinValue);
            Contract.Requires<ArgumentNullException>(idCausale != Guid.Empty);

            _idUtente = idUtente;
            _controlDate = controlDate;
            _idCausale = idCausale;
            _note = note;
        }

        

        public override string ToDescription()
        {
            return string.Format("si controlla non reso il intervento {0}.", Id);
        }

        public bool Equals(ControlInterventoNonReso other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other._idUtente.Equals(_idUtente) && other._controlDate.Equals(_controlDate) && other._idCausale.Equals(_idCausale) && Equals(other._note, _note);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ControlInterventoNonReso);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ _idUtente.GetHashCode();
                result = (result*397) ^ _controlDate.GetHashCode();
                result = (result*397) ^ _idCausale.GetHashCode();
                result = (result*397) ^ (_note != null ? _note.GetHashCode() : 0);
                return result;
            }
        }
    }

    
}
