using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace CommonDomain.Core.Handlers.Commands
{
    public class PortHandlerHelper
    {

        public void Add<TEvent,TCommand>(Dictionary<Type, Func<IEvent,ICommand>> dictionnary,IPortHandler<TEvent,TCommand> eventHandler) 
            where TEvent  : IEvent
            where TCommand  : ICommand
        {
            Contract.Requires(dictionnary != null);

            dictionnary.Add(typeof(TEvent), (evt)=> eventHandler.Port((TEvent)evt) );
        }
    }
}