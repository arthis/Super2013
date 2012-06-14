using System;
using CommonDomain;

namespace Super.Appaltatore.Events.Consuntivazione
{
    public interface IInterventoConsuntivato :IMessage
    {
        Guid Id { get; set; }
    }
    public interface IInterventoRotConsuntivato : IInterventoConsuntivato
    {
    }
    public interface IInterventoRotManConsuntivato : IInterventoConsuntivato
    {
    }
    public interface IInterventoAmbConsuntivato : IInterventoConsuntivato
    {
    }
}