using System;
using Super.Contabilita.Events.Builders;
using Super.Contabilita.Events.TipoOggettoIntervento.Rotabile;

namespace Super.Contabilita.Domain.TipoOggettoIntervento
{
    public class CarriageRot : TipoOgettoInterventoRot
    {

        public CarriageRot()
        {
            
        }

        public CarriageRot(Guid id,string description, string sign, bool isInternational)
        {
            var evt = Build.CarriageRotCreated
                .ForDescription(description)
                .ForSign(sign)
                .IsInternational(isInternational);
            
            RaiseEvent(id,evt);
        }

        public void Apply(CarriageRotCreated evt)
        {
            this.Id = evt.Id;
        }


        public void Update(string description, string sign, bool isInternational)
        {
            var evt = Build.CarriageRotUpdated
             .ForDescription(description)
             .ForSign(sign)
             .IsInternational(isInternational);

            RaiseEvent(evt);
        }


        public void Apply(CarriageRotUpdated evt)
        {

        }
    }
}