using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Appaltatore.Events.Consuntivazione
{
    public abstract class InterventoConsuntivatoNonResoTrenitalia : Message, IEvent
    {
        private Guid _id;
        private readonly string _idInterventoAppaltatore;
        private readonly DateTime _dataConsuntivazione;
        private readonly Guid _idCausaleTrenitalia;
        private readonly string _note;

        public Guid Id
        {
            get { return _id; }
        }
        public string Note
        {
            get { return _note; }
        }
        public Guid IdCausaleTrenitalia
        {
            get { return _idCausaleTrenitalia; }
        }
        public DateTime DataConsuntivazione
        {
            get { return _dataConsuntivazione; }
        }
        public string IdInterventoAppaltatore
        {
            get { return _idInterventoAppaltatore; }
        }

        //for serialization 
        public InterventoConsuntivatoNonResoTrenitalia()
        {
            
        }

        public InterventoConsuntivatoNonResoTrenitalia(Guid id,
                                                       string idInterventoAppaltatore,
                                                       DateTime dataConsuntivazione,
                                                       Guid idCausaleTrenitalia,
                                                       string note)
        {
            Contract.Requires<ArgumentNullException>(id == Guid.Empty);
            Contract.Requires<ArgumentNullException>(string.IsNullOrEmpty(idInterventoAppaltatore));
            Contract.Requires<ArgumentNullException>(dataConsuntivazione == DateTime.MinValue);
            Contract.Requires<ArgumentNullException>(idCausaleTrenitalia == Guid.Empty);

            _id = id;
            _idInterventoAppaltatore = idInterventoAppaltatore;
            _dataConsuntivazione = dataConsuntivazione;
            _idCausaleTrenitalia = idCausaleTrenitalia;
            _note = note;
        }

        public bool Equals(InterventoConsuntivatoNonResoTrenitalia other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other._id.Equals(_id) && Equals(other._idInterventoAppaltatore, _idInterventoAppaltatore) && other._dataConsuntivazione.Equals(_dataConsuntivazione) && other._idCausaleTrenitalia.Equals(_idCausaleTrenitalia) && Equals(other._note, _note);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoConsuntivatoNonResoTrenitalia);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ _id.GetHashCode();
                result = (result*397) ^ (_idInterventoAppaltatore != null ? _idInterventoAppaltatore.GetHashCode() : 0);
                result = (result*397) ^ _dataConsuntivazione.GetHashCode();
                result = (result*397) ^ _idCausaleTrenitalia.GetHashCode();
                result = (result*397) ^ (_note != null ? _note.GetHashCode() : 0);
                return result;
            }
        }
    }

    public class InterventoConsuntivatoRotNonResoTrenitalia : InterventoConsuntivatoNonResoTrenitalia, IInterventoRotConsuntivato
    {
        //for serialization
        public InterventoConsuntivatoRotNonResoTrenitalia()
        {
            
        }

        public InterventoConsuntivatoRotNonResoTrenitalia(Guid id, string idInterventoAppaltatore, DateTime dataConsuntivazione, Guid idCausaleTrenitalia, string note) : base(id, idInterventoAppaltatore, dataConsuntivazione, idCausaleTrenitalia, note)
        {
        }

        public override string ToDescription()
        {
            return string.Format("Il intervento rotabile '{0}' é stato consuntivato non reso Trenitalia.", Id);
        }

        public bool Equals(InterventoConsuntivatoRotNonResoTrenitalia other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoConsuntivatoRotNonResoTrenitalia);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public class InterventoConsuntivatoRotManNonResoTrenitalia : InterventoConsuntivatoNonResoTrenitalia, IInterventoRotManConsuntivato
    {

        //for serialization
        public InterventoConsuntivatoRotManNonResoTrenitalia()
        {
            

        }

        public InterventoConsuntivatoRotManNonResoTrenitalia(Guid id, string idInterventoAppaltatore, DateTime dataConsuntivazione, Guid idCausaleTrenitalia, string note) : base(id, idInterventoAppaltatore, dataConsuntivazione, idCausaleTrenitalia, note)
        {
        }

        public override string ToDescription()
        {
            return string.Format("Il intervento rotabile in manutenzione '{0}' é stato consuntivato non reso Trenitalia.", Id);
        }

        public bool Equals(InterventoConsuntivatoRotManNonResoTrenitalia other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoConsuntivatoRotManNonResoTrenitalia);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public class InterventoConsuntivatoAmbNonResoTrenitalia : InterventoConsuntivatoNonResoTrenitalia, IInterventoAmbConsuntivato
    {

        //for serialization
        public InterventoConsuntivatoAmbNonResoTrenitalia()
        {
            
        }

        public InterventoConsuntivatoAmbNonResoTrenitalia(Guid id, string idInterventoAppaltatore, DateTime dataConsuntivazione, Guid idCausaleTrenitalia, string note) : base(id, idInterventoAppaltatore, dataConsuntivazione, idCausaleTrenitalia, note)
        {
        }

        public override string ToDescription()
        {
            return string.Format("Il intervento ambiente '{0}' é stato consuntivato non reso Trenitalia.", Id);
        }

        public bool Equals(InterventoConsuntivatoAmbNonResoTrenitalia other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoConsuntivatoAmbNonResoTrenitalia);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
