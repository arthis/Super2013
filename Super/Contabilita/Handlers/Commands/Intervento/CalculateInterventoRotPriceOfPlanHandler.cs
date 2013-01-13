using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.Intervento;
using Super.Contabilita.Domain.Intervento;
using Super.Contabilita.Domain.Pricing;

namespace Super.Contabilita.Handlers.Commands.Intervento
{

    public class CalculateInterventoRotPriceOfPlanHandler : CommandHandler<CalculateInterventoRotPriceOfPlan>
    {
        private readonly PricingRot _pricing;

        public CalculateInterventoRotPriceOfPlanHandler(IEventRepository eventRepository, PricingRot pricing)
            : base(eventRepository)
        {
            _pricing = pricing;
        }


        public override CommandValidation Execute(CalculateInterventoRotPriceOfPlan cmd)
        {
            Contract.Requires(cmd != null);

            var intervento = EventRepository.GetById<Domain.Intervento.InterventoRot>(cmd.Id);

            if (intervento.IsNull())
            {
                intervento = new InterventoRot(cmd.Id, cmd.IdTipoIntervento, cmd.IdPlan, cmd.Oggetti.ToDomain(), cmd.WorkPeriod.ToDomain());
            }



            intervento.CalculatePrice(_pricing);

            EventRepository.Save(intervento, cmd.CommitId);

            return intervento.CommandValidationMessages;
        }

    }

 
}
