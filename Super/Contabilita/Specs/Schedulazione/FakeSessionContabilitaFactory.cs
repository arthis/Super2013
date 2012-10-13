using System;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using Super.Contabilita.Domain;

namespace Super.Contabilita.Specs.Schedulazione
{
    public class FakeSessionContabilitaFactory : ISessionFactory<ISessionContabilita>
    {
        private readonly Guid _userId;
        private readonly Guid _pricingId;
        private readonly IEventRepository _eventRepository;

        /// <summary>
        /// event repository is udes to regenerate the pricing as it must be some kind of global stuff
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="eventRepository"></param>
        public FakeSessionContabilitaFactory(Guid userId, Guid pricingId, IEventRepository eventRepository )
        {
            _userId = userId;
            _pricingId = pricingId;

            _eventRepository = eventRepository;
        }

        public ISessionContabilita CreateSession(ICommand cmd)
        {
            ISession session = new CommonSession(_userId,true);
            var pricing = _eventRepository.GetById<Domain.Pricing.Pricing>(_pricingId);
            return new SessionContabilita(session, pricing);
        }

        public Guid UserId { get { return _userId; } }
        public bool IsAuthenticated { get { return true; } }
    }

    
}