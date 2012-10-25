using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using CommonDomain.Persistence;

namespace CommonDomain.Core.Handlers.Events
{
    public class EventHandlerHelper
    {
        private readonly IProjectionRepositoryBuilder _projectionRepositoryBuilder;
        private readonly Dictionary<Type, Action<IEvent>> _dictionnary;
        private readonly IBus _bus;
        private readonly Action<IEvent> _execute;


        public EventHandlerHelper(IProjectionRepositoryBuilder projectionRepositoryBuilder, Dictionary<Type, Action<IEvent>> dictionnary, IBus bus, Action<IEvent> execute)
        {
            Contract.Requires(projectionRepositoryBuilder!=null);

            _projectionRepositoryBuilder = projectionRepositoryBuilder;
            _dictionnary = dictionnary;
            _bus = bus;
            _execute = execute;
        }

        public EventHandlerHelper(IProjectionRepositoryBuilder projectionRepositoryBuilder, Dictionary<Type, Action<IEvent>> dictionnary, Action<IEvent> execute)
        {
            Contract.Requires(projectionRepositoryBuilder != null);

            _projectionRepositoryBuilder = projectionRepositoryBuilder;
            _dictionnary = dictionnary;
            _execute = execute;
        }

        public void Subscribe<T>( IEventHandler<T> finalhandler) where T : IEvent,IMessage
        {
            string subscriptionId = "Super";

            //to redo something does not go well here...
            _dictionnary.Add(typeof(T), (evt) => new ProjectOnlyOnceOnlyHandler<T>(_projectionRepositoryBuilder.Build(),
                                                                finalhandler).Handle((T)evt));

            if(_bus!=null)
                _bus.Subscribe<T>(subscriptionId, (evt) => _execute((T)evt));

        }
    }
}