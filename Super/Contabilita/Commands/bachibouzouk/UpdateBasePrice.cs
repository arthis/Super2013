using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Contabilita.Commands.bachibouzouk
{
    public class UpdateBasePrice: CommandBase
    {
        public decimal Value { get; set; }
        public IntervalOpened Intervall { get; set; }
        public Guid IdTipoIntervento { get; set; }
        public Guid IdGruppoOggettoInervento { get; set; }

        public UpdateBasePrice()
        {
            
        }

        public UpdateBasePrice(Guid id, Guid commitId, long version, decimal value, IntervalOpened intervall, Guid idTipoIntervento, Guid idGruppoOggettoInervento)
            : base(id, commitId, version)
        {
            Contract.Requires<ArgumentException>(intervall != null);
            Contract.Requires<ArgumentException>(idTipoIntervento!= Guid.Empty);
            Contract.Requires<ArgumentException>(idGruppoOggettoInervento != Guid.Empty);

            Value = value;
            Intervall = intervall;
            IdTipoIntervento = idTipoIntervento;
            IdGruppoOggettoInervento = idGruppoOggettoInervento;
            
        }

        public override string ToDescription()
        {
            return string.Format("Aggiornamo il prezzo di base " );
        }

        public bool Equals(UpdateBasePrice other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.Value == Value && Equals(other.Intervall, Intervall) && other.IdTipoIntervento.Equals(IdTipoIntervento) && other.IdGruppoOggettoInervento.Equals(IdGruppoOggettoInervento);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as UpdateBasePrice);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ Value.GetHashCode();
                result = (result*397) ^ (Intervall != null ? Intervall.GetHashCode() : 0);
                result = (result*397) ^ IdTipoIntervento.GetHashCode();
                result = (result*397) ^ IdGruppoOggettoInervento.GetHashCode();
                return result;
            }
        }
    }
}
