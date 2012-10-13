using System;
using System.Diagnostics.Contracts;
using System.Linq;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Programmazione.Events.Intervento
{
    public abstract class InterventoGeneratedFromSchedulazione : Message, IEvent
    {
        public Guid IdPeriodoProgrammazione { get; set; }
        public Guid IdProgramm { get; set; }
        public Guid IdSchedulazione { get; set; }
        public Guid IdInterventoGeneration { get; set; }
        public Guid IdCommittente { get; set; }
        public Guid IdLotto { get; set; }
        public Guid IdImpianto { get; set; }
        public Guid IdTipoIntervento { get; set; }
        public Guid IdAppaltatore { get; set; }
        public Guid IdCategoriaCommerciale { get; set; }
        public Guid IdDirezioneRegionale { get; set; }
        public WorkPeriod WorkPeriod { get; set; }
        public string Note { get; set; }

        public InterventoGeneratedFromSchedulazione()
        {
            
        }

        public InterventoGeneratedFromSchedulazione(Guid id,
            Guid commitId,
            long version,
            Guid idPeriodoProgrammazione,
            Guid idProgramm,
            Guid idSchedulazione,
            Guid idInterventoGeneration,
            Guid idCommittente,
            Guid idLotto,
            Guid idImpianto,
            Guid idTipoIntervento,
            Guid idAppaltatore,
            Guid idCategoriaCommerciale,
            Guid idDirezioneRegionale,
            WorkPeriod workPeriod,
            string note)
            : base(id,commitId,  version)
        {
            Contract.Requires(idPeriodoProgrammazione != Guid.Empty);
            Contract.Requires(idProgramm != Guid.Empty);
            Contract.Requires(idSchedulazione != Guid.Empty);
            Contract.Requires(idInterventoGeneration != Guid.Empty);
            Contract.Requires(idCommittente != Guid.Empty);
            Contract.Requires(idLotto != Guid.Empty);
            Contract.Requires(idImpianto != Guid.Empty);
            Contract.Requires(idTipoIntervento != Guid.Empty);
            Contract.Requires(idAppaltatore != Guid.Empty);
            Contract.Requires(idCategoriaCommerciale != Guid.Empty);
            Contract.Requires(idDirezioneRegionale != Guid.Empty);
            Contract.Requires(workPeriod != null);

            IdPeriodoProgrammazione = idPeriodoProgrammazione;
            IdProgramm = idProgramm;
            IdSchedulazione= idSchedulazione;
            IdCommittente = idCommittente;
            IdLotto = idLotto;
            IdImpianto = idImpianto;
            IdTipoIntervento = idTipoIntervento;
            IdAppaltatore = idAppaltatore;
            IdCategoriaCommerciale = idCategoriaCommerciale;
            IdDirezioneRegionale = idDirezioneRegionale;
            WorkPeriod = workPeriod;
            Note = note;
        }



        public bool Equals(InterventoGeneratedFromSchedulazione other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.IdPeriodoProgrammazione.Equals(IdPeriodoProgrammazione) && other.IdProgramm.Equals(IdProgramm) && other.IdSchedulazione.Equals(IdSchedulazione) && other.IdInterventoGeneration.Equals(IdInterventoGeneration) && other.IdCommittente.Equals(IdCommittente) && other.IdLotto.Equals(IdLotto) && other.IdImpianto.Equals(IdImpianto) && other.IdTipoIntervento.Equals(IdTipoIntervento) && other.IdAppaltatore.Equals(IdAppaltatore) && other.IdCategoriaCommerciale.Equals(IdCategoriaCommerciale) && other.IdDirezioneRegionale.Equals(IdDirezioneRegionale) && Equals(other.WorkPeriod, WorkPeriod) && Equals(other.Note, Note);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoGeneratedFromSchedulazione);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ IdPeriodoProgrammazione.GetHashCode();
                result = (result*397) ^ IdProgramm.GetHashCode();
                result = (result*397) ^ IdSchedulazione.GetHashCode();
                result = (result*397) ^ IdInterventoGeneration.GetHashCode();
                result = (result*397) ^ IdCommittente.GetHashCode();
                result = (result*397) ^ IdLotto.GetHashCode();
                result = (result*397) ^ IdImpianto.GetHashCode();
                result = (result*397) ^ IdTipoIntervento.GetHashCode();
                result = (result*397) ^ IdAppaltatore.GetHashCode();
                result = (result*397) ^ IdCategoriaCommerciale.GetHashCode();
                result = (result*397) ^ IdDirezioneRegionale.GetHashCode();
                result = (result*397) ^ (WorkPeriod != null ? WorkPeriod.GetHashCode() : 0);
                result = (result*397) ^ (Note != null ? Note.GetHashCode() : 0);
                return result;
            }
        }
    }

    public class InterventoRotGeneratedFromSchedulazione : InterventoGeneratedFromSchedulazione
    {
        public InterventoRotGeneratedFromSchedulazione()
        {

        }

        public InterventoRotGeneratedFromSchedulazione(Guid id, Guid commitId, long version, Guid idPeriodoProgrammazione,
                                   Guid idProgramm, Guid idSchedulazione, Guid idInterventoGeneration,
                                   Guid idCommittente,
                                   Guid idLotto, Guid idImpianto, Guid idTipoIntervento, Guid idAppaltatore, Guid idCategoriaCommerciale, Guid idDirezioneRegionale, WorkPeriod workPeriod, string note, OggettoRot[] oggetti, Treno trenoArrivo, Treno trenoPartenza, string turnoTreno, string rigaTurnoTreno, string convoglio)
            : base(id, commitId, version, idPeriodoProgrammazione, idProgramm, idSchedulazione,idInterventoGeneration, idCommittente, idLotto, idImpianto, idTipoIntervento, idAppaltatore, idCategoriaCommerciale, idDirezioneRegionale, workPeriod, note)
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
        public Treno TrenoArrivo { get; set; }
        public Treno TrenoPartenza { get; set; }
        public string TurnoTreno { get; set; }
        public string RigaTurnoTreno { get; set; }
        public string Convoglio { get; set; }

        public override string ToDescription()
        {
            return string.Format("Il Intervento rotabile {0} e stato generato per la schedulazione.", Id);
        }

        public bool Equals(InterventoRotGeneratedFromSchedulazione other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Oggetti, Oggetti) && Equals(other.TrenoArrivo, TrenoArrivo) && Equals(other.TrenoPartenza, TrenoPartenza) && Equals(other.TurnoTreno, TurnoTreno) && Equals(other.RigaTurnoTreno, RigaTurnoTreno) && Equals(other.Convoglio, Convoglio);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoRotGeneratedFromSchedulazione);
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

    public class InterventoRotManGeneratedFromSchedulazione : InterventoGeneratedFromSchedulazione
    {
        public InterventoRotManGeneratedFromSchedulazione()
        {

        }

        public InterventoRotManGeneratedFromSchedulazione(Guid id, Guid commitId, long version, Guid idPeriodoProgrammazione,
                                   Guid idProgramm, Guid idSchedulazione, Guid idInterventoGeneration,
                                   Guid idCommittente,
                                   Guid idLotto, Guid idImpianto, Guid idTipoIntervento, Guid idAppaltatore, Guid idCategoriaCommerciale, Guid idDirezioneRegionale, WorkPeriod workPeriod, string note, OggettoRotMan[] oggetti)
            : base(id, commitId, version, idPeriodoProgrammazione, idProgramm, idSchedulazione, idInterventoGeneration, idCommittente, idLotto, idImpianto, idTipoIntervento, idAppaltatore, idCategoriaCommerciale, idDirezioneRegionale, workPeriod, note)
        {
            Contract.Requires(oggetti != null);

            Oggetti = oggetti;
        }

        public OggettoRotMan[] Oggetti { get; set; }

        public override string ToDescription()
        {
            return string.Format("Il Intervento rotabile in manutenzione {0} e stato generato per la schedulazione.", Id);
        }


        public bool Equals(InterventoRotManGeneratedFromSchedulazione other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Oggetti, Oggetti);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoRotManGeneratedFromSchedulazione);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ (Oggetti != null ? Oggetti.GetHashCode() : 0);
            }
        }
    }

    public class InterventoAmbGeneratedFromSchedulazione : InterventoGeneratedFromSchedulazione
    {
        public InterventoAmbGeneratedFromSchedulazione()
        {

        }

        public InterventoAmbGeneratedFromSchedulazione(Guid id, Guid commitId, long version, Guid idPeriodoProgrammazione,
                                   Guid idProgramm, Guid idSchedulazione, Guid idInterventoGeneration,
                                   Guid idCommittente,
                                   Guid idLotto, Guid idImpianto, Guid idTipoIntervento, Guid idAppaltatore, Guid idCategoriaCommerciale, Guid idDirezioneRegionale, WorkPeriod workPeriod, string note, int quantity, string description)
            : base(id, commitId, version, idPeriodoProgrammazione, idProgramm, idSchedulazione, idInterventoGeneration, idCommittente, idLotto, idImpianto, idTipoIntervento, idAppaltatore, idCategoriaCommerciale, idDirezioneRegionale, workPeriod, note)
        {
            Quantity = quantity;
            Description = description;
        }

        public int Quantity { get; set; }
        public string Description { get; set; }

        public override string ToDescription()
        {
            return string.Format("Il Intervento ambiente {0} é stato programmato per la schedulazione.", Id);
        }

        public bool Equals(InterventoAmbGeneratedFromSchedulazione other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.Quantity == Quantity && Equals(other.Description, Description);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoAmbGeneratedFromSchedulazione);
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