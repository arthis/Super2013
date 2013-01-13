using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.Schedulazione;
using Super.Contabilita.Domain;
using Super.Contabilita.Domain.Intervento;
using Super.Contabilita.Domain.Schedulazione;

namespace Super.Contabilita.Handlers.Commands.Schedulazione
{

    public class CalculateSchedulazioneAmbPriceOfScenarioHandler : CommandHandler<CalculateSchedulazioneAmbPriceOfScenario>
    {
        private readonly Domain.Pricing.PricingAmb _pricing;


        public CalculateSchedulazioneAmbPriceOfScenarioHandler(IEventRepository eventRepository, Domain.Pricing.PricingAmb pricing)
            : base(eventRepository)
        {
            _pricing = pricing;
        }


        public override CommandValidation Execute(CalculateSchedulazioneAmbPriceOfScenario cmd)
        {
            Contract.Requires(cmd != null);

            var schedulazione = EventRepository.GetById<Domain.Schedulazione.SchedulazioneAmb>(cmd.Id);

            if (schedulazione.IsNull())
            {
                schedulazione = new SchedulazioneAmb(cmd.Id, cmd.IdTipoIntervento, cmd.IdScenario, cmd.Quantity, cmd.Period.ToDomain(), cmd.WorkPeriod.ToDomain());
            }


            schedulazione.CalculateBasePrice(_pricing);


            EventRepository.Save(schedulazione, cmd.CommitId);

            return schedulazione.CommandValidationMessages;
        }

    }

 
}
