using System;
using System.Collections.Generic;

namespace CommonDomain
{
    public interface IActionFactory
    {

        IActionFactory WithCommands(IEnumerable<Type> commands);
        IActionFactory WithCommittenti(IEnumerable<Guid> committenti);
        IActionFactory WithLotti(IEnumerable<Guid> lotti);
        IActionFactory WithTipiIntervento(IEnumerable<Guid> tipiIntervento);

        IAction CreateAction(ICommand cmd);

        void AddFullyConstrainedAction<T>(T cmd) where T : ICommand;
        void AddCommandConstrainedOnlyAction<T>(T cmd) where T : ICommand;
    }
}