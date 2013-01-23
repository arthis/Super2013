using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text.RegularExpressions;

namespace CommonDomain.Core.Handlers.Actions
{
    
    public class ActionCommandConstrainedOnly<T> : IAction  where T :ICommand
    {

        public IEnumerable<Regex> CommandsAvailableToTheUser { get; set; } 

        public ActionCommandConstrainedOnly()
        {
        }
        
        public bool CanBeExecuted()
        {
            Contract.Requires<ArgumentNullException>(CommandsAvailableToTheUser != null);

            return CommandsAvailableToTheUser.Any(x => x.IsMatch(typeof(T).ToString()));
        }


    }
}