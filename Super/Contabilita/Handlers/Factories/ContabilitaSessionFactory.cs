using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using Super.Contabilita.Domain;

namespace Super.Contabilita.Handlers.Factories
{
    public class ContabilitaSessionFactory : ISessionFactory<SessionContabilita>
    {
        private readonly ISessionFactory<CommonSession> _sessionFactory;
        private readonly IEventRepository _eventRepository;
        private Domain.Pricing.Pricing _pricing;
        private Guid  _guidPricing = new Guid("91a2f71c-def9-4bf6-b42f-394e8f003c41"); 

        public ContabilitaSessionFactory(ISessionFactory<CommonSession> sessionFactory, IEventRepository eventRepository)
        {
            Contract.Requires(sessionFactory != null);
            Contract.Requires(eventRepository != null);

            _sessionFactory = sessionFactory;
            _eventRepository = eventRepository;
        }


        public SessionContabilita CreateSession(ICommand cmd)
        {
            //regenerate the pricing if need be
            if (_pricing == null)
                _pricing = _eventRepository.GetById<Domain.Pricing.Pricing>(_guidPricing);

            var session = new SessionContabilita(_sessionFactory.CreateSession(cmd), _pricing);
            
            return session;
        }
    }
}
