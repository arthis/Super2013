﻿using System;
using System.Diagnostics.Contracts;
using System.Linq;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Programmazione.Events.Scenario
{

    public abstract class SchedulazioneAddedToScenario : EventBase
    {
        public Guid IdProgramma { get; set; }
        public Guid IdPeriodoProgrammazione { get; set; }
        public Guid IdSchedulazione { get; set; }
        public Guid IdCommittente { get; set; }
        public Guid IdLotto { get; set; }
        public Guid IdImpianto { get; set; }
        public Guid IdTipoIntervento { get; set; }
        public Guid IdAppaltatore { get; set; }
        public Guid IdCategoriaCommerciale { get; set; }
        public Guid IdDirezioneRegionale { get; set; }
        public string Note { get; set; }
        public WorkPeriod WorkPeriod { get; set; }
        public Period Period { get; set; }


        public SchedulazioneAddedToScenario()
        {

        }

        public SchedulazioneAddedToScenario(Guid id,
            Guid commitId,
            long version,
            Guid idProgramma,
            Guid idPeriodoProgrammazione,
            Guid idSchedulazione,
            Guid idCommittente,
            Guid idLotto,
            Guid idImpianto,
            Guid idTipoIntervento,
            Guid idAppaltatore,
            Guid idCategoriaCommerciale,
            Guid idDirezioneRegionale,
            WorkPeriod workPeriod,
            Period period,
            string note)
            : base(id, commitId, version)
        {
            Contract.Requires(idProgramma != Guid.Empty);
            Contract.Requires(idPeriodoProgrammazione != Guid.Empty);
            Contract.Requires(idSchedulazione != Guid.Empty);
            Contract.Requires(idCommittente != Guid.Empty);
            Contract.Requires(idLotto != Guid.Empty);
            Contract.Requires(idImpianto != Guid.Empty);
            Contract.Requires(idTipoIntervento != Guid.Empty);
            Contract.Requires(idAppaltatore != Guid.Empty);
            Contract.Requires(idCategoriaCommerciale != Guid.Empty);
            Contract.Requires(idDirezioneRegionale != Guid.Empty);
            Contract.Requires(workPeriod != null);
            Contract.Requires(period != null);


            IdProgramma = idProgramma;
            IdPeriodoProgrammazione = idPeriodoProgrammazione;
            IdSchedulazione = idSchedulazione;
            IdCommittente = idCommittente;
            IdLotto = idLotto;
            IdImpianto = idImpianto;
            IdTipoIntervento = idTipoIntervento;
            IdAppaltatore = idAppaltatore;
            IdCategoriaCommerciale = idCategoriaCommerciale;
            IdDirezioneRegionale = idDirezioneRegionale;
            WorkPeriod = workPeriod;
            Period = period;
            Note = note;

        }

        protected bool Equals(SchedulazioneAddedToScenario other)
        {
            return base.Equals(other) && IdProgramma.Equals(other.IdProgramma) && IdPeriodoProgrammazione.Equals(other.IdPeriodoProgrammazione) && IdSchedulazione.Equals(other.IdSchedulazione) && IdCommittente.Equals(other.IdCommittente) && IdLotto.Equals(other.IdLotto) && IdImpianto.Equals(other.IdImpianto) && IdTipoIntervento.Equals(other.IdTipoIntervento) && IdAppaltatore.Equals(other.IdAppaltatore) && IdCategoriaCommerciale.Equals(other.IdCategoriaCommerciale) && IdDirezioneRegionale.Equals(other.IdDirezioneRegionale) && string.Equals(Note, other.Note) && Equals(WorkPeriod, other.WorkPeriod) && Equals(Period, other.Period);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SchedulazioneAddedToScenario) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode*397) ^ IdProgramma.GetHashCode();
                hashCode = (hashCode*397) ^ IdPeriodoProgrammazione.GetHashCode();
                hashCode = (hashCode*397) ^ IdSchedulazione.GetHashCode();
                hashCode = (hashCode*397) ^ IdCommittente.GetHashCode();
                hashCode = (hashCode*397) ^ IdLotto.GetHashCode();
                hashCode = (hashCode*397) ^ IdImpianto.GetHashCode();
                hashCode = (hashCode*397) ^ IdTipoIntervento.GetHashCode();
                hashCode = (hashCode*397) ^ IdAppaltatore.GetHashCode();
                hashCode = (hashCode*397) ^ IdCategoriaCommerciale.GetHashCode();
                hashCode = (hashCode*397) ^ IdDirezioneRegionale.GetHashCode();
                hashCode = (hashCode*397) ^ (Note != null ? Note.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (WorkPeriod != null ? WorkPeriod.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Period != null ? Period.GetHashCode() : 0);
                return hashCode;
            }
        }
    }

    public class SchedulazioneRotAddedToScenario : SchedulazioneAddedToScenario
    {
        public string Convoglio { get; set; }
        public string RigaTurnoTreno { get; set; }
        public string TurnoTreno { get; set; }
        public Treno TrenoArrivo { get; set; }
        public Treno TrenoPartenza { get; set; }
        public OggettoRot[] Oggetti { get; set; }
       


        public SchedulazioneRotAddedToScenario()
        {
            
        }

        public SchedulazioneRotAddedToScenario(Guid id,
            Guid commitId,
            long version,
            Guid idProgramma,
            Guid idPeriodoProgrammazione,
            Guid idSchedulazione,
            Guid idCommittente,
            Guid idLotto,
            Guid idImpianto,
            Guid idTipoIntervento,
            Guid idAppaltatore,
            Guid idCategoriaCommerciale,
            Guid idDirezioneRegionale,
            WorkPeriod workPeriod,
            Period period,
            string note,
            OggettoRot[] oggetti,
            Treno trenoPartenza,
            Treno trenoArrivo,
            string turnoTreno,
            string rigaTurnoTreno,
            string convoglio)
            : base(id, commitId, version, idProgramma, idPeriodoProgrammazione, idSchedulazione, idCommittente, idLotto, idImpianto,
            idTipoIntervento, idAppaltatore, idCategoriaCommerciale, idDirezioneRegionale, workPeriod, period, note)
        {
            Contract.Requires(oggetti != null);

            Oggetti = oggetti;
            TrenoPartenza = trenoPartenza;
            TrenoArrivo = trenoArrivo;
            TurnoTreno = turnoTreno;
            RigaTurnoTreno = rigaTurnoTreno;
            Convoglio = convoglio;
            
        }

        public override string ToDescription()
        {
            return string.Format("Aggiungere una schedulazione  rotabile {0}  al scenario ", Id);
        }

        public bool Equals(SchedulazioneRotAddedToScenario other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Convoglio, Convoglio) && Equals(other.RigaTurnoTreno, RigaTurnoTreno) && Equals(other.TurnoTreno, TurnoTreno) && Equals(other.TrenoArrivo, TrenoArrivo) && Equals(other.TrenoPartenza, TrenoPartenza) && other.Oggetti.SequenceEqual(Oggetti);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as SchedulazioneRotAddedToScenario);
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

    public class SchedulazioneRotManAddedToScenario : SchedulazioneAddedToScenario
    {

        public OggettoRotMan[] Oggetti { get; set; }

        public SchedulazioneRotManAddedToScenario()
        {

        }

        public SchedulazioneRotManAddedToScenario(Guid id,
            Guid commitId,
            long version,
            Guid idProgramma,
            Guid idPeriodoProgrammazione,
            Guid idSchedulazione,
            Guid idCommittente,
            Guid idLotto,
            Guid idImpianto,
            Guid idTipoIntervento,
            Guid idAppaltatore,
            Guid idCategoriaCommerciale,
            Guid idDirezioneRegionale,
            WorkPeriod workPeriod,
            Period period,
            string note,
            OggettoRotMan[] oggetti)
            : base(id, commitId, version, idProgramma, idPeriodoProgrammazione, idSchedulazione, idCommittente, idLotto, idImpianto,
            idTipoIntervento, idAppaltatore, idCategoriaCommerciale, idDirezioneRegionale, workPeriod, period, note)
        {
            Contract.Requires(oggetti != null);

            Oggetti = oggetti;

        }

        public override string ToDescription()
        {
            return string.Format("Aggiungere una schedulazione  rotabile in manutenzione {0}  al scenario ", Id);
        }

        protected bool Equals(SchedulazioneRotManAddedToScenario other)
        {
            return base.Equals(other) && other.Oggetti.SequenceEqual(Oggetti);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SchedulazioneRotManAddedToScenario) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ (Oggetti != null ? Oggetti.GetHashCode() : 0);
            }
        }
    }

    public class SchedulazioneAmbAddedToScenario : SchedulazioneAddedToScenario
    {

        public string Description { get; set; }
        public int Quantity { get; set; }

        public SchedulazioneAmbAddedToScenario()
        {

        }

        public SchedulazioneAmbAddedToScenario(Guid id,
            Guid commitId,
            long version,
            Guid idProgramma,
            Guid idPeriodoProgrammazione,
            Guid idSchedulazione,
            Guid idCommittente,
            Guid idLotto,
            Guid idImpianto,
            Guid idTipoIntervento,
            Guid idAppaltatore,
            Guid idCategoriaCommerciale,
            Guid idDirezioneRegionale,
            WorkPeriod workPeriod,
            Period period,
            string note,
            int quantity,
            string description)
            : base(id, commitId, version, idProgramma,  idPeriodoProgrammazione, idSchedulazione, idCommittente, idLotto, idImpianto,
                   idTipoIntervento, idAppaltatore, idCategoriaCommerciale, idDirezioneRegionale, workPeriod, period, note)
        {
            Contract.Requires(quantity > 0);

            Quantity = quantity;
            Description = description;
        }

        public override string ToDescription()
        {
            return string.Format("Aggiungere una schedulazione  ambiente {0}  al scenario ", Id);
        }

        public bool Equals(SchedulazioneAmbAddedToScenario other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Description, Description) && other.Quantity == Quantity;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as SchedulazioneAmbAddedToScenario);
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
