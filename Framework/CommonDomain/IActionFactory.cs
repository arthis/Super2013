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

        IAction CreateAction<T>(T cmd) where T:ICommand;

        
    }
}