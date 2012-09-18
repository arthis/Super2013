using System;
using System.Diagnostics.Contracts;
using System.Linq;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Contabilita.Commands.Schedulazione
{
    public abstract class CalculateSchedulazionePriceOfScenario : CommandBase
    {
        public Guid IdScenario { get; set; }
        public Guid IdSchedulazione { get; set; }
        public Guid IdTipoIntervento { get; set; }
        public WorkPeriod WorkPeriod { get; set; }
        public Period Period { get; set; }


        public CalculateSchedulazionePriceOfScenario()
        {

        }

        public CalculateSchedulazionePriceOfScenario(Guid id,
                                          Guid commitId,
                                          long version,
                                          Guid idScenario,
                                          Guid idSchedulazione,
                                          WorkPeriod workPeriod,
                                          Guid idTipoIntervento,
                                          Period period)
            : base(id, commitId, version)
        {
            Contract.Requires<ArgumentNullException>(idScenario != Guid.Empty);
            Contract.Requires<ArgumentNullException>(idSchedulazione != Guid.Empty);
            Contract.Requires<ArgumentNullException>(idTipoIntervento != Guid.Empty);
            Contract.Requires<ArgumentNullException>(workPeriod != null);
            Contract.Requires<ArgumentNullException>(period != null);

            IdScenario = idScenario;
            IdSchedulazione = idSchedulazione;
            IdTipoIntervento = idTipoIntervento;
            WorkPeriod = workPeriod;
            Period = period;

        }


        protected bool Equals(CalculateSchedulazionePriceOfScenario other)
        {
            return base.Equals(other) && IdScenario.Equals(other.IdScenario) && IdSchedulazione.Equals(other.IdSchedulazione) && IdTipoIntervento.Equals(other.IdTipoIntervento) && Equals(WorkPeriod, other.WorkPeriod) && Equals(Period, other.Period);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CalculateSchedulazionePriceOfScenario)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode * 397) ^ IdScenario.GetHashCode();
                hashCode = (hashCode * 397) ^ IdSchedulazione.GetHashCode();
                hashCode = (hashCode * 397) ^ IdTipoIntervento.GetHashCode();
                hashCode = (hashCode * 397) ^ (WorkPeriod != null ? WorkPeriod.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Period != null ? Period.GetHashCode() : 0);
                return hashCode;
            }
        }
    }

    public class CalculateSchedulazioneRotPriceOfScenario : CalculateSchedulazionePriceOfScenario
    {
        public CalculateSchedulazioneRotPriceOfScenario()
        {

        }

        public CalculateSchedulazioneRotPriceOfScenario(Guid id,
            Guid commitId,
            long version,
            Guid idScenario,
            Guid idSchedulazione,
            WorkPeriod workPeriod,
            Guid idTipoIntervento,
            Period period,
            OggettoRot[] oggetti)
            : base(id, commitId, version, idScenario, idSchedulazione, workPeriod,idTipoIntervento, period)
        {
            Contract.Requires(oggetti != null);

            Oggetti = oggetti;
            
        }

        public OggettoRot[] Oggetti { get; set; }
        

        public override string ToDescription()
        {
            return string.Format("Calcolare il prezzo della schedulazione rotabile {0}", Id);
        }

        protected bool Equals(CalculateSchedulazioneRotPriceOfScenario other)
        {
            return base.Equals(other) && Oggetti.SequenceEqual(other.Oggetti);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CalculateSchedulazioneRotPriceOfScenario) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ (Oggetti != null ? Oggetti.GetHashCode() : 0);
            }              
        }
    }

    public class CalculateSchedulazioneRotManPriceOfScenario : CalculateSchedulazionePriceOfScenario
    {
        public CalculateSchedulazioneRotManPriceOfScenario()
        {

        }

        public CalculateSchedulazioneRotManPriceOfScenario(Guid id,
            Guid commitId,
            long version,
            Guid idScenario,
            Guid idSchedulazione,
            WorkPeriod workPeriod,
            Guid idTipoIntervento,
            Period period,
            OggettoRotMan[] oggetti)
            : base(id, commitId, version, idScenario, idSchedulazione, workPeriod, idTipoIntervento, period)
        {
            Contract.Requires(oggetti != null);

            Oggetti = oggetti;
        }

        public OggettoRotMan[] Oggetti { get; set; }

        public override string ToDescription()
        {
            return string.Format("Calcolare il prezzo della schedulazione rotabile in manutenzione {0}", Id);
        }


        public bool Equals(CalculateSchedulazioneRotManPriceOfScenario other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.Oggetti.SequenceEqual(Oggetti);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CalculateSchedulazioneRotManPriceOfScenario);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode() * 397) ^ (Oggetti != null ? Oggetti.GetHashCode() : 0);
            }
        }
    }

    public class CalculateSchedulazioneAmbPriceOfScenario : CalculateSchedulazionePriceOfScenario
    {
        public CalculateSchedulazioneAmbPriceOfScenario()
        {

        }

        public CalculateSchedulazioneAmbPriceOfScenario(
            Guid id,
            Guid commitId,
            long version,
            Guid idScenario,
            Guid idSchedulazione,
            WorkPeriod workPeriod,
            Guid idTipoIntervento,
            Period period,
            int quantity,
            string description)
            : base(id, commitId, version, idScenario, idSchedulazione, workPeriod, idTipoIntervento, period)
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

        public bool Equals(CalculateSchedulazioneAmbPriceOfScenario other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.Quantity == Quantity && Equals(other.Description, Description);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CalculateSchedulazioneAmbPriceOfScenario);
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