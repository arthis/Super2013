using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using CommonDomain.Persistence;

namespace CommonDomain.Core
{
    public class SagaHandler
    {
        protected ISagaRepository Repository;


        public SagaHandler(ISagaRepository repository)
        {
            Contract.Requires<ArgumentNullException>(repository != null);

            Repository = repository;
        }
    }

}
