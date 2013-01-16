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

        void AddFullyConstrainedActionHandlerFor<T>() where T : ICommand;
        void AddCommandTypeConstrainedActionHandlerFor<T>() where T : ICommand;
    }
}