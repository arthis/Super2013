using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using CommandService;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.Impianto;
using Super.Contabilita.Commands.Lotto;
using Super.Contabilita.Handlers.Repositories;

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

        }

        public override void Subscribe(IBus bus)
        {
            //do nothing
        }


        
    }

}
