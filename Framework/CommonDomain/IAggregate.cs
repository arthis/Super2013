namespace CommonDomain
{
	using System;
	using System.Collections;
    using System.Collections.Generic;

	public interface IAggregate
	{
		Guid Id { get; }
		int Version { get; }

		void ApplyEvent(object @event);
        ICollection<IEvent> GetUncommittedEvents();
		void ClearUncommittedEvents();

		IMemento GetSnapshot();
	}
}