using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain;
using CommonDomain.Core;

namespace CommonSpecs
{
    public class FakeSessionFactory :ISessionFactory
    {
        private readonly Guid _userId;

        public FakeSessionFactory(Guid userId)
        {
            _userId = userId;
        }

        public ISession CreateSession(ICommand cmd)
        {
            return new Session(_userId,true);
        }
    }
}
