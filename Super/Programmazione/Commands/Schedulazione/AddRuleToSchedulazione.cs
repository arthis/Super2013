using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core;

namespace Super.Programmazione.Commands.Schedulazione
{
    public class AddRuleToSchedulazione : CommandBase
    {
        public AddRuleToSchedulazione()
        {
            
        }

        public AddRuleToSchedulazione(Guid id, Guid idCommitId, long version)
            : base(id, idCommitId,version)
        {
            
        }

        public override string ToDescription()
        {
            return string.Format("Aggiungere una regola alla schedulazione {0} ", Id);
        }
    }
}
