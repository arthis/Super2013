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
        private readonly Dictionary<Type, Func<IMessage, CommandValidation>> _handlers = new Dictionary<Type, Func<IMessage, CommandValidation>>();

        public void InitHandlers(IRepository repositoryEvent)
        {
            TypicalHandler.Add<CreateImpianto>(_handlers, new CreateImpiantoHandler(repositoryEvent));
            TypicalHandler.Add<UpdateImpianto>(_handlers, new UpdateImpiantoHandler(repositoryEvent));
            TypicalHandler.Add<DeleteImpianto>(_handlers, new DeleteImpiantoHandler(repositoryEvent));

            TypicalHandler.Add<CreateLotto>(_handlers, new CreateLottoHandler(repositoryEvent));
            TypicalHandler.Add<UpdateLotto>(_handlers, new UpdateLottoHandler(repositoryEvent));
            TypicalHandler.Add<DeleteLotto>(_handlers, new DeleteLottoHandler(repositoryEvent));

        }

        public void Subscribe(IBus bus)
        {
            //do nothing
        }


        public CommandValidation Execute(IMessage commandBase)
        {
            Contract.Requires<ArgumentNullException>(commandBase != null);


            var type = commandBase.GetType();
            if (_handlers.ContainsKey(type))
                return _handlers[type](commandBase);

            throw new HandlerForDomainEventNotFoundException(string.Format("No handler found for the command '{0}'", commandBase.GetType()));
          
        }
    }

}
