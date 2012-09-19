using CommonDomain;

namespace Super.Appaltatore.Events.Consuntivazione
{
    public interface IInterventoConsuntivato : IEvent
    {
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