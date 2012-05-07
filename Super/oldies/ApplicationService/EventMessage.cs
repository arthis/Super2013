using System;
using Cqrs.Eventing;
using NServiceBus;

namespace ApplicationService
{
    ///// <summary>
    ///// Wraps Cqrs event to be transportable by NServiceBus.
    ///// </summary>
    ///// <typeparam name="T">Type of transported event.</typeparam>
    //[Serializable]
    //public class EventMessage : IMessage 
    //{
    //    /// <summary>
    //    /// Gets or sets transported event.
    //    /// </summary>
    //    public object Payload { get; set; }
    //}
}