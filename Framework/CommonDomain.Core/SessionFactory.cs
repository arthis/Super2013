using System.Diagnostics.Contracts;
using CommonDomain.Persistence;

namespace CommonDomain.Core
{
    public class CommonSessionFactory : ISessionFactory<CommonSession>
    {
        private readonly ISessionRepository<CommonSession> _sessionRepository;

        public CommonSessionFactory(ISessionRepository<CommonSession> sessionRepository)
        {
            Contract.Requires(sessionRepository != null);

            _sessionRepository = sessionRepository;
        }

        public CommonSession CreateSession(ICommand cmd)
        {
            var session = _sessionRepository.GetSession(cmd.SecurityToken);
            return session;
        }
    }
}