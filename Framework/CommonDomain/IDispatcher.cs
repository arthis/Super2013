using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EventStore;

namespace CommonDomain
{
    public interface IDispatcher
    {
        void DispatchCommit(Commit commit);
    }
}
