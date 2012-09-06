using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using CommonDomain.Persistence;

namespace CommonDomain.Core.Handlers.Events
{
    public class EventHandlerHelper
    {
        private readonly IProjectionRepositoryBuilder _projectionRepositoryBuilder;

        public EventHandlerHelper(IProjectionRepositoryBuilder projectionRepositoryBuilder)
        {
            Contract.Requires(projectionRepositoryBuilder!=null);

            _projectionRepositoryBuilder = projectionRepositoryBuilder;
        }

        public void Add<T>(Dictionary<Type, Action<IEvent>> dictionnary, IEventHandler<T> finalhandler) where T : IMessage
        {
            //to redo something does not go well here...
            dictionnary.Add(typeof(T), (evt) => new ProjectOnlyOnceOnlyHandler<T>(_projectionRepositoryBuilder.Build(),
                                                                finalhandler).Handle((T)evt));

        }
    }
}