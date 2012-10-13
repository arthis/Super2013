namespace CommonDomain
{
    public interface ISessionFactory<TSession> where TSession:ISession
    {
        TSession CreateSession(ICommand cmd);
    }
}