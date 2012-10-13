using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using CommandService;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.Impianto;
using Super.Contabilita.Commands.Lotto;
using Super.Contabilita.Domain;
using Super.Contabilita.Handlers.Commands.Appaltatore;
using Super.Contabilita.Handlers.Commands.CategoriaCommerciale;
using Super.Contabilita.Handlers.Commands.Committente;
using Super.Contabilita.Handlers.Commands.DirezioneRegionale;
using Super.Contabilita.Handlers.Commands.Lotto;
using Super.Contabilita.Handlers.Commands.MeasuringUnit;
using Super.Contabilita.Handlers.Commands.PeriodoProgrammazione;
using Super.Contabilita.Handlers.Commands.TipoIntervento;
using Super.Contabilita.Handlers.Impianto;
using Super.Contabilita.Handlers.Repositories;

namespace Super.Contabilita.Handlers
{
    public class CommandHandlerService<TSession> : CommandHandlerServiceBase<TSession> where TSession:ISessionContabilita
    {


        public override void InitCommandHandlers(ICommandRepository commandRepository, IEventRepository eventRepository, ISessionFactory<TSession> sessionFactory)
        {
            var handlerHelper = new CommandHandlerHelper<TSession>(commandRepository, sessionFactory, _handlers);

            handlerHelper.Add( new CreateImpiantoHandler(eventRepository));
            handlerHelper.Add( new UpdateImpiantoHandler(eventRepository));
            handlerHelper.Add( new DeleteImpiantoHandler(eventRepository));

            handlerHelper.Add( new CreateLottoHandler(eventRepository));
            handlerHelper.Add( new UpdateLottoHandler(eventRepository, new SqlLottoRepository()));
            handlerHelper.Add( new DeleteLottoHandler(eventRepository));

            handlerHelper.Add( new CreateAppaltatoreHandler(eventRepository));
            handlerHelper.Add( new UpdateAppaltatoreHandler(eventRepository));
            handlerHelper.Add( new DeleteAppaltatoreHandler(eventRepository));


            handlerHelper.Add( new CreateCategoriaCommercialeHandler(eventRepository));
            handlerHelper.Add( new UpdateCategoriaCommercialeHandler(eventRepository));
            handlerHelper.Add( new DeleteCategoriaCommercialeHandler(eventRepository));

            handlerHelper.Add( new CreateCommittenteHandler(eventRepository));
            handlerHelper.Add( new UpdateCommittenteHandler(eventRepository));
            handlerHelper.Add( new DeleteCommittenteHandler(eventRepository));

            handlerHelper.Add( new CreateDirezioneRegionaleHandler(eventRepository));
            handlerHelper.Add( new UpdateDirezioneRegionaleHandler(eventRepository));
            handlerHelper.Add( new DeleteDirezioneRegionaleHandler(eventRepository));

            handlerHelper.Add( new CreateMeasuringUnitHandler(eventRepository));
            handlerHelper.Add( new UpdateMeasuringUnitHandler(eventRepository));
            handlerHelper.Add( new DeleteMeasuringUnitHandler(eventRepository));

            handlerHelper.Add( new CreatePeriodoProgrammazioneHandler(eventRepository));
            handlerHelper.Add( new UpdatePeriodoProgrammazioneHandler(eventRepository));
            handlerHelper.Add( new DeletePeriodoProgrammazioneHandler(eventRepository));
            handlerHelper.Add( new ClosePeriodoProgrammazioneHandler(eventRepository));

            handlerHelper.Add( new CreateTipoInterventoAmbHandler(eventRepository));
            handlerHelper.Add( new UpdateTipoInterventoAmbHandler(eventRepository));
            handlerHelper.Add( new DeleteTipoInterventoAmbHandler(eventRepository));

            handlerHelper.Add( new CreateTipoInterventoRotHandler(eventRepository));
            handlerHelper.Add( new UpdateTipoInterventoRotHandler(eventRepository));
            handlerHelper.Add( new DeleteTipoInterventoRotHandler(eventRepository));

            handlerHelper.Add( new CreateTipoInterventoRotManHandler(eventRepository));
            handlerHelper.Add( new UpdateTipoInterventoRotManHandler(eventRepository));
            handlerHelper.Add( new DeleteTipoInterventoRotManHandler(eventRepository));

        }

        public override void Subscribe(IBus bus)
        {
            //do nothing
        }


        
    }

}
