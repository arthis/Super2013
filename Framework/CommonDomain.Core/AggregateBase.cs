using System.ComponentModel;

namespace CommonDomain.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public abstract class AggregateBase : IAggregate, IEquatable<IAggregate>
    {
        private readonly ICollection<IMessage> uncommittedEvents = new LinkedList<IMessage>();
        public readonly CommandValidation CommandValidationMessages;

        private IRouteEvents registeredRoutes;

        protected AggregateBase()
            : this(null)
        {
        }

        protected AggregateBase(IRouteEvents handler)
        {
            CommandValidationMessages = new CommandValidation();

            if (handler == null) return;

            this.RegisteredRoutes = handler;
            this.RegisteredRoutes.Register(this);
        }

        public Guid Id { get; protected set; }
        public int Version { get; protected set; }

        protected IRouteEvents RegisteredRoutes
        {
            get
            {
                return registeredRoutes ?? (registeredRoutes = new ConventionEventRouter(true, this));
            }
            set
            {
                if (value == null)
                    throw new InvalidOperationException("AggregateBase must have an event router to function");

                registeredRoutes = value;
            }
        }

        protected void Register<T>(Action<T> route)
        {
            this.RegisteredRoutes.Register(route);
        }

        protected void RaiseEvent(IMessage @event)
        {
            ((IAggregate)this).ApplyEvent(@event);
            this.uncommittedEvents.Add(@event);
        }
        void IAggregate.ApplyEvent(object @event)
        {
            this.RegisteredRoutes.Dispatch(@event);
            this.Version++;
        }
        ICollection<IMessage> IAggregate.GetUncommittedEvents()
        {
            return this.uncommittedEvents;
        }
        void IAggregate.ClearUncommittedEvents()
        {
            this.uncommittedEvents.Clear();
        }

        IMemento IAggregate.GetSnapshot()
        {
            var snapshot = this.GetSnapshot();
            snapshot.Id = this.Id;
            snapshot.Version = this.Version;
            return snapshot;
        }
        protected virtual IMemento GetSnapshot()
        {
            return null;
        }

        public bool IsNull()
        {
            return Id == Guid.Empty;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return this.Equals(obj as IAggregate);
        }
        public virtual bool Equals(IAggregate other)
        {
            return null != other && other.Id == this.Id;
        }
    }
}