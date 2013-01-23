using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Actions;

namespace CommonSpecs
{

    public class FakeAction :IAction
    {
        public bool CanBeExecuted()
        {
            return true;
        }
    }
    public class FakeActionFactory :IActionFactory
    {
        private readonly Guid _userId;

        public FakeActionFactory(Guid userId)
        {
            _userId = userId;
        }

        public IActionFactory WithCommands(IEnumerable<Regex> commands)
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

        public IAction CreateAction<T>(T cmd) where  T:ICommand
        {
            return new FakeAction();
        }

        public void AddFullyConstrainedActionHandlerFor<T>() where T : ICommand
        {
            throw new NotImplementedException();
        }

        public void AddCommandTypeConstrainedActionHandlerFor<T>() where T : ICommand
        {
            throw new NotImplementedException();
        }
    }

    
}
