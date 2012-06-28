﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Appaltatore.Events.Consuntivazione
{
    public abstract class InterventoConsuntivatoNonReso : Message
    {


        public string Note { get; set; }
        public Guid IdCausaleAppaltatore { get; set; }
        public DateTime DataConsuntivazione { get; set; }
        public string IdInterventoAppaltatore { get; set; }

        //for serialization
        public InterventoConsuntivatoNonReso()
        {
            
        }

        public InterventoConsuntivatoNonReso(Guid id,
                                string idInterventoAppaltatore,
                                DateTime dataConsuntivazione,
                                Guid idCausaleAppaltatore,
                                string note)
        {
            Contract.Requires<ArgumentNullException>(id != Guid.Empty);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(idInterventoAppaltatore));
            Contract.Requires<ArgumentNullException>(dataConsuntivazione > DateTime.MinValue);
            Contract.Requires<ArgumentNullException>(idCausaleAppaltatore != Guid.Empty);

            Id = id;
            IdInterventoAppaltatore = idInterventoAppaltatore;
            DataConsuntivazione = dataConsuntivazione;
            IdCausaleAppaltatore = idCausaleAppaltatore;
            Note = note;
        }

        public bool Equals(InterventoConsuntivatoNonReso other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Note, Note) && other.IdCausaleAppaltatore.Equals(IdCausaleAppaltatore) && other.DataConsuntivazione.Equals(DataConsuntivazione) && Equals(other.IdInterventoAppaltatore, IdInterventoAppaltatore);
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
                result = (result*397) ^ (Note != null ? Note.GetHashCode() : 0);
                result = (result*397) ^ IdCausaleAppaltatore.GetHashCode();
                result = (result*397) ^ DataConsuntivazione.GetHashCode();
                result = (result*397) ^ (IdInterventoAppaltatore != null ? IdInterventoAppaltatore.GetHashCode() : 0);
                return result;
            }
        }
    }

    public class InterventoConsuntivatoRotNonReso : InterventoConsuntivatoNonReso, IInterventoRotConsuntivato
    {
        //for serialization
        public InterventoConsuntivatoRotNonReso()
        {
            
        }

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
        //for serialization
        public InterventoConsuntivatoRotManNonReso()
        {
            
        }

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
        //for serialization
        public InterventoConsuntivatoAmbNonReso()
        {
            
        }

        
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
