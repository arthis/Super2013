using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Appaltatore.Events.Consuntivazione
{
    public abstract class InterventoConsuntivatoNonResoTrenitalia : Message, IEvent
    {
        public InterventoConsuntivatoNonResoTrenitalia()
        {
        }

        public InterventoConsuntivatoNonResoTrenitalia(Guid id,
                                                       Guid commitId,
                                                       long version,
                                                       string idInterventoAppaltatore,
                                                       DateTime dataConsuntivazione,
                                                       Guid idCausaleTrenitalia,
                                                       string note)
            : base(id, commitId, version)
        {
            Contract.Requires<ArgumentNullException>(id != Guid.Empty);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(idInterventoAppaltatore));
            Contract.Requires<ArgumentNullException>(dataConsuntivazione > DateTime.MinValue);
            Contract.Requires<ArgumentNullException>(idCausaleTrenitalia != Guid.Empty);

            Id = id;
            IdInterventoAppaltatore = idInterventoAppaltatore;
            DataConsuntivazione = dataConsuntivazione;
            IdCausaleTrenitalia = idCausaleTrenitalia;
            Note = note;
        }

        public string Note { get; set; }
        public Guid IdCausaleTrenitalia { get; set; }
        public DateTime DataConsuntivazione { get; set; }
        public string IdInterventoAppaltatore { get; set; }

        //for serialization 

        public bool Equals(InterventoConsuntivatoNonResoTrenitalia other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Note, Note) &&
                   other.IdCausaleTrenitalia.Equals(IdCausaleTrenitalia) &&
                   other.DataConsuntivazione.Equals(DataConsuntivazione) &&
                   Equals(other.IdInterventoAppaltatore, IdInterventoAppaltatore);
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
                result = (result*397) ^ (Note != null ? Note.GetHashCode() : 0);
                result = (result*397) ^ IdCausaleTrenitalia.GetHashCode();
                result = (result*397) ^ DataConsuntivazione.GetHashCode();
                result = (result*397) ^ (IdInterventoAppaltatore != null ? IdInterventoAppaltatore.GetHashCode() : 0);
                return result;
            }
        }
    }

    public class InterventoConsuntivatoRotNonResoTrenitalia : InterventoConsuntivatoNonResoTrenitalia,
                                                              IInterventoRotConsuntivato
    {
        //for serialization
        public InterventoConsuntivatoRotNonResoTrenitalia()
        {
        }

        public InterventoConsuntivatoRotNonResoTrenitalia(Guid id, Guid commitId, long version,
                                                          string idInterventoAppaltatore, DateTime dataConsuntivazione,
                                                          Guid idCausaleTrenitalia, string note)
            : base(id, commitId, version, idInterventoAppaltatore, dataConsuntivazione, idCausaleTrenitalia, note)
        {
        }

        #region IInterventoRotConsuntivato Members

        public override string ToDescription()
        {
            return string.Format("Il intervento rotabile '{0}' é stato consuntivato non reso Trenitalia.", Id);
        }

        #endregion

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

    public class InterventoConsuntivatoRotManNonResoTrenitalia : InterventoConsuntivatoNonResoTrenitalia,
                                                                 IInterventoRotManConsuntivato
    {
        //for serialization
        public InterventoConsuntivatoRotManNonResoTrenitalia()
        {
        }

        public InterventoConsuntivatoRotManNonResoTrenitalia(Guid id, Guid commitId, long version,
                                                             string idInterventoAppaltatore,
                                                             DateTime dataConsuntivazione, Guid idCausaleTrenitalia,
                                                             string note)
            : base(id, commitId, version, idInterventoAppaltatore, dataConsuntivazione, idCausaleTrenitalia, note)
        {
        }

        #region IInterventoRotManConsuntivato Members

        public override string ToDescription()
        {
            return
                string.Format("Il intervento rotabile in manutenzione '{0}' é stato consuntivato non reso Trenitalia.",
                              Id);
        }

        #endregion

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

    public class InterventoConsuntivatoAmbNonResoTrenitalia : InterventoConsuntivatoNonResoTrenitalia,
                                                              IInterventoAmbConsuntivato
    {
        //for serialization
        public InterventoConsuntivatoAmbNonResoTrenitalia()
        {
        }

        public InterventoConsuntivatoAmbNonResoTrenitalia(Guid id, Guid commitId, long version,
                                                          string idInterventoAppaltatore, DateTime dataConsuntivazione,
                                                          Guid idCausaleTrenitalia, string note)
            : base(id, commitId, version, idInterventoAppaltatore, dataConsuntivazione, idCausaleTrenitalia, note)
        {
        }

        #region IInterventoAmbConsuntivato Members

        public override string ToDescription()
        {
            return string.Format("Il intervento ambiente '{0}' é stato consuntivato non reso Trenitalia.", Id);
        }

        #endregion

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