namespace Super.Saga.Domain.Intervento
{
    enum Trigger
    {
        Scheduled,
        Consuntivato,
        Closed
    }

    enum State
    {
        Start,
        Programmation,
        Control,
        End
    }
}