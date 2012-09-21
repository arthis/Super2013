using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.Intervento;
using Super.Contabilita.Commands.Schedulazione;
using Super.Contabilita.Domain.Intervento;

namespace Super.Contabilita.Handlers.Schedulazione
{

    public class CalculateSchedulazioneAmbPriceOfScenarioHandler : CommandHandler<CalculateSchedulazioneAmbPriceOfScenario>
    {
        public CalculateSchedulazioneAmbPriceOfScenarioHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(CalculateSchedulazioneAmbPriceOfScenario cmd)
        {

            throw new NotImplementedException();

            //Contract.Requires(cmd != null);

            //var intervento = EventRepository.GetById<Domain.Intervento.InterventoRot>(cmd.Id);

            //if (intervento.IsNull())
            //{
            //    intervento = new InterventoRot(cmd.Id, cmd.IdTipoIntervento, cmd.IdPlan, cmd.Oggetti.ToDomain(), cmd.WorkPeriod.ToDomain());
            //}

            //var bachibousouk = EventRepository.GetById<Domain.Pricing.Pricing>(cmd.IdBachBouzouk);
            
            //intervento.CalculatePrice(bachibousouk);

            //EventRepository.Save(intervento, cmd.CommitId);

            //return intervento.CommandValidationMessages;
        }

    }

 
}
