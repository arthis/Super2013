using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Programmazione.Commands.Intervento
{
    public abstract class AddInterventoToPlan : CommandBase
    {
        public Guid IdPeriodoProgrammazione { get; set; }
        public Guid IdPlan { get; set; }
        public Guid IdCommittente { get; set; }
        public Guid IdLotto { get; set; }
        public Guid IdImpianto { get; set; }
        public Guid IdTipoIntervento { get; set; }
        public Guid IdAppaltatore { get; set; }
        public Guid IdCategoriaCommerciale { get; set; }
        public Guid IdDirezioneRegionale { get; set; }
        public string Note { get; set; }
        public WorkPeriod WorkPeriod { get; set; }



        public AddInterventoToPlan()
        {

        }

        public AddInterventoToPlan(Guid id,
                                   Guid commitId,
                                   long version,
                                   Guid idPeriodoProgrammazione,
                                   Guid idPlan,
                                   Guid idCommittente,
                                   Guid idLotto,
                                   Guid idImpianto,
                                   Guid idTipoIntervento,
                                   Guid idAppaltatore,
                                   Guid idCategoriaCommerciale,
                                   Guid idDirezioneRegionale,
                                   WorkPeriod workPeriod,
                                   string note)
            : base(id, commitId, version)
        {
            Contract.Requires(idPeriodoProgrammazione != Guid.Empty);
            Contract.Requires(idPlan != Guid.Empty);
            Contract.Requires(idCommittente != Guid.Empty);
            Contract.Requires(idLotto != Guid.Empty);
            Contract.Requires(idImpianto != Guid.Empty);
            Contract.Requires(idTipoIntervento != Guid.Empty);
            Contract.Requires(idAppaltatore != Guid.Empty);
            Contract.Requires(idCategoriaCommerciale != Guid.Empty);
            Contract.Requires(idDirezioneRegionale != Guid.Empty);
            Contract.Requires(workPeriod != null);


            IdPeriodoProgrammazione = idPeriodoProgrammazione;
            IdPlan = idPlan;
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

        public bool Equals(AddInterventoToPlan other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.IdPeriodoProgrammazione.Equals(IdPeriodoProgrammazione) && other.IdPlan.Equals(IdPlan) && other.IdCommittente.Equals(IdCommittente) && other.IdLotto.Equals(IdLotto) && other.IdImpianto.Equals(IdImpianto) && other.IdTipoIntervento.Equals(IdTipoIntervento) && other.IdAppaltatore.Equals(IdAppaltatore) && other.IdCategoriaCommerciale.Equals(IdCategoriaCommerciale) && other.IdDirezioneRegionale.Equals(IdDirezioneRegionale) && Equals(other.Note, Note) && Equals(other.WorkPeriod, WorkPeriod);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as AddInterventoToPlan);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result * 397) ^ IdPeriodoProgrammazione.GetHashCode();
                result = (result * 397) ^ IdPlan.GetHashCode();
                result = (result * 397) ^ IdCommittente.GetHashCode();
                result = (result * 397) ^ IdLotto.GetHashCode();
                result = (result * 397) ^ IdImpianto.GetHashCode();
                result = (result * 397) ^ IdTipoIntervento.GetHashCode();
                result = (result * 397) ^ IdAppaltatore.GetHashCode();
                result = (result * 397) ^ IdCategoriaCommerciale.GetHashCode();
                result = (result * 397) ^ IdDirezioneRegionale.GetHashCode();
                result = (result * 397) ^ (Note != null ? Note.GetHashCode() : 0);
                result = (result * 397) ^ (WorkPeriod != null ? WorkPeriod.GetHashCode() : 0);
                return result;
            }
        }
    }

    public class AddInterventoRotToPlan : AddInterventoToPlan
    {
        public string Convoglio { get; set; }
        public string RigaTurnoTreno { get; set; }
        public string TurnoTreno { get; set; }
        public Treno TrenoArrivo { get; set; }
        public Treno TrenoPartenza { get; set; }
        public OggettoRot[] Oggetti { get; set; }

        public AddInterventoRotToPlan()
        {

        }

        public AddInterventoRotToPlan(Guid id,
                                   Guid commitId,
                                   long version,
                                   Guid idPeriodoProgrammazione,
                                   Guid idPlan,
                                   Guid idCommittente,
                                   Guid idLotto,
                                   Guid idImpianto,
                                   Guid idTipoIntervento,
                                   Guid idAppaltatore,
                                   Guid idCategoriaCommerciale,
                                   Guid idDirezioneRegionale,
                                   WorkPeriod workPeriod,
                                   string note,
                                   OggettoRot[] oggetti,
                                   Treno trenoPartenza,
                                   Treno trenoArrivo,
                                   string turnoTreno,
                                   string rigaTurnoTreno,
                                   string convoglio)
            : base(id, commitId, version, idPeriodoProgrammazione, idPlan, idCommittente, idLotto, idImpianto,
            idTipoIntervento, idAppaltatore, idCategoriaCommerciale, idDirezioneRegionale, workPeriod, note)
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
            return string.Format("Aggiungere una schedulazione  rotabile {0}  al piano ", Id);
        }

        public bool Equals(AddInterventoRotToPlan other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Convoglio, Convoglio) && Equals(other.RigaTurnoTreno, RigaTurnoTreno) && Equals(other.TurnoTreno, TurnoTreno) && Equals(other.TrenoArrivo, TrenoArrivo) && Equals(other.TrenoPartenza, TrenoPartenza) && Equals(other.Oggetti, Oggetti);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as AddInterventoRotToPlan);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result * 397) ^ (Convoglio != null ? Convoglio.GetHashCode() : 0);
                result = (result * 397) ^ (RigaTurnoTreno != null ? RigaTurnoTreno.GetHashCode() : 0);
                result = (result * 397) ^ (TurnoTreno != null ? TurnoTreno.GetHashCode() : 0);
                result = (result * 397) ^ (TrenoArrivo != null ? TrenoArrivo.GetHashCode() : 0);
                result = (result * 397) ^ (TrenoPartenza != null ? TrenoPartenza.GetHashCode() : 0);
                result = (result * 397) ^ (Oggetti != null ? Oggetti.GetHashCode() : 0);
                return result;
            }
        }
    }

    public class AddInterventoRotManToPlan : AddInterventoToPlan
    {

        public OggettoRotMan[] Oggetti { get; set; }

        public AddInterventoRotManToPlan()
        {

        }

        public AddInterventoRotManToPlan(Guid id,
                                   Guid commitId,
                                   long version,
                                   Guid idPeriodoProgrammazione,
                                   Guid idPlan,
                                   Guid idCommittente,
                                   Guid idLotto,
                                   Guid idImpianto,
                                   Guid idTipoIntervento,
                                   Guid idAppaltatore,
                                   Guid idCategoriaCommerciale,
                                   Guid idDirezioneRegionale,
                                   WorkPeriod workPeriod,
                                   string note,
                                   OggettoRotMan[] oggetti)
            : base(id, commitId, version, idPeriodoProgrammazione, idPlan, idCommittente, idLotto, idImpianto,
            idTipoIntervento, idAppaltatore, idCategoriaCommerciale, idDirezioneRegionale, workPeriod, note)
        {
            Contract.Requires(oggetti != null);

            Oggetti = oggetti;

        }

        public override string ToDescription()
        {
            return string.Format("Aggiungere una schedulazione  rotabile in manutenzione {0}  al piano ", Id);
        }

        public bool Equals(AddInterventoRotManToPlan other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Oggetti, Oggetti);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as AddInterventoRotManToPlan);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode() * 397) ^ (Oggetti != null ? Oggetti.GetHashCode() : 0);
            }
        }
    }

    public class AddInterventoAmbToPlan : AddInterventoToPlan
    {

        public string Description { get; set; }
        public int Quantity { get; set; }

        public AddInterventoAmbToPlan()
        {

        }

        public AddInterventoAmbToPlan(Guid id,
                                               Guid commitId,
                                               long version,
                                               Guid idPeriodoProgrammazione,
                                               Guid idPlan,
                                               Guid idCommittente,
                                               Guid idLotto,
                                               Guid idImpianto,
                                               Guid idTipoIntervento,
                                               Guid idAppaltatore,
                                               Guid idCategoriaCommerciale,
                                               Guid idDirezioneRegionale,
                                               WorkPeriod workPeriod,
                                               string note,
                                               int quantity,
                                               string description)
            : base(id, commitId, version, idPeriodoProgrammazione, idPlan, idCommittente, idLotto, idImpianto,
                   idTipoIntervento, idAppaltatore, idCategoriaCommerciale, idDirezioneRegionale, workPeriod, note)
        {
            Contract.Requires<ArgumentOutOfRangeException>(quantity > 0);

            Quantity = quantity;
            Description = description;
        }

        public override string ToDescription()
        {
            return string.Format("Aggiungere una schedulazione  ambiente {0}  al piano ", Id);
        }

        public bool Equals(AddInterventoAmbToPlan other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Description, Description) && other.Quantity == Quantity;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as AddInterventoAmbToPlan);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result * 397) ^ (Description != null ? Description.GetHashCode() : 0);
                result = (result * 397) ^ Quantity;
                return result;
            }
        }
    }
}
