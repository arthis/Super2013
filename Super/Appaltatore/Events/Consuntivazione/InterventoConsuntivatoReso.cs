using System;
using System.Diagnostics.Contracts;
using System.Linq;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Appaltatore.Events.Consuntivazione
{
    public abstract class InterventoConsuntivatoReso : Message, IEvent
    {
        public InterventoConsuntivatoReso()
        {
        }

        public InterventoConsuntivatoReso(Guid id,
                                          Guid commitId,
                                          long version,
                                          string idInterventoAppaltatore,
                                          DateTime dataConsuntivazione,
                                          WorkPeriod period,
                                          string note)
            : base(id, commitId, version)
        {
            Contract.Requires(id != Guid.Empty);
            Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));
            Contract.Requires(dataConsuntivazione > DateTime.MinValue);
            Contract.Requires(period != null);

            Id = id;
            IdInterventoAppaltatore = idInterventoAppaltatore;
            DataConsuntivazione = dataConsuntivazione;
            Period = period;
            Note = note;
        }

        public string Note { get; set; }
        public WorkPeriod Period { get; set; }
        public string IdInterventoAppaltatore { get; set; }
        public DateTime DataConsuntivazione { get; set; }

        //for serialization

        public bool Equals(InterventoConsuntivatoReso other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Note, Note) && Equals(other.Period, Period) &&
                   Equals(other.IdInterventoAppaltatore, IdInterventoAppaltatore) &&
                   other.DataConsuntivazione.Equals(DataConsuntivazione);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoConsuntivatoReso);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ (Note != null ? Note.GetHashCode() : 0);
                result = (result*397) ^ (Period != null ? Period.GetHashCode() : 0);
                result = (result*397) ^ (IdInterventoAppaltatore != null ? IdInterventoAppaltatore.GetHashCode() : 0);
                result = (result*397) ^ DataConsuntivazione.GetHashCode();
                return result;
            }
        }
    }

    public class InterventoConsuntivatoRotReso : InterventoConsuntivatoReso, IInterventoRotConsuntivato
    {
        public InterventoConsuntivatoRotReso()
        {
        }

        public InterventoConsuntivatoRotReso(Guid id, Guid commitId, long version, string idInterventoAppaltatore,
                                             DateTime dataConsuntivazione, WorkPeriod period, string note,
                                             OggettoRot[] oggetti, Treno trenoPartenza, Treno trenoArrivo,
                                             string turnoTreno, string rigaTurnoTreno, string convoglio)
            : base(id, commitId, version, idInterventoAppaltatore, dataConsuntivazione, period, note)
        {
            Oggetti = oggetti;
            TrenoPartenza = trenoPartenza;
            TrenoArrivo = trenoArrivo;
            TurnoTreno = turnoTreno;
            RigaTurnoTreno = rigaTurnoTreno;
            Convoglio = convoglio;
        }

        public string Convoglio { get; set; }
        public string RigaTurnoTreno { get; set; }
        public string TurnoTreno { get; set; }
        public Treno TrenoArrivo { get; set; }
        public Treno TrenoPartenza { get; set; }
        public OggettoRot[] Oggetti { get; set; }


        //for serialization

        #region IInterventoRotConsuntivato Members

        public override string ToDescription()
        {
            return string.Format("Il intervento rotabile '{0}' é stato consuntivato reso.", Id);
        }

        #endregion

        public bool Equals(InterventoConsuntivatoRotReso other)
        {
            Contract.Requires(Oggetti.First() != null);

            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Convoglio, Convoglio) &&
                   Equals(other.RigaTurnoTreno, RigaTurnoTreno) && Equals(other.TurnoTreno, TurnoTreno) &&
                   Equals(other.TrenoArrivo, TrenoArrivo) && Equals(other.TrenoPartenza, TrenoPartenza) &&
                   Oggetti.SequenceEqual(other.Oggetti);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoConsuntivatoRotReso);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ (Convoglio != null ? Convoglio.GetHashCode() : 0);
                result = (result*397) ^ (RigaTurnoTreno != null ? RigaTurnoTreno.GetHashCode() : 0);
                result = (result*397) ^ (TurnoTreno != null ? TurnoTreno.GetHashCode() : 0);
                result = (result*397) ^ (TrenoArrivo != null ? TrenoArrivo.GetHashCode() : 0);
                result = (result*397) ^ (TrenoPartenza != null ? TrenoPartenza.GetHashCode() : 0);
                result = (result*397) ^ (Oggetti != null ? Oggetti.GetHashCode() : 0);
                return result;
            }
        }
    }

    public class InterventoConsuntivatoRotManReso : InterventoConsuntivatoReso, IInterventoRotManConsuntivato
    {
        //for serialization
        public InterventoConsuntivatoRotManReso()
        {
        }

        public InterventoConsuntivatoRotManReso(Guid id, Guid commitId, long version, string idInterventoAppaltatore,
                                                DateTime dataConsuntivazione, WorkPeriod period, string note,
                                                OggettoRotMan[] oggetti)
            : base(id, commitId, version, idInterventoAppaltatore, dataConsuntivazione, period, note)
        {
            Oggetti = oggetti;
        }

        public OggettoRotMan[] Oggetti { get; set; }

        #region IInterventoRotManConsuntivato Members

        public override string ToDescription()
        {
            return string.Format("Il intervento rotabile in manutenzione '{0}' é stato consuntivato reso.", Id);
        }

        #endregion

        public bool Equals(InterventoConsuntivatoRotManReso other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.Oggetti.SequenceEqual(Oggetti);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoConsuntivatoRotManReso);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ (Oggetti != null ? Oggetti.GetHashCode() : 0);
            }
        }
    }

    public class InterventoConsuntivatoAmbReso : InterventoConsuntivatoReso, IInterventoAmbConsuntivato
    {
        //for serialization
        public InterventoConsuntivatoAmbReso()
        {
        }

        public InterventoConsuntivatoAmbReso(Guid id,
                                             Guid commitId,
                                             long version,
                                             string idInterventoAppaltatore,
                                             DateTime dataConsuntivazione,
                                             WorkPeriod period,
                                             string note,
                                             int quantity,
                                             string description)
            : base(id, commitId, version, idInterventoAppaltatore, dataConsuntivazione, period, note)
        {
            Contract.Requires(quantity >= 0);

            Quantity = quantity;
            Description = description;
        }


        public string Description { get; set; }
        public int Quantity { get; set; }

        #region IInterventoAmbConsuntivato Members

        public override string ToDescription()
        {
            return string.Format("Il intervento ambiente '{0}' é stato consuntivato reso.", Id);
        }

        #endregion

        public bool Equals(InterventoConsuntivatoAmbReso other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Description, Description) && other.Quantity == Quantity;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoConsuntivatoAmbReso);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
                result = (result*397) ^ Quantity;
                return result;
            }
        }
    }
}