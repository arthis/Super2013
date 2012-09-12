namespace CommonDomain
{
    public interface ISessionFactory
    {
        ISession CreateSession(ICommand cmd);
    }
}