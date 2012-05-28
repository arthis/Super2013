using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using CommandService;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using Super.Appaltatore.Commands;

namespace Super.Appaltatore.Handlers
{
    public class CommandHandlerService : ICommandHandlerService
    {
        private readonly Dictionary<Type, Func<Object, CommandValidation>> _handlers = new Dictionary<Type, Func<Object, CommandValidation>>();

        public void InitHandlers(IRepository repositoryEvent)
        {
            _handlers.Add(typeof(ProgrammareInterventoAmb),
                          (cmd) => new ProgrammareInterventoAmbHandler(repositoryEvent).Execute((ProgrammareInterventoAmb)cmd));
            _handlers.Add(typeof(ProgrammareInterventoRot),
                          (cmd) => new ProgrammareInterventoRotHandler(repositoryEvent).Execute((ProgrammareInterventoRot)cmd));
            _handlers.Add(typeof(ProgrammareInterventoRotMan),
                          (cmd) => new ProgrammareInterventoRotManHandler(repositoryEvent).Execute((ProgrammareInterventoRotMan)cmd));
        }


        public CommandValidation Execute(ICommand commandBase)
        {
            Contract.Requires<ArgumentNullException>(commandBase != null);


            var type = commandBase.GetType();
            if (_handlers.ContainsKey(type))
                return _handlers[type](commandBase);

            throw new Exception(string.Format("No handler found for the command '{0}'", commandBase.GetType()));
          
        }
    }

}
