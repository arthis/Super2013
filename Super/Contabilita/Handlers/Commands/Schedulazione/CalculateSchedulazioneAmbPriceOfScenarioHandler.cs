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
        private readonly ISessionFactory<ISessionContabilita> _sessionContabilitaFactory;


        public CalculateSchedulazioneAmbPriceOfScenarioHandler(IEventRepository eventRepository, ISessionFactory<ISessionContabilita> sessionContabilitaFactory)
            : base(eventRepository)
        {
            _sessionContabilitaFactory = sessionContabilitaFactory;
        }


        public override CommandValidation Execute(CalculateSchedulazioneAmbPriceOfScenario cmd)
        {
            Contract.Requires(cmd != null);

            var session = _sessionContabilitaFactory.CreateSession(cmd);

            var intervento = EventRepository.GetById<SchedulazioneAmb>(cmd.Id);

            throw new NotImplementedException();

            //if (intervento.IsNull())
            //{
            //    intervento = new SchedulazioneAmb();
            //}

            

            //intervento.CalculatePrice(session.Pricing);

            //var bachibousouk = EventRepository.GetById<Domain.Pricing.Pricing>(cmd.IdBachBouzouk);

            //intervento.CalculatePrice(bachibousouk);

            //EventRepository.Save(intervento, cmd.CommitId);

            //return intervento.CommandValidationMessages;
        }

    }

 
}
