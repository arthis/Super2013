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
using Super.Contabilita.Handlers.Appaltatore;
using Super.Contabilita.Handlers.CategoriaCommerciale;
using Super.Contabilita.Handlers.Committente;
using Super.Contabilita.Handlers.DirezioneRegionale;
using Super.Contabilita.Handlers.Impianto;
using Super.Contabilita.Handlers.Lotto;
using Super.Contabilita.Handlers.MeasuringUnit;
using Super.Contabilita.Handlers.PeriodoProgrammazione;
using Super.Contabilita.Handlers.Repositories;
using Super.Contabilita.Handlers.TipoIntervento;

namespace Super.Contabilita.Handlers
{
    public class CommandHandlerService : CommandHandlerServiceBase
    {
        

        public override void InitHandlers(ICommandRepository commandRepository, IEventRepository eventRepository)
        {
            var handlerHelper = new CommandHandlerHelper(commandRepository);

            handlerHelper.Add(_handlers, new CreateImpiantoHandler(eventRepository));
            handlerHelper.Add(_handlers, new UpdateImpiantoHandler(eventRepository));
            handlerHelper.Add(_handlers, new DeleteImpiantoHandler(eventRepository));

            handlerHelper.Add(_handlers, new CreateLottoHandler(eventRepository));
            handlerHelper.Add(_handlers, new UpdateLottoHandler(eventRepository, new SqlLottoRepository()));
            handlerHelper.Add(_handlers, new DeleteLottoHandler(eventRepository));

            handlerHelper.Add(_handlers, new CreateAppaltatoreHandler(eventRepository));
            handlerHelper.Add(_handlers, new UpdateAppaltatoreHandler(eventRepository));
            handlerHelper.Add(_handlers, new DeleteAppaltatoreHandler(eventRepository));


            handlerHelper.Add(_handlers, new CreateCategoriaCommercialeHandler(eventRepository));
            handlerHelper.Add(_handlers, new UpdateCategoriaCommercialeHandler(eventRepository));
            handlerHelper.Add(_handlers, new DeleteCategoriaCommercialeHandler(eventRepository));

            handlerHelper.Add(_handlers, new CreateCommittenteHandler(eventRepository));
            handlerHelper.Add(_handlers, new UpdateCommittenteHandler(eventRepository));
            handlerHelper.Add(_handlers, new DeleteCommittenteHandler(eventRepository));

            handlerHelper.Add(_handlers, new CreateDirezioneRegionaleHandler(eventRepository));
            handlerHelper.Add(_handlers, new UpdateDirezioneRegionaleHandler(eventRepository));
            handlerHelper.Add(_handlers, new DeleteDirezioneRegionaleHandler(eventRepository));

            handlerHelper.Add(_handlers, new CreateMeasuringUnitHandler(eventRepository));
            handlerHelper.Add(_handlers, new UpdateMeasuringUnitHandler(eventRepository));
            handlerHelper.Add(_handlers, new DeleteMeasuringUnitHandler(eventRepository));

            handlerHelper.Add(_handlers, new CreatePeriodoProgrammazioneHandler(eventRepository));
            handlerHelper.Add(_handlers, new UpdatePeriodoProgrammazioneHandler(eventRepository));
            handlerHelper.Add(_handlers, new DeletePeriodoProgrammazioneHandler(eventRepository));
            handlerHelper.Add(_handlers, new ClosePeriodoProgrammazioneHandler(eventRepository));

            handlerHelper.Add(_handlers, new CreateTipoInterventoAmbHandler(eventRepository));
            handlerHelper.Add(_handlers, new UpdateTipoInterventoAmbHandler(eventRepository));
            handlerHelper.Add(_handlers, new DeleteTipoInterventoAmbHandler(eventRepository));

            handlerHelper.Add(_handlers, new CreateTipoInterventoRotHandler(eventRepository));
            handlerHelper.Add(_handlers, new UpdateTipoInterventoRotHandler(eventRepository));
            handlerHelper.Add(_handlers, new DeleteTipoInterventoRotHandler(eventRepository));

            handlerHelper.Add(_handlers, new CreateTipoInterventoRotManHandler(eventRepository));
            handlerHelper.Add(_handlers, new UpdateTipoInterventoRotManHandler(eventRepository));
            handlerHelper.Add(_handlers, new DeleteTipoInterventoRotManHandler(eventRepository));

        }

        public override void Subscribe(IBus bus)
        {
            //do nothing
        }


        
    }

}
