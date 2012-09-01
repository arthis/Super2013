using System;
using Super.Contabilita.Events;
using Super.Contabilita.Events.Builders;
using Super.Contabilita.Events.TipoOggettoIntervento.RotabileInManutenzione;

namespace Super.Contabilita.Domain.TipoOggettoIntervento
{
    public class CarriageRotMan : TipoOgettoInterventoRotMan
    {
        public CarriageRotMan()
        {
            
        }

          public CarriageRotMan(Guid id, string description, string sign, bool isInternational, Guid idGruppoOggettoIntervento)
              :base(id)
        {
            var evt = BuildEvt.CarriageRotManCreated
                .ForDescription(description)
                .ForSign(sign)
                .IsInternational(isInternational)
                .ForGruppoOggetto(idGruppoOggettoIntervento);
            
            RaiseEvent(id,evt);
        }

        public void Apply(CarriageRotManCreated evt)
        {
            this.Id = evt.Id;
        }

        public void Update(string description, string sign, bool isInternational, Guid idGruppoOggettoIntervento)
        {
            var evt = BuildEvt.CarriageRotManUpdated
             .ForDescription(description)
             .ForSign(sign)
             .IsInternational(isInternational)
             .ForGruppoOggetto(idGruppoOggettoIntervento);

            RaiseEvent(evt);
        }


        public void Apply(CarriageRotManUpdated evt)
        {

        }
    }
}