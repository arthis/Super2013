using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CommonDomain
{
    public interface IActionFactory
    {

        IActionFactory WithCommands(IEnumerable<Regex> commands);
        IActionFactory WithCommittenti(IEnumerable<Guid> committenti);
        IActionFactory WithLotti(IEnumerable<Guid> lotti);
        IActionFactory WithTipiIntervento(IEnumerable<Guid> tipiIntervento);

        IAction CreateAction(ICommand cmd);

        void AddFullyConstrainedAction<T>() where T : ICommand;
        void AddCommandConstrainedOnlyAction<T>() where T : ICommand;
    }
}