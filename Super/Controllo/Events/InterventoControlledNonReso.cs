using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Controllo.Events
{
    public class InterventoControlledNonReso : Message , IEvent
    {
        private readonly Guid _idUser;
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
        public Guid IdUser
        {
            get { return _idUser; }
        }

        //for serialization
        public InterventoControlledNonReso()
        {
            
        }

        public InterventoControlledNonReso(Guid id, Guid commitId, long version, Guid idUser, DateTime controlDate, Guid idCausale, string note)
            : base(id, commitId, version)
        {
            
            Contract.Requires( idUser != Guid.Empty);
            Contract.Requires<ArgumentOutOfRangeException>(controlDate > DateTime.MinValue);
            Contract.Requires(idCausale != Guid.Empty);

            
            _idUser = idUser;
            _controlDate = controlDate;
            _idCausale = idCausale;
            _note = note;
        }
        public override string ToDescription()
        {
            return string.Format("Il intervento '{0}' é stato controllato non reso.", Id);
        }


        public bool Equals(InterventoControlledNonReso other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other._idUser.Equals(_idUser) && other._controlDate.Equals(_controlDate) && other._idCausale.Equals(_idCausale) && Equals(other._note, _note);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoControlledNonReso);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                
                result = (result*397) ^ _idUser.GetHashCode();
                result = (result*397) ^ _controlDate.GetHashCode();
                result = (result*397) ^ _idCausale.GetHashCode();
                result = (result*397) ^ (_note != null ? _note.GetHashCode() : 0);
                return result;
            }
        }
    }
	
}
