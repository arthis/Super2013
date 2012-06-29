using System;
using System.Diagnostics.Contracts;
using System.Linq;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Appaltatore.Events.Programmazione
{
    public abstract class InterventoProgrammato : Message
    {
        public string Note { get;  set; }
        public WorkPeriod Period { get;  set; }
        public Guid IdDirezioneRegionale { get;  set; }
        public Guid IdCategoriaCommerciale { get;  set; }
        public Guid IdAppaltatore { get;  set; }
        public Guid IdTipoIntervento { get;  set; }
        public Guid IdImpianto { get;  set; }


        //for serialization
        public InterventoProgrammato()
        {
            
        }

        public InterventoProgrammato(Guid id,
                                     Guid commitId,
                                     Guid idImpianto,
                                     Guid idTipoIntervento,
                                     Guid idAppaltatore,
                                     Guid idCategoriaCommerciale,
                                     Guid idDirezioneRegionale,
                                     WorkPeriod period,
                                     string note)
        {
            Contract.Requires<ArgumentNullException>(id == Guid.Empty);
            Contract.Requires<ArgumentNullException>(commitId == Guid.Empty);
            Contract.Requires<ArgumentNullException>(idImpianto == Guid.Empty);
            Contract.Requires<ArgumentNullException>(idTipoIntervento == Guid.Empty);
            Contract.Requires<ArgumentNullException>(idAppaltatore == Guid.Empty);
            Contract.Requires<ArgumentNullException>(idCategoriaCommerciale == Guid.Empty);
            Contract.Requires<ArgumentNullException>(idDirezioneRegionale == Guid.Empty);
            Contract.Requires<ArgumentNullException>(Period == null);

            Id = id;
            CommitId = commitId;
            IdImpianto = idImpianto;
            IdTipoIntervento = idTipoIntervento;
            IdAppaltatore = idAppaltatore;
            IdCategoriaCommerciale = idCategoriaCommerciale;
            IdDirezioneRegionale = idDirezioneRegionale;
            Period = period;
            Note = note;
        }

        public bool Equals(InterventoProgrammato other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Note, Note) && Equals(other.Period, Period) && other.IdDirezioneRegionale.Equals(IdDirezioneRegionale) && other.IdCategoriaCommerciale.Equals(IdCategoriaCommerciale) && other.IdAppaltatore.Equals(IdAppaltatore) && other.IdTipoIntervento.Equals(IdTipoIntervento) && other.IdImpianto.Equals(IdImpianto);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoProgrammato);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ (Note != null ? Note.GetHashCode() : 0);
                result = (result*397) ^ (Period != null ? Period.GetHashCode() : 0);
                result = (result*397) ^ IdDirezioneRegionale.GetHashCode();
                result = (result*397) ^ IdCategoriaCommerciale.GetHashCode();
                result = (result*397) ^ IdAppaltatore.GetHashCode();
                result = (result*397) ^ IdTipoIntervento.GetHashCode();
                result = (result*397) ^ IdImpianto.GetHashCode();
                return result;
            }
        }
    }

    public class InterventoRotProgrammato : InterventoProgrammato
    {

        public string Convoglio { get;  set; }
        public string RigaTurnoTreno { get; set; }
        public string TurnoTreno { get; set; }
        public Treno TrenoArrivo { get; set; }
        public Treno TrenoPartenza { get; set; }
        public OggettoRot[] Oggetti { get; set; }

        //for serialization
        public InterventoRotProgrammato()
        {
            
        }
        
        public InterventoRotProgrammato(Guid id,
                                     Guid commitId,
                                     Guid idImpianto,
                                     Guid idTipoIntervento,
                                     Guid idAppaltatore,
                                     Guid idCategoriaCommerciale,
                                     Guid idDirezioneRegionale,
                                     WorkPeriod period,
                                     string note,
                                    OggettoRot[] oggetti,
                                    Treno trenoPartenza,
                                    Treno trenoArrivo,
                                    string turnoTreno,
                                    string rigaTurnoTreno,
                                    string convoglio
            )
            : base(id,commitId, idImpianto, idTipoIntervento, idAppaltatore, idCategoriaCommerciale, idDirezioneRegionale, period, note)
        {
            Oggetti = oggetti;
            TrenoPartenza = trenoPartenza;
            TrenoArrivo = trenoArrivo;
            TurnoTreno = turnoTreno;
            RigaTurnoTreno = rigaTurnoTreno;
            Convoglio = convoglio;
        }

        public override string ToDescription()
        {
            return string.Format("Il intervento rotabile '{0}' é stato programmato.", Id);
        }

        public bool Equals(InterventoRotProgrammato other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Convoglio, Convoglio) && Equals(other.RigaTurnoTreno, RigaTurnoTreno) && Equals(other.TurnoTreno, TurnoTreno) && Equals(other.TrenoArrivo, TrenoArrivo) && Equals(other.TrenoPartenza, TrenoPartenza) && Equals(other.Oggetti, Oggetti);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoRotProgrammato);
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

    public class InterventoRotManProgrammato : InterventoProgrammato
    {

        public OggettoRotMan[] Oggetti { get; set; }

        //for serialization
        public InterventoRotManProgrammato()
        {
            
        }

        public InterventoRotManProgrammato(Guid id,
                                     Guid commitId,
                                     Guid idImpianto,
                                     Guid idTipoIntervento,
                                     Guid idAppaltatore,
                                     Guid idCategoriaCommerciale,
                                     Guid idDirezioneRegionale,
                                     WorkPeriod period,
                                     string note,
                                     OggettoRotMan[] oggetti)
            : base(id,commitId, idImpianto, idTipoIntervento, idAppaltatore, idCategoriaCommerciale, idDirezioneRegionale, period, note)
        {
            Oggetti = oggetti;
        }

        public override string ToDescription()
        {
            return string.Format("Il intervento rotabile in manutenzione '{0}' é stato programmato.", Id);
        }

        public bool Equals(InterventoRotManProgrammato other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Oggetti, Oggetti);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoRotManProgrammato);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ (Oggetti != null ? Oggetti.GetHashCode() : 0);
            }
        }
    }

    public class InterventoAmbProgrammato : InterventoProgrammato
    {
        

        //for serialization
        public InterventoAmbProgrammato()
        {
            
        }

        public InterventoAmbProgrammato(Guid id,
                                     Guid commitId,
                                     Guid idImpianto,
                                     Guid idTipoIntervento,
                                     Guid idAppaltatore,
                                     Guid idCategoriaCommerciale,
                                     Guid idDirezioneRegionale,
                                     WorkPeriod period,
                                     string note,
                                     int quantita,
                                     string description)
            : base(id, commitId, idImpianto, idTipoIntervento, idAppaltatore, idCategoriaCommerciale, idDirezioneRegionale, period, note)
        {
            Quantita = quantita;
            Description = description;
        }

        public string Description { get; set; }
        public int Quantita { get; set; }

        public override string ToDescription()
        {
            return string.Format("Il intervento ambiente '{0}' é stato programmato.", Id);
        }

        public bool Equals(InterventoAmbProgrammato other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Description, Description) && other.Quantita == Quantita;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoAmbProgrammato);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
                result = (result*397) ^ Quantita;
                return result;
            }
        }
    }
}