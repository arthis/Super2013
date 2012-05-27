using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core;
using CommonDomain.Core.Super;

namespace Super.Appaltatore.Commands
{

    public abstract class ProgrammareIntervento : CommandBase
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
            return Equals(obj as ProgrammareIntervento);
        }


        public bool Equals(ProgrammareIntervento other)
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
                result = (result*397) ^ Id.GetHashCode();
                result = (result*397) ^ IdAreaIntervento.GetHashCode();
                result = (result*397) ^ IdTipoIntervento.GetHashCode();
                result = (result*397) ^ IdAppaltatore.GetHashCode();
                result = (result*397) ^ IdCategoriaCommerciale.GetHashCode();
                result = (result*397) ^ IdDirezioneRegionale.GetHashCode();
                result = (result*397) ^ Start.GetHashCode();
                result = (result*397) ^ End.GetHashCode();
                result = (result*397) ^ (Note != null ? Note.GetHashCode() : 0);
                return result;
            }
        }
    }

    public class ProgrammareInterventoRot : ProgrammareIntervento
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
            return string.Format("si programma il intervento rotabile {0}.", Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ProgrammareInterventoRot);
        }

        public bool Equals(ProgrammareInterventoRot other)
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

    public class ProgrammareInterventoRotMan : ProgrammareIntervento, IEquatable<ProgrammareInterventoRotMan>
    {
        public OggettoRotMan[] Oggetti { get; set; }

        public override string ToDescription()
        {
            return string.Format("si programma il intervento rotabile in manutenzione {0}.", Id);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ProgrammareInterventoRotMan);
        }

        public bool Equals(ProgrammareInterventoRotMan other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.Oggetti.SequenceEqual(Oggetti);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ (Oggetti != null ? Oggetti.GetHashCode() : 0);
            }
        }
    }

    public class ProgrammareInterventoAmb : ProgrammareIntervento, IEquatable<ProgrammareInterventoAmb>
    {
        public int Quantita { get; set; }
        public string Descrizione { get; set; }

        public override string ToDescription()
        {
            return string.Format("si programma il intervento ambiente {0}.", Id);
        }


        public override bool Equals(object obj)
        {
            return Equals(obj as ProgrammareInterventoAmb);
        }

        public bool Equals(ProgrammareInterventoAmb other)
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
                result = (result*397) ^ Quantita;
                result = (result*397) ^ (Descrizione != null ? Descrizione.GetHashCode() : 0);
                return result;
            }
        }
    }
}
