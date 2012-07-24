using System;
using System.Diagnostics.Contracts;
using System.Linq;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Contabilita.Commands.Schedulation
{
    public abstract class CalculateSchedulationPrice:CommandBase
    {
        public Guid IdPeriodoProgrammazione { get; set; }
        public Guid IdPlan { get; set; }
        public Guid IdCommittente { get; set; }
        public Guid IdLotto { get; set; }
        public Guid IdImpianto { get; set; }
        public Guid IdTipoSchedulation { get; set; }
        public Guid IdAppaltatore { get; set; }
        public Guid IdCategoriaCommerciale { get; set; }
        public Guid IdDirezioneRegionale { get; set; }
        public WorkPeriod Period { get; set; }
        public string Note { get; set; }

        public CalculateSchedulationPrice()
        {
            
        }

        public CalculateSchedulationPrice(Guid id,
                                          Guid commitId,
                                          long version,
                                          Guid idPeriodoProgrammazione,
                                          Guid idPlan,
                                          Guid idCommittente,
                                          Guid idLotto,
                                          Guid idImpianto,
                                          Guid idTipoSchedulation,
                                          Guid idAppaltatore,
                                          Guid idCategoriaCommerciale,
                                          Guid idDirezioneRegionale,
                                          WorkPeriod period,
                                          string note)
            : base(id,commitId,  version)
        {
            Contract.Requires<ArgumentNullException>(idPeriodoProgrammazione != Guid.Empty);
            Contract.Requires<ArgumentNullException>(idPlan != Guid.Empty);
            Contract.Requires<ArgumentNullException>(idCommittente != Guid.Empty);
            Contract.Requires<ArgumentNullException>(idLotto != Guid.Empty);
            Contract.Requires<ArgumentNullException>(idImpianto != Guid.Empty);
            Contract.Requires<ArgumentNullException>(idTipoSchedulation != Guid.Empty);
            Contract.Requires<ArgumentNullException>(idAppaltatore != Guid.Empty);
            Contract.Requires<ArgumentNullException>(idCategoriaCommerciale != Guid.Empty);
            Contract.Requires<ArgumentNullException>(idDirezioneRegionale != Guid.Empty);
            Contract.Requires<ArgumentNullException>(period != null);

            IdPeriodoProgrammazione = idPeriodoProgrammazione;
            IdPlan = idPlan;
            IdCommittente = idCommittente;
            IdLotto = idLotto;
            IdImpianto = idImpianto;
            IdTipoSchedulation = idTipoSchedulation;
            IdAppaltatore = idAppaltatore;
            IdCategoriaCommerciale = idCategoriaCommerciale;
            IdDirezioneRegionale = idDirezioneRegionale;
            Period = period;
            Note = note;
        }



        public bool Equals(CalculateSchedulationPrice other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.Id.Equals(Id) && other.IdImpianto.Equals(IdImpianto) && other.IdTipoSchedulation.Equals(IdTipoSchedulation) && other.IdAppaltatore.Equals(IdAppaltatore) && other.IdCategoriaCommerciale.Equals(IdCategoriaCommerciale) && other.IdDirezioneRegionale.Equals(IdDirezioneRegionale) && Equals(other.Period, Period) && Equals(other.Note, Note);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CalculateSchedulationPrice);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ Id.GetHashCode();
                result = (result*397) ^ IdImpianto.GetHashCode();
                result = (result*397) ^ IdTipoSchedulation.GetHashCode();
                result = (result*397) ^ IdAppaltatore.GetHashCode();
                result = (result*397) ^ IdCategoriaCommerciale.GetHashCode();
                result = (result*397) ^ IdDirezioneRegionale.GetHashCode();
                result = (result*397) ^ (Period != null ? Period.GetHashCode() : 0);
                result = (result*397) ^ (Note != null ? Note.GetHashCode() : 0);
                return result;
            }
        }
    }

    public class CalculateSchedulationRotPrice : CalculateSchedulationPrice
    {
        public CalculateSchedulationRotPrice()
        {

        }

        public CalculateSchedulationRotPrice(Guid id, Guid commitId, long version, Guid idPeriodoProgrammazione,
                                    Guid idPlan,
                                    Guid idCommittente,
                                    Guid idLotto, Guid idImpianto, Guid idTipoSchedulation, Guid idAppaltatore, Guid idCategoriaCommerciale, Guid idDirezioneRegionale, WorkPeriod period, string note, OggettoRot[] oggetti, Treno trenoArrivo, Treno trenoPartenza, string turnoTreno, string rigaTurnoTreno, string convoglio)
            : base(id, commitId, version, idPeriodoProgrammazione, idPlan, idCommittente, idLotto, idImpianto, idTipoSchedulation, idAppaltatore, idCategoriaCommerciale, idDirezioneRegionale, period, note)
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
            return string.Format("Calcolare il prezzo della schedulazione rotabile {0}", Id);
        }

        public bool Equals(CalculateSchedulationRotPrice other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.Oggetti.SequenceEqual(Oggetti) && Equals(other.TrenoArrivo, TrenoArrivo) && Equals(other.TrenoPartenza, TrenoPartenza) && Equals(other.TurnoTreno, TurnoTreno) && Equals(other.RigaTurnoTreno, RigaTurnoTreno) && Equals(other.Convoglio, Convoglio);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CalculateSchedulationRotPrice);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result * 397) ^ (Oggetti != null ? Oggetti.GetHashCode() : 0);
                result = (result * 397) ^ (TrenoArrivo != null ? TrenoArrivo.GetHashCode() : 0);
                result = (result * 397) ^ (TrenoPartenza != null ? TrenoPartenza.GetHashCode() : 0);
                result = (result * 397) ^ (TurnoTreno != null ? TurnoTreno.GetHashCode() : 0);
                result = (result * 397) ^ (RigaTurnoTreno != null ? RigaTurnoTreno.GetHashCode() : 0);
                result = (result * 397) ^ (Convoglio != null ? Convoglio.GetHashCode() : 0);
                return result;
            }
        }
    }

    public class CalculateSchedulationRotManPrice : CalculateSchedulationPrice
    {
        public CalculateSchedulationRotManPrice()
        {

        }

        public CalculateSchedulationRotManPrice(Guid id, Guid commitId, long version, Guid idPeriodoProgrammazione,
                                   Guid idPlan,
                                   Guid idCommittente,
                                   Guid idLotto, Guid idImpianto, Guid idTipoSchedulation, Guid idAppaltatore, Guid idCategoriaCommerciale, Guid idDirezioneRegionale, WorkPeriod period, string note, OggettoRotMan[] oggetti)
            : base(id, commitId, version, idPeriodoProgrammazione, idPlan, idCommittente, idLotto, idImpianto, idTipoSchedulation, idAppaltatore, idCategoriaCommerciale, idDirezioneRegionale, period, note)
        {
            Contract.Requires(oggetti != null);

            Oggetti = oggetti;
        }

        public OggettoRotMan[] Oggetti { get; set; }

        public override string ToDescription()
        {
            return string.Format("Calcolare il prezzo della schedulazione rotabile in manutenzione {0}", Id);
        }


        public bool Equals(CalculateSchedulationRotManPrice other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.Oggetti.SequenceEqual(Oggetti);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CalculateSchedulationRotManPrice);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode() * 397) ^ (Oggetti != null ? Oggetti.GetHashCode() : 0);
            }
        }
    }

    public class CalculateSchedulationAmbPrice : CalculateSchedulationPrice
    {
        public CalculateSchedulationAmbPrice()
        {

        }

        public CalculateSchedulationAmbPrice(Guid id, Guid commitId, long version, Guid idPeriodoProgrammazione,
                                   Guid idPlan,
                                   Guid idCommittente,
                                   Guid idLotto, Guid idImpianto, Guid idTipoSchedulation, Guid idAppaltatore, Guid idCategoriaCommerciale, Guid idDirezioneRegionale, WorkPeriod period, string note, int quantity, string description)
            : base(id, commitId, version, idPeriodoProgrammazione, idPlan, idCommittente, idLotto, idImpianto, idTipoSchedulation, idAppaltatore, idCategoriaCommerciale, idDirezioneRegionale, period, note)
        {
            Quantity = quantity;
            Description = description;
        }

        public int Quantity { get; set; }
        public string Description { get; set; }

        public override string ToDescription()
        {
            return string.Format("Calcolare il prezzo della schedulazione ambiente {0}", Id);
        }

        public bool Equals(CalculateSchedulationAmbPrice other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.Quantity == Quantity && Equals(other.Description, Description);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CalculateSchedulationAmbPrice);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result * 397) ^ Quantity;
                result = (result * 397) ^ (Description != null ? Description.GetHashCode() : 0);
                return result;
            }
        }
    }
}