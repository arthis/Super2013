﻿using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.Intervento;
using Super.Contabilita.Domain.Intervento;

namespace Super.Contabilita.Handlers.Commands.Intervento
{

    public class CalculateInterventoRotPriceOfPlanHandler : CommandHandler<CalculateInterventoRotPriceOfPlan>
    {
        public CalculateInterventoRotPriceOfPlanHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(CalculateInterventoRotPriceOfPlan cmd)
        {
            Contract.Requires(cmd != null);

            var intervento = EventRepository.GetById<Domain.Intervento.InterventoRot>(cmd.Id);

            if (intervento.IsNull())
            {
                intervento = new InterventoRot(cmd.Id, cmd.IdTipoIntervento, cmd.IdPlan, cmd.Oggetti.ToDomain(), cmd.WorkPeriod.ToDomain());
            }

            var bachibousouk = EventRepository.GetById<Domain.Pricing.Pricing>(cmd.IdBachBouzouk);
            
            intervento.CalculatePrice(bachibousouk);

            EventRepository.Save(intervento, cmd.CommitId);

            return intervento.CommandValidationMessages;
        }

    }

 
}
