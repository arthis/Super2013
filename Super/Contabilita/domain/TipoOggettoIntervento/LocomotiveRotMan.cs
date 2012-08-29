using System;
using Super.Contabilita.Events.Builders;
using Super.Contabilita.Events.TipoOggettoIntervento.RotabileInManutenzione;

namespace Super.Contabilita.Domain.TipoOggettoIntervento
{
    public class LocomotiveRotMan : TipoOgettoInterventoRotMan
    {
         public LocomotiveRotMan()
        {
            
        }

        public LocomotiveRotMan(Guid id,string description, string sign)
        {
            var evt = Build.LocomotiveRotManCreated
                .ForDescription(description)
                .ForSign(sign);
            
            RaiseEvent(id,evt);
        }

        public void Apply(LocomotiveRotManCreated evt)
        {
            this.Id = evt.Id;
        }


        public void Update(string description, string sign)
        {
            var evt = Build.LocomotiveRotManUpdated
             .ForDescription(description)
             .ForSign(sign);

            RaiseEvent(evt);
        }


        public void Apply(LocomotiveRotManUpdated evt)
        {

        }
    }
}