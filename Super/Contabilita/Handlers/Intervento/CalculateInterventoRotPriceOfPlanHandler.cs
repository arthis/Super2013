using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.Intervento;
using Super.Contabilita.Domain;
using Super.Contabilita.Domain.Intervento;
using Super.Contabilita.Domain.TipoOggettoIntervento;

namespace Super.Contabilita.Handlers.Intervento
{

    public class CalculateInterventoRotPriceOfPlanHandler : CommandHandler<CalculateInterventoRotPriceOfPlan>
    {
        public CalculateInterventoRotPriceOfPlanHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(CalculateInterventoRotPriceOfPlan cmd)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);

            var intervento = EventRepository.GetById<Domain.Intervento.Intervento>(cmd.Id);

              if (intervento.IsNull())
              {
                  intervento = new Domain.Intervento.Intervento(cmd.Id,cmd.Oggetti.ToValueObject());
              }
                

            var bachibousouk = EventRepository.GetById<Domain.bachibouzouk.bachibouzouk>(cmd.IdBachBouzouk);
            var oggetti = new List<OggettoInterventoRot>();
            foreach (var oggetto in cmd.Oggetti)
            {
                var TipoOggetto = EventRepository.GetById<TipoOgettoInterventoRot>(oggetto.IdTipoOggettoInterventoRot);
                var o = Build.Ogget
            }

            intervento.CalculatePrice(bachibousouk, cmd.IdPlan, cmd.IdTipoIntervento, cmd.Oggetti.ToValueObject(), Period.FromMessage(cmd.Period));

            EventRepository.Save(intervento, cmd.CommitId);

            return intervento.CommandValidationMessages;
        }

    }

 
}
