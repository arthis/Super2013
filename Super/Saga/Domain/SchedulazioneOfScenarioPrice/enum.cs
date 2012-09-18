namespace Super.Saga.Domain.SchedulazioneOfScenarioPrice
{
    enum Trigger
    {
        SchedulazionAdded,
        SchedulazioneCalculated
    }

    enum State
    {
        Start,
        Calculating,
        End
    }
}