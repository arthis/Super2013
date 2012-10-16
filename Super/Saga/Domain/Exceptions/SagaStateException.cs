using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Super.Saga.Domain.Exceptions
{
    public class SagaStateException : Exception
    {
        public SagaStateException() : base()
        {
            
        }

        public SagaStateException(string msg)
            : base(msg)
        {

        }
    }
}
