namespace Super.Saga.Domain.Intervento
{
    public enum Trigger
    {
        Scheduled,
        Consuntivato,
        Closed
    }

    public enum State
    {
        Start,
        Programmation,
        Control,
        End
    }
}