using System;
using Super.Contabilita.Events.Builders;
using Super.Contabilita.Events.TipoOggettoIntervento.Rotabile;

namespace Super.Contabilita.Domain.TipoOggettoIntervento
{
    public class LocomotiveRot : TipoOgettoInterventoRot
    {
       
        public LocomotiveRot()
        {
            
        }

        public LocomotiveRot(Guid id,string description, string sign)
        {
            var evt = Build.LocomotiveRotCreated
                .ForDescription(description)
                .ForSign(sign);
            
            RaiseEvent(id,evt);
        }

        public void Apply(LocomotiveRotCreated evt)
        {
            this.Id = evt.Id;
        }


        public void Update(string description, string sign)
        {
            var evt = Build.LocomotiveRotUpdated
             .ForDescription(description)
             .ForSign(sign);

            RaiseEvent(evt);
        }


        public void Apply(LocomotiveRotUpdated evt)
        {

        }
    }
}