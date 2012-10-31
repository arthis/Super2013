using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Contabilita.Domain
{
    public class ActionContabilita : IActionContabilita
    {
        private readonly IAction _action;
        private readonly Pricing.Pricing _pricing;


        public ActionContabilita(IAction action  , Pricing.Pricing pricing)
        {
            Contract.Requires(pricing != null);
            Contract.Requires(action != null);

            _action = action;
            _pricing = pricing;
            
        }



        public Pricing.Pricing Pricing { get { return _pricing; } }
        public bool CanBeExecuted()
        {
            throw new NotImplementedException();
        }
    }
}
