using System;
using Cqrs.Eventing.Storage;

namespace Cqrs.Eventing.Sourcing
{
    public class UndefinedValues
    {
        public static Guid UndefinedEventSourceId = Guid.Empty;
        public const int UndefinedEventSequence = -1;
    }
}
