using System.Collections.Generic;

namespace Cqrs.Eventing.Sourcing.Mapping
{
    public interface IEventHandlerMappingStrategy
    {
        IEnumerable<ISourcedEventHandler> GetEventHandlers(object target);
    }
}