using System;
using Ncqrs.Eventing;
using NServiceBus;

namespace Ncqrs.NServiceBus
{
    /// <summary>
    /// Wraps Ncqrs event to be transportable by NServiceBus.
    /// </summary>
    /// <typeparam name="T">Type of transported event.</typeparam>
    [Serializable]
    public class EventMessage : IMessage 
    {
        /// <summary>
        /// Gets or sets transported event.
        /// </summary>
        public object Payload { get; set; }
    }
}