using System;
using CommonDomain;

namespace Super.Programmazione.Events
{
    public interface IInterventoPianificato : IMessage
    {
        Guid Id { get; set; }
    }
}