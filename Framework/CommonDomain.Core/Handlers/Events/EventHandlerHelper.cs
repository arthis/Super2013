using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using CommonDomain.Persistence;

namespace CommonDomain.Core.Handlers.Events
{
    public class Projection
    {
        public string ProjectionName {get ; set; }
        public Action<IEvent> Projects {get ; set; }
    }
    public class EventHandlerHelper
    {
        private readonly string _boundedContext;
        private readonly IProjectionRepositoryBuilder _projectionRepositoryBuilder;
        private readonly Dictionary<Type, IEnumerable<Projection>> _dictionnary;
        private readonly IBus _bus;
        private readonly Action<IEvent> _execute;


        public EventHandlerHelper(string boundedContext,IProjectionRepositoryBuilder projectionRepositoryBuilder, Dictionary<Type, IEnumerable<Projection>> dictionnary, IBus bus, Action<IEvent> execute)
        {
            Contract.Requires(projectionRepositoryBuilder!=null);
            Contract.Requires(!string.IsNullOrEmpty(boundedContext));

            _boundedContext = boundedContext;
            _projectionRepositoryBuilder = projectionRepositoryBuilder;
            _dictionnary = dictionnary;
            _bus = bus;
            _execute = execute;
        }

        public EventHandlerHelper(IProjectionRepositoryBuilder projectionRepositoryBuilder, Dictionary<Type, IEnumerable<Projection>> dictionnary, Action<IEvent> execute)
        {
            Contract.Requires(projectionRepositoryBuilder != null);

            _projectionRepositoryBuilder = projectionRepositoryBuilder;
            _dictionnary = dictionnary;
            _execute = execute;
        }

        public void Subscribe<T>( IEventHandler<T> finalhandler) where T : IEvent,IMessage
        {
            if (_dictionnary.ContainsKey(typeof (T)))
                ((List<Projection>) _dictionnary[typeof (T)]).Add(
                    new Projection()
                        {
                            Projects = (evt) => new ProjectOnlyOnceOnlyHandler<T>(_projectionRepositoryBuilder.Build(), finalhandler).Handle((T) evt),
                            ProjectionName = finalhandler.GetType().ToString()
                        });
            else
            {
                _dictionnary.Add(typeof(T), 
                    new List<Projection>()
                        {
                            new Projection()
                            {
                                Projects = (evt) => new ProjectOnlyOnceOnlyHandler<T>(_projectionRepositoryBuilder.Build(), finalhandler).Handle((T) evt),
                                ProjectionName = finalhandler.GetType().ToString()
                            }   
                        });
                if (_bus != null)
                {
                    string subscriptionId = string.Format("Super.{0}.Projections", _boundedContext);
                    _bus.Subscribe<T>(subscriptionId, (evt) => _execute((T)evt));
                }
            }
        }
    }
}