﻿using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Programmazione.Events.Schedulazione
{
    public abstract class SchedulazioneAddedToPlan : Message, IEvent
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
        public Period Period { get; set; }
        





        public SchedulazioneAddedToPlan()
        {

        }

        public SchedulazioneAddedToPlan(Guid id,
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
            Contract.Requires<ArgumentNullException>(idPeriodoProgrammazione != Guid.Empty);
            Contract.Requires<ArgumentNullException>(idPlan != Guid.Empty);
            Contract.Requires<ArgumentNullException>(idCommittente != Guid.Empty);
            Contract.Requires<ArgumentNullException>(idLotto != Guid.Empty);
            Contract.Requires<ArgumentNullException>(idImpianto != Guid.Empty);
            Contract.Requires<ArgumentNullException>(idTipoIntervento != Guid.Empty);
            Contract.Requires<ArgumentNullException>(idAppaltatore != Guid.Empty);
            Contract.Requires<ArgumentNullException>(idCategoriaCommerciale != Guid.Empty);
            Contract.Requires<ArgumentNullException>(idDirezioneRegionale != Guid.Empty);
            Contract.Requires<ArgumentNullException>(workPeriod != null);


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

        public bool Equals(SchedulazioneAddedToPlan other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.IdPeriodoProgrammazione.Equals(IdPeriodoProgrammazione) && other.IdPlan.Equals(IdPlan) && other.IdCommittente.Equals(IdCommittente) && other.IdLotto.Equals(IdLotto) && other.IdImpianto.Equals(IdImpianto) && other.IdTipoIntervento.Equals(IdTipoIntervento) && other.IdAppaltatore.Equals(IdAppaltatore) && other.IdCategoriaCommerciale.Equals(IdCategoriaCommerciale) && other.IdDirezioneRegionale.Equals(IdDirezioneRegionale) && Equals(other.Note, Note) && Equals(other.WorkPeriod, WorkPeriod);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as SchedulazioneAddedToPlan);
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

    public class SchedulazioneRotAddedToPlan : SchedulazioneAddedToPlan
    {
        public string Convoglio { get; set; }
        public string RigaTurnoTreno { get; set; }
        public string TurnoTreno { get; set; }
        public Treno TrenoArrivo { get; set; }
        public Treno TrenoPartenza { get; set; }
        public OggettoRot[] Oggetti { get; set; }



        public SchedulazioneRotAddedToPlan()
        {

        }

        public SchedulazioneRotAddedToPlan(Guid id,
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
            Contract.Requires<ArgumentNullException>(oggetti != null);

            Oggetti = oggetti;
            TrenoPartenza = trenoPartenza;
            TrenoArrivo = trenoArrivo;
            TurnoTreno = turnoTreno;
            RigaTurnoTreno = rigaTurnoTreno;
            Convoglio = convoglio;

        }

        public override string ToDescription()
        {
            return string.Format("schedulazione  rotabile {0} aggiunta al piano ", Id);
        }

        public bool Equals(SchedulazioneRotAddedToPlan other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Convoglio, Convoglio) && Equals(other.RigaTurnoTreno, RigaTurnoTreno) && Equals(other.TurnoTreno, TurnoTreno) && Equals(other.TrenoArrivo, TrenoArrivo) && Equals(other.TrenoPartenza, TrenoPartenza) && Equals(other.Oggetti, Oggetti);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as SchedulazioneRotAddedToPlan);
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

    public class SchedulazioneRotManAddedToPlan : SchedulazioneAddedToPlan
    {

        public OggettoRotMan[] Oggetti { get; set; }

        public SchedulazioneRotManAddedToPlan()
        {

        }

        public SchedulazioneRotManAddedToPlan(Guid id,
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
            Contract.Requires<ArgumentNullException>(oggetti != null);

            Oggetti = oggetti;

        }

        public override string ToDescription()
        {
            return string.Format("Aggiungere una schedulazione  rotabile in manutenzione {0}  al plan ", Id);
        }

        public bool Equals(SchedulazioneRotManAddedToPlan other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Oggetti, Oggetti);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as SchedulazioneRotManAddedToPlan);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode() * 397) ^ (Oggetti != null ? Oggetti.GetHashCode() : 0);
            }
        }
    }

    public class SchedulazioneAmbAddedToPlan : SchedulazioneAddedToPlan
    {

        public string Description { get; set; }
        public int Quantity { get; set; }

        public SchedulazioneAmbAddedToPlan()
        {

        }

        public SchedulazioneAmbAddedToPlan(Guid id,
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
            return string.Format("Aggiungere una schedulazione  ambiente {0}  al plan ", Id);
        }

        public bool Equals(SchedulazioneAmbAddedToPlan other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Description, Description) && other.Quantity == Quantity;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as SchedulazioneAmbAddedToPlan);
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
