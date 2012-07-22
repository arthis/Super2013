using System;
using System.Diagnostics.Contracts;
using System.Linq;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Programmazione.Events
{
    public class InterventoRotGenerated : InterventoGenerated
    {
        public InterventoRotGenerated()
        {
            
        }

        public InterventoRotGenerated(Guid id, Guid commitId, long version, Guid idImpianto, Guid idTipoIntervento, Guid idAppaltatore, Guid idCategoriaCommerciale, Guid idDirezioneRegionale, WorkPeriod period, string note, OggettoRot[] oggetti, Treno trenoArrivo, Treno trenoPartenza, string turnoTreno, string rigaTurnoTreno, string convoglio)
            : base(id, commitId, version, idImpianto, idTipoIntervento, idAppaltatore, idCategoriaCommerciale, idDirezioneRegionale, period, note)
        {
            Contract.Requires(oggetti != null);

            Oggetti = oggetti;
            TrenoArrivo = trenoArrivo;
            TrenoPartenza = trenoPartenza;
            TurnoTreno = turnoTreno;
            RigaTurnoTreno = rigaTurnoTreno;
            Convoglio = convoglio;
        }

        public OggettoRot[] Oggetti { get; set; }
        public Treno  TrenoArrivo { get; set; }
        public Treno TrenoPartenza { get; set; }
        public string TurnoTreno { get; set; }
        public string RigaTurnoTreno { get; set; }
        public string Convoglio { get; set; }

        public override string ToDescription()
        {
            return string.Format("Il Intervento rotabile {0} e stato schedulato.", Id);
        }

        public bool Equals(InterventoRotGenerated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) &&  other.Oggetti.SequenceEqual(Oggetti) && Equals(other.TrenoArrivo, TrenoArrivo) && Equals(other.TrenoPartenza, TrenoPartenza) && Equals(other.TurnoTreno, TurnoTreno) && Equals(other.RigaTurnoTreno, RigaTurnoTreno) && Equals(other.Convoglio, Convoglio);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoRotGenerated);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ (Oggetti != null ? Oggetti.GetHashCode() : 0);
                result = (result*397) ^ (TrenoArrivo != null ? TrenoArrivo.GetHashCode() : 0);
                result = (result*397) ^ (TrenoPartenza != null ? TrenoPartenza.GetHashCode() : 0);
                result = (result*397) ^ (TurnoTreno != null ? TurnoTreno.GetHashCode() : 0);
                result = (result*397) ^ (RigaTurnoTreno != null ? RigaTurnoTreno.GetHashCode() : 0);
                result = (result*397) ^ (Convoglio != null ? Convoglio.GetHashCode() : 0);
                return result;
            }
        }
    }

    public class InterventoRotManGenerated : InterventoGenerated
    {
        public InterventoRotManGenerated()
        {
            
        }

        public InterventoRotManGenerated(Guid id, Guid commitId, long version, Guid idImpianto, Guid idTipoIntervento, Guid idAppaltatore, Guid idCategoriaCommerciale, Guid idDirezioneRegionale, WorkPeriod period, string note, OggettoRotMan[] oggetti)
            : base(id, commitId, version, idImpianto, idTipoIntervento, idAppaltatore, idCategoriaCommerciale, idDirezioneRegionale, period, note)
        {
            Contract.Requires(oggetti!=null);

            Oggetti = oggetti;
        }

        public OggettoRotMan[] Oggetti { get; set; }

        public override string ToDescription()
        {
            return string.Format("Il Intervento rotabile in manutenzione {0} e stato schedulato.", Id);
        }


        public bool Equals(InterventoRotManGenerated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) &&  other.Oggetti.SequenceEqual(Oggetti);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoRotManGenerated);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ (Oggetti != null ? Oggetti.GetHashCode() : 0);
            }
        }
    }

    public class InterventoAmbGenerated : InterventoGenerated
    {
        public InterventoAmbGenerated()
        {
            
        }

        public InterventoAmbGenerated(Guid id, Guid commitId, long version, Guid idImpianto, Guid idTipoIntervento, Guid idAppaltatore, Guid idCategoriaCommerciale, Guid idDirezioneRegionale, WorkPeriod period, string note, int quantity, string description)
            : base(id, commitId, version, idImpianto, idTipoIntervento, idAppaltatore, idCategoriaCommerciale, idDirezioneRegionale, period, note)
        {
            Quantity = quantity;
            Description = description;
        }

        public int Quantity { get; set; }
        public string Description { get; set; }

        public override string ToDescription()
        {
            return string.Format("Il Intervento ambiente {0} E stato schedulato.", Id);
        }

        public bool Equals(InterventoAmbGenerated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.Quantity == Quantity && Equals(other.Description, Description);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoAmbGenerated);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ Quantity;
                result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
                return result;
            }
        }
    }
}