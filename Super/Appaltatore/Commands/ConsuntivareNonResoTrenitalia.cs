using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using CommonDomain.Core;

namespace Super.Appaltatore.Commands
{

    public abstract class ConsuntivareNonResoTrenitalia : CommandBase
    {
        private readonly string _idInterventoAppaltatore;
        private readonly DateTime _dataConsuntivazione;
        private readonly Guid _idCausaleTrenitalia;
        private readonly string _note;

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
        public ConsuntivareNonResoTrenitalia()
        {
            
        }

        public ConsuntivareNonResoTrenitalia(Guid id,
                                string idInterventoAppaltatore,
                                DateTime dataConsuntivazione,
                                Guid idCausaleTrenitalia,
                                string note)
        {
            Contract.Requires<ArgumentNullException>(id == Guid.Empty);
            Contract.Requires<ArgumentNullException>(string.IsNullOrEmpty(idInterventoAppaltatore));
            Contract.Requires<ArgumentNullException>(dataConsuntivazione == DateTime.MinValue);
            Contract.Requires<ArgumentNullException>(idCausaleTrenitalia == Guid.Empty);

            Id = id;
            _idInterventoAppaltatore = idInterventoAppaltatore;
            _dataConsuntivazione = dataConsuntivazione;
            _idCausaleTrenitalia = idCausaleTrenitalia;
            _note = note;
        }


        public override string ToDescription()
        {
            return string.Format("Consuntivare non reso trenitalia il intervento rotabile '{0}' ", Id);
        }

        public bool Equals(ConsuntivareNonResoTrenitalia other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other._idInterventoAppaltatore, _idInterventoAppaltatore) && other._dataConsuntivazione.Equals(_dataConsuntivazione) && other._idCausaleTrenitalia.Equals(_idCausaleTrenitalia) && Equals(other._note, _note);
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
                result = (result*397) ^ (_idInterventoAppaltatore != null ? _idInterventoAppaltatore.GetHashCode() : 0);
                result = (result*397) ^ _dataConsuntivazione.GetHashCode();
                result = (result*397) ^ _idCausaleTrenitalia.GetHashCode();
                result = (result*397) ^ (_note != null ? _note.GetHashCode() : 0);
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

        public ConsuntivareRotNonResoTrenitalia(Guid id, string idInterventoAppaltatore, DateTime dataConsuntivazione, Guid idCausaleTrenitalia, string note) : base(id, idInterventoAppaltatore, dataConsuntivazione, idCausaleTrenitalia, note)
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
        public ConsuntivareRotManNonResoTrenitalia(Guid id, string idInterventoAppaltatore, DateTime dataConsuntivazione, Guid idCausaleTrenitalia, string note) : base(id, idInterventoAppaltatore, dataConsuntivazione, idCausaleTrenitalia, note)
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

        public ConsuntivareAmbNonResoTrenitalia(Guid id, string idInterventoAppaltatore, DateTime dataConsuntivazione, Guid idCausaleTrenitalia, string note) : base(id, idInterventoAppaltatore, dataConsuntivazione, idCausaleTrenitalia, note)
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
