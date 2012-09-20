using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Programmazione.Commands.Scenario
{
    public abstract class AddSchedulazioneToScenario : CommandBase
    {
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


        public AddSchedulazioneToScenario()
        {

        }

        public AddSchedulazioneToScenario(Guid id,
                                          Guid commitId,
                                          long version,
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

        public bool Equals(AddSchedulazioneToScenario other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.IdPeriodoProgrammazione.Equals(IdPeriodoProgrammazione) && other.IdSchedulazione.Equals(IdSchedulazione) && other.IdCommittente.Equals(IdCommittente) && other.IdLotto.Equals(IdLotto) && other.IdImpianto.Equals(IdImpianto) && other.IdTipoIntervento.Equals(IdTipoIntervento) && other.IdAppaltatore.Equals(IdAppaltatore) && other.IdCategoriaCommerciale.Equals(IdCategoriaCommerciale) && other.IdDirezioneRegionale.Equals(IdDirezioneRegionale) && Equals(other.Note, Note) && Equals(other.WorkPeriod, WorkPeriod) && Equals(other.Period, Period);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as AddSchedulazioneToScenario);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result * 397) ^ IdPeriodoProgrammazione.GetHashCode();
                result = (result * 397) ^ IdSchedulazione.GetHashCode();
                result = (result * 397) ^ IdCommittente.GetHashCode();
                result = (result * 397) ^ IdLotto.GetHashCode();
                result = (result * 397) ^ IdImpianto.GetHashCode();
                result = (result * 397) ^ IdTipoIntervento.GetHashCode();
                result = (result * 397) ^ IdAppaltatore.GetHashCode();
                result = (result * 397) ^ IdCategoriaCommerciale.GetHashCode();
                result = (result * 397) ^ IdDirezioneRegionale.GetHashCode();
                result = (result * 397) ^ (Note != null ? Note.GetHashCode() : 0);
                result = (result * 397) ^ (WorkPeriod != null ? WorkPeriod.GetHashCode() : 0);
                result = (result * 397) ^ (Period != null ? Period.GetHashCode() : 0);
                return result;
            }
        }
    }

    public class AddSchedulazioneRotToScenario : AddSchedulazioneToScenario
    {
        public string Convoglio { get; set; }
        public string RigaTurnoTreno { get; set; }
        public string TurnoTreno { get; set; }
        public Treno TrenoArrivo { get; set; }
        public Treno TrenoPartenza { get; set; }
        public OggettoRot[] Oggetti { get; set; }
       


        public AddSchedulazioneRotToScenario()
        {
            
        }

        public AddSchedulazioneRotToScenario(Guid id,
            Guid commitId,
            long version,
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
            : base(id, commitId, version, idPeriodoProgrammazione, idSchedulazione, idCommittente, idLotto, idImpianto,
            idTipoIntervento, idAppaltatore, idCategoriaCommerciale, idDirezioneRegionale, workPeriod, period,note)
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

        public bool Equals(AddSchedulazioneRotToScenario other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Convoglio, Convoglio) && Equals(other.RigaTurnoTreno, RigaTurnoTreno) && Equals(other.TurnoTreno, TurnoTreno) && Equals(other.TrenoArrivo, TrenoArrivo) && Equals(other.TrenoPartenza, TrenoPartenza) && Equals(other.Oggetti, Oggetti);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as AddSchedulazioneRotToScenario);
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

    public class AddSchedulazioneRotManToScenario : AddSchedulazioneToScenario
    {

        public OggettoRotMan[] Oggetti { get; set; }

        public AddSchedulazioneRotManToScenario()
        {

        }

        public AddSchedulazioneRotManToScenario(Guid id,
            Guid commitId,
            long version,
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
            : base(id, commitId, version, idPeriodoProgrammazione, idSchedulazione, idCommittente, idLotto, idImpianto,
            idTipoIntervento, idAppaltatore, idCategoriaCommerciale, idDirezioneRegionale, workPeriod,period, note)
        {
            Contract.Requires(oggetti != null);

            Oggetti = oggetti;

        }

        public override string ToDescription()
        {
            return string.Format("Aggiungere una schedulazione  rotabile in manutenzione {0}  al scenario ", Id);
        }

        public bool Equals(AddSchedulazioneRotManToScenario other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Oggetti, Oggetti);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as AddSchedulazioneRotManToScenario);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ (Oggetti != null ? Oggetti.GetHashCode() : 0);
            }
        }
    }

    public class AddSchedulazioneAmbToScenario : AddSchedulazioneToScenario
    {

        public string Description { get; set; }
        public int Quantity { get; set; }

        public AddSchedulazioneAmbToScenario()
        {

        }

        public AddSchedulazioneAmbToScenario(Guid id,
            Guid commitId,
            long version,
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
            : base(id, commitId, version, idPeriodoProgrammazione, idSchedulazione, idCommittente, idLotto, idImpianto,
                   idTipoIntervento, idAppaltatore, idCategoriaCommerciale, idDirezioneRegionale, workPeriod,period, note)
        {
            Contract.Requires<ArgumentOutOfRangeException>(quantity > 0);

            Quantity = quantity;
            Description = description;
        }

        public override string ToDescription()
        {
            return string.Format("Aggiungere una schedulazione  ambiente {0}  al scenario ", Id);
        }

        public bool Equals(AddSchedulazioneAmbToScenario other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Description, Description) && other.Quantity == Quantity;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as AddSchedulazioneAmbToScenario);
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
