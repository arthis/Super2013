﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Appaltatore.Events.Consuntivazione
{
    public abstract class InterventoConsuntivatoNonResoTrenitalia : Message, IEvent
    {
        public Guid Id { get; set; }
        public string IdInterventoAppaltatore { get; set; }
        public DateTime DataConsuntivazione { get; set; }
        public Guid IdCausale { get; set; }
        public string Note { get; set; }

        public bool Equals(InterventoConsuntivatoNonResoTrenitalia other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.Id.Equals(Id) && Equals(other.IdInterventoAppaltatore, IdInterventoAppaltatore) && other.DataConsuntivazione.Equals(DataConsuntivazione) && other.IdCausale.Equals(IdCausale) && Equals(other.Note, Note);
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
                result = (result*397) ^ Id.GetHashCode();
                result = (result*397) ^ (IdInterventoAppaltatore != null ? IdInterventoAppaltatore.GetHashCode() : 0);
                result = (result*397) ^ DataConsuntivazione.GetHashCode();
                result = (result*397) ^ IdCausale.GetHashCode();
                result = (result*397) ^ (Note != null ? Note.GetHashCode() : 0);
                return result;
            }
        }
    }

    public class InterventoConsuntivatoRotNonResoTrenitalia : InterventoConsuntivatoNonResoTrenitalia, IInterventoRotConsuntivato
    {
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
