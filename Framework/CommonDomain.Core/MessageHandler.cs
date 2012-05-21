using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using CommonDomain.Persistence;
using EasyNetQ;

namespace CommonDomain.Core
{
    public class SagaHandler
    {
        protected ISagaRepository Repository;
        protected IBus Bus;


        public SagaHandler(ISagaRepository repository, IBus bus)
        {
            Contract.Requires<ArgumentNullException>(repository != null);
            Contract.Requires<ArgumentNullException>(bus != null);

            Repository = repository;
            Bus = bus;
        }
    }

}
