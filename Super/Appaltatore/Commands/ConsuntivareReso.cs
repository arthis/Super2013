using System;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Appaltatore.Commands
{
    
    public abstract class ConsuntivareReso : CommandBase
    {
        public string IdInterventoAppaltatore { get; set; }
        public DateTime DataConsuntivazione { get; set; }
        public WorkPeriod workPeriod { get; set; }
        public string Note { get; set; }

        public bool Equals(ConsuntivareReso other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.IdInterventoAppaltatore, IdInterventoAppaltatore) && other.DataConsuntivazione.Equals(DataConsuntivazione) && Equals(other.workPeriod, workPeriod) && Equals(other.Note, Note);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ConsuntivareReso);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ (IdInterventoAppaltatore != null ? IdInterventoAppaltatore.GetHashCode() : 0);
                result = (result*397) ^ DataConsuntivazione.GetHashCode();
                result = (result*397) ^ (workPeriod != null ? workPeriod.GetHashCode() : 0);
                result = (result*397) ^ (Note != null ? Note.GetHashCode() : 0);
                return result;
            }
        }
    }

    
    public class ConsuntivareRotReso : ConsuntivareReso
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
            return string.Format("Consuntivare reso il intervento rotabile '{0}' ", Id);
        }

        public bool Equals(ConsuntivareRotReso other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Oggetti, Oggetti) && Equals(other.NumeroTrenoArrivo, NumeroTrenoArrivo) && other.DataTrenoArrivo.Equals(DataTrenoArrivo) && Equals(other.NumeroTrenoPartenza, NumeroTrenoPartenza) && other.DataTrenoPartenza.Equals(DataTrenoPartenza) && Equals(other.TurnoTreno, TurnoTreno) && Equals(other.RigaTurnoTreno, RigaTurnoTreno) && Equals(other.Convoglio, Convoglio);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ConsuntivareRotReso);
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

    public class ConsuntivareRotManReso : ConsuntivareReso
    {
        public OggettoRotMan[] Oggetti { get; set; }

       

        public override string ToDescription()
        {
            return string.Format("Consuntivare reso il intervento rotabile in manutenzione '{0}' ", Id);
        }

        public bool Equals(ConsuntivareRotManReso other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Oggetti, Oggetti);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ConsuntivareRotManReso);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ (Oggetti != null ? Oggetti.GetHashCode() : 0);
            }
        }
    }

    public class ConsuntivareAmbReso : ConsuntivareReso
    {
        public int Quantita { get; set; }
        public string Descrizione { get; set; }

        public override string ToDescription()
        {
            return string.Format("Consuntivare reso il intervento ambiente '{0}' ", Id);
        }

        public bool Equals(ConsuntivareAmbReso other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.Quantita == Quantita && Equals(other.Descrizione, Descrizione);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ConsuntivareAmbReso);
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
