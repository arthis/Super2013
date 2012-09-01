using System;
using Super.Contabilita.Events;
using Super.Contabilita.Events.Builders;
using Super.Contabilita.Events.TipoOggettoIntervento.RotabileInManutenzione;

namespace Super.Contabilita.Domain.TipoOggettoIntervento
{
    public class LocomotiveRotMan : TipoOgettoInterventoRotMan
    {
         public LocomotiveRotMan()
        {
            
        }

        public LocomotiveRotMan(Guid id, string description, string sign, Guid idGruppoOggettoIntervento)
             : base(id)
        {
            var evt = BuildEvt.LocomotiveRotManCreated
                .ForDescription(description)
                .ForSign(sign)
                .ForGruppoOggetto(idGruppoOggettoIntervento);
            
            RaiseEvent(id,evt);
        }

        public void Apply(LocomotiveRotManCreated evt)
        {
            this.Id = evt.Id;
        }


        public void Update(string description, string sign, Guid idGruppoOggettoIntervento)
        {
            var evt = BuildEvt.LocomotiveRotManUpdated
             .ForDescription(description)
             .ForSign(sign)
             .ForGruppoOggetto(idGruppoOggettoIntervento);

            RaiseEvent(evt);
        }


        public void Apply(LocomotiveRotManUpdated evt)
        {

        }
    }
}