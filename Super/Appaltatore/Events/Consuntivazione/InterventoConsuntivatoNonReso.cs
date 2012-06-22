using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Appaltatore.Events.Consuntivazione
{
    public abstract class InterventoConsuntivatoNonReso : Message, IEvent
    {

        private Guid _id;
        private readonly string _idInterventoAppaltatore;
        private readonly DateTime _dataConsuntivazione;
        private readonly Guid _idCausaleAppaltatore;
        private readonly string _note;

        public Guid Id
        {
            get { return _id; }
        }
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

        public InterventoConsuntivatoNonReso(Guid id,
                                string idInterventoAppaltatore,
                                DateTime dataConsuntivazione,
                                Guid idCausaleAppaltatore,
                                string note)
        {
            Contract.Requires<ArgumentNullException>(id == Guid.Empty);
            Contract.Requires<ArgumentNullException>(string.IsNullOrEmpty(idInterventoAppaltatore));
            Contract.Requires<ArgumentNullException>(dataConsuntivazione == DateTime.MinValue);
            Contract.Requires<ArgumentNullException>(idCausaleAppaltatore == Guid.Empty);

            _id = id;
            _idInterventoAppaltatore = idInterventoAppaltatore;
            _dataConsuntivazione = dataConsuntivazione;
            _idCausaleAppaltatore = idCausaleAppaltatore;
            _note = note;
        }

        public bool Equals(InterventoConsuntivatoNonReso other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other._id.Equals(_id) && Equals(other._idInterventoAppaltatore, _idInterventoAppaltatore) && other._dataConsuntivazione.Equals(_dataConsuntivazione) && other._idCausaleAppaltatore.Equals(_idCausaleAppaltatore) && Equals(other._note, _note);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoConsuntivatoNonReso);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ _id.GetHashCode();
                result = (result*397) ^ (_idInterventoAppaltatore != null ? _idInterventoAppaltatore.GetHashCode() : 0);
                result = (result*397) ^ _dataConsuntivazione.GetHashCode();
                result = (result*397) ^ _idCausaleAppaltatore.GetHashCode();
                result = (result*397) ^ (_note != null ? _note.GetHashCode() : 0);
                return result;
            }
        }
    }

    public class InterventoConsuntivatoRotNonReso : InterventoConsuntivatoNonReso, IInterventoRotConsuntivato
    {
        public InterventoConsuntivatoRotNonReso(Guid id, string idInterventoAppaltatore, DateTime dataConsuntivazione, Guid idCausaleAppaltatore, string note) : base(id, idInterventoAppaltatore, dataConsuntivazione, idCausaleAppaltatore, note)
        {
        }

        public override string ToDescription()
        {
            return string.Format("Il intervento rotabile '{0}' é stato consuntivato non reso.", Id);
        }


        public bool Equals(InterventoConsuntivatoRotNonReso other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoConsuntivatoRotNonReso);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public class InterventoConsuntivatoRotManNonReso : InterventoConsuntivatoNonReso, IInterventoRotManConsuntivato
    {
        public InterventoConsuntivatoRotManNonReso(Guid id, string idInterventoAppaltatore, DateTime dataConsuntivazione, Guid idCausaleAppaltatore, string note) : base(id, idInterventoAppaltatore, dataConsuntivazione, idCausaleAppaltatore, note)
        {
        }

        public override string ToDescription()
        {
            return string.Format("Il intervento rotabile in manutenzione '{0}' é stato consuntivato non reso.", Id);
        }

        public bool Equals(InterventoConsuntivatoRotManNonReso other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoConsuntivatoRotManNonReso);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public class InterventoConsuntivatoAmbNonReso : InterventoConsuntivatoNonReso,  IInterventoAmbConsuntivato
    {
        public InterventoConsuntivatoAmbNonReso(Guid id, string idInterventoAppaltatore, DateTime dataConsuntivazione, Guid idCausaleAppaltatore, string note) : base(id, idInterventoAppaltatore, dataConsuntivazione, idCausaleAppaltatore, note)
        {
        }
    

        public override string ToDescription()
        {
            return string.Format("Il intervento ambiente '{0}' é stato consuntivato non reso.", Id);
        }

        public bool Equals(InterventoConsuntivatoAmbNonReso other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoConsuntivatoAmbNonReso);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
