using System;
using System.Linq;
using CommandService;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;

namespace Super.Controllo.Commands
{

    public abstract class ControlInterventoReso : CommandBase
    {
        public Guid IdUtente { get; set; }
        public Guid ControlDate { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Note { get; set; }

        public bool Equals(ControlInterventoReso other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.IdUtente.Equals(IdUtente) && other.ControlDate.Equals(ControlDate) && other.Start.Equals(Start) && other.End.Equals(End) && Equals(other.Note, Note);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ControlInterventoReso);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ IdUtente.GetHashCode();
                result = (result*397) ^ ControlDate.GetHashCode();
                result = (result*397) ^ Start.GetHashCode();
                result = (result*397) ^ End.GetHashCode();
                result = (result*397) ^ (Note != null ? Note.GetHashCode() : 0);
                return result;
            }
        }
    }

    public class ControlInterventoRotReso : ControlInterventoReso
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
            return string.Format("si controlla reso il intervento rotabile {0}.", Id);
        }

        public bool Equals(ControlInterventoRotReso other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Oggetti, Oggetti) && Equals(other.NumeroTrenoArrivo, NumeroTrenoArrivo) && other.DataTrenoArrivo.Equals(DataTrenoArrivo) && Equals(other.NumeroTrenoPartenza, NumeroTrenoPartenza) && other.DataTrenoPartenza.Equals(DataTrenoPartenza) && Equals(other.TurnoTreno, TurnoTreno) && Equals(other.RigaTurnoTreno, RigaTurnoTreno) && Equals(other.Convoglio, Convoglio);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ControlInterventoRotReso);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ (Oggetti != null ? Oggetti.GetHashCode() : 0);
                result = (result*397) ^ (NumeroTrenoArrivo != null ? NumeroTrenoArrivo.GetHashCode() : 0);
                result = (result*397) ^ DataTrenoArrivo.GetHashCode();
                result = (result*397) ^ (NumeroTrenoPartenza != null ? NumeroTrenoPartenza.GetHashCode() : 0);
                result = (result*397) ^ DataTrenoPartenza.GetHashCode();
                result = (result*397) ^ (TurnoTreno != null ? TurnoTreno.GetHashCode() : 0);
                result = (result*397) ^ (RigaTurnoTreno != null ? RigaTurnoTreno.GetHashCode() : 0);
                result = (result*397) ^ (Convoglio != null ? Convoglio.GetHashCode() : 0);
                return result;
            }
        }
    }

    public class ControlInterventoRotManReso : ControlInterventoReso
    {
        public OggettoRotMan[] Oggetti { get; set; }

        public override string ToDescription()
        {
            return string.Format("si controlla reso il intervento rotabile in manutenzione {0}.", Id);
        }

        public bool Equals(ControlInterventoRotManReso other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Oggetti, Oggetti);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ControlInterventoRotManReso);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ (Oggetti != null ? Oggetti.GetHashCode() : 0);
            }
        }
    }

    public class ControlInterventoAmbReso : ControlInterventoReso
    {
        public int Quantita { get; set; }
        public string Descrizione { get; set; }

        public override string ToDescription()
        {
            return string.Format("si controlla reso il intervento ambiente '{0}' ", Id);
        }

        public bool Equals(ControlInterventoAmbReso other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.Quantita == Quantita && Equals(other.Descrizione, Descrizione);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ControlInterventoAmbReso);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ Quantita;
                result = (result*397) ^ (Descrizione != null ? Descrizione.GetHashCode() : 0);
                return result;
            }
        }
    }


}
