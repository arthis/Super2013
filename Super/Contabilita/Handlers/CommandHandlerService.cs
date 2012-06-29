using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using CommandService;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.Impianto;
using Super.Contabilita.Commands.Lotto;

namespace Super.Contabilita.Handlers
{
    public class CommandHandlerService : ICommandHandlerService
    {
        private readonly Dictionary<Type, Func<ICommand, CommandValidation>> _handlers = new Dictionary<Type, Func<ICommand, CommandValidation>>();

        public void InitHandlers(ICommandRepository commandRepository, IEventRepository eventRepository)
        {
            var handlerHelper = new HandlerHelper(commandRepository);

            handlerHelper.Add<CreateImpianto>(_handlers, new CreateImpiantoHandler(eventRepository));
            handlerHelper.Add<UpdateImpianto>(_handlers, new UpdateImpiantoHandler(eventRepository));
            handlerHelper.Add<DeleteImpianto>(_handlers, new DeleteImpiantoHandler(eventRepository));

            handlerHelper.Add<CreateLotto>(_handlers, new CreateLottoHandler(eventRepository));
            handlerHelper.Add<UpdateLotto>(_handlers, new UpdateLottoHandler(eventRepository));
            handlerHelper.Add<DeleteLotto>(_handlers, new DeleteLottoHandler(eventRepository));

        }

        public void Subscribe(IBus bus)
        {
            //do nothing
        }


        public CommandValidation Execute(ICommand commandBase)
        {
            Contract.Requires<ArgumentNullException>(commandBase != null);


            var type = commandBase.GetType();
            if (_handlers.ContainsKey(type))
                return _handlers[type](commandBase);

            throw new HandlerForDomainEventNotFoundException(string.Format("No handler found for the command '{0}'", commandBase.GetType()));
          
        }
    }

}
