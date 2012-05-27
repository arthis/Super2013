using System;
using System.Linq;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super;

namespace Super.Appaltatore.Events.Programmazione
{
    public abstract class InterventoProgrammato : Message, IEvent
    {
        public Guid Id { get; set; }
        public Guid IdAreaIntervento { get; set; }
        public Guid IdTipoIntervento { get; set; }
        public Guid IdAppaltatore { get; set; }
        public Guid IdCategoriaCommerciale { get; set; }
        public Guid IdDirezioneRegionale { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Note { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoProgrammato);
        }

        public bool Equals(InterventoProgrammato other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.Id.Equals(Id) && other.IdAreaIntervento.Equals(IdAreaIntervento) && other.IdTipoIntervento.Equals(IdTipoIntervento) && other.IdAppaltatore.Equals(IdAppaltatore) && other.IdCategoriaCommerciale.Equals(IdCategoriaCommerciale) && other.IdDirezioneRegionale.Equals(IdDirezioneRegionale) && other.Start.Equals(Start) && other.End.Equals(End) && Equals(other.Note, Note);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result * 397) ^ Id.GetHashCode();
                result = (result * 397) ^ IdAreaIntervento.GetHashCode();
                result = (result * 397) ^ IdTipoIntervento.GetHashCode();
                result = (result * 397) ^ IdAppaltatore.GetHashCode();
                result = (result * 397) ^ IdCategoriaCommerciale.GetHashCode();
                result = (result * 397) ^ IdDirezioneRegionale.GetHashCode();
                result = (result * 397) ^ Start.GetHashCode();
                result = (result * 397) ^ End.GetHashCode();
                result = (result * 397) ^ (Note != null ? Note.GetHashCode() : 0);
                return result;
            }
        }

    }

    public class InterventoRotPianificato : InterventoProgrammato
    {
        public OggettoRot[] Oggetti { get; set; }
        public string NumeroTrenoArrivo { get; set; }
        public DateTime DataTrenoArrivo { get; set; }
        public string NumeroTrenoPartenza { get; set; }
        public DateTime DataTrenoPartenza { get; set; }
        public string TurnoTreno { get; set; }
        public string RigaTurnoTreno { get; set; }
        public string Convoglio { get; set; }

        public override string ToDescription()
        {
            return string.Format("Il intervento rotabile '{0}' é stato programmato.", Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoRotPianificato);
        }

        public bool Equals(InterventoRotPianificato other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.Oggetti.SequenceEqual(Oggetti) && Equals(other.NumeroTrenoArrivo, NumeroTrenoArrivo) && other.DataTrenoArrivo.Equals(DataTrenoArrivo) && Equals(other.NumeroTrenoPartenza, NumeroTrenoPartenza) && other.DataTrenoPartenza.Equals(DataTrenoPartenza) && Equals(other.TurnoTreno, TurnoTreno) && Equals(other.RigaTurnoTreno, RigaTurnoTreno) && Equals(other.Convoglio, Convoglio);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result * 397) ^ (Oggetti != null ? Oggetti.GetHashCode() : 0);
                result = (result * 397) ^ (NumeroTrenoArrivo != null ? NumeroTrenoArrivo.GetHashCode() : 0);
                result = (result * 397) ^ DataTrenoArrivo.GetHashCode();
                result = (result * 397) ^ (NumeroTrenoPartenza != null ? NumeroTrenoPartenza.GetHashCode() : 0);
                result = (result * 397) ^ DataTrenoPartenza.GetHashCode();
                result = (result * 397) ^ (TurnoTreno != null ? TurnoTreno.GetHashCode() : 0);
                result = (result * 397) ^ (RigaTurnoTreno != null ? RigaTurnoTreno.GetHashCode() : 0);
                result = (result * 397) ^ (Convoglio != null ? Convoglio.GetHashCode() : 0);
                return result;
            }
        }
    }

    public class InterventoRotManPianificato : InterventoProgrammato
    {
        public OggettoRotMan[] Oggetti { get; set; }

        public override string ToDescription()
        {
            return string.Format("Il intervento rotabile in manutenzione '{0}' é stato programmato.", Id);
        }


        public override bool Equals(object obj)
        {
            return Equals(obj as InterventoRotManPianificato);
        }

        public bool Equals(InterventoRotManPianificato other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.Oggetti.SequenceEqual(Oggetti);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode() * 397) ^ (Oggetti != null ? Oggetti.GetHashCode() : 0);
            }
        }
    }

    public class InterventoAmbPianificato : InterventoProgrammato
    {

        public int Quantita { get; set; }
        public string Descrizione { get; set; }

        public override string ToDescription()
        {
            return string.Format("Il intervento ambiente '{0}' é stato programmato.", Id);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as InterventoAmbPianificato);
        }

        public bool Equals(InterventoAmbPianificato other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.Quantita == Quantita && Equals(other.Descrizione, Descrizione);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result * 397) ^ Quantita;
                result = (result * 397) ^ (Descrizione != null ? Descrizione.GetHashCode() : 0);
                return result;
            }
        }
    }
}