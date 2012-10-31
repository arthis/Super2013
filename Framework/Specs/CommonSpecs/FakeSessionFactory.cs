using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Actions;

namespace CommonSpecs
{
    public class FakeActionFactory :IActionFactory
    {
        private readonly Guid _userId;

        public FakeActionFactory(Guid userId)
        {
            _userId = userId;
        }

        public IActionFactory WithCommands(IEnumerable<Type> commands)
        {
            throw new NotImplementedException();
        }

        public IActionFactory WithCommittenti(IEnumerable<Guid> committenti)
        {
            throw new NotImplementedException();
        }

        public IActionFactory WithLotti(IEnumerable<Guid> lotti)
        {
            throw new NotImplementedException();
        }

        public IActionFactory WithTipiIntervento(IEnumerable<Guid> tipiIntervento)
        {
            throw new NotImplementedException();
        }

        public IAction CreateAction(ICommand cmd)
        {
            return new ActionFullyConstrained(null,null,null,null,null);
        }

        public void AddFullyConstrainedAction<T>(T cmd) where T : ICommand
        {
            throw new NotImplementedException();
        }

        public void AddCommandConstrainedOnlyAction<T>(T cmd) where T : ICommand
        {
            throw new NotImplementedException();
        }
    }

    
}
