using System.Diagnostics.Contracts;
using CommonDomain.Persistence;

namespace CommonDomain.Core
{
    public class SessionFactory :ISessionFactory
    {
        private readonly ISessionRepository _sessionRepository;

        public SessionFactory(ISessionRepository sessionRepository)
        {
            Contract.Requires(sessionRepository != null);

            _sessionRepository = sessionRepository;
        }

        public ISession CreateSession(ICommand cmd)
        {
            var session = _sessionRepository.GetSession(cmd.SecurityToken);
            return session;
        }
    }
}