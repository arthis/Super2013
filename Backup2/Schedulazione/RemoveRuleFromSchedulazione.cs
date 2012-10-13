using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core;

namespace Super.Programmazione.Commands.Schedulazione
{
    public class RemoveRuleFromSchedulazione : CommandBase
    {
        public RemoveRuleFromSchedulazione()
        {
            
        }

        public RemoveRuleFromSchedulazione(Guid id, Guid idCommitId, long version)
            : base(id, idCommitId,version)
        {
            
        }

        public override string ToDescription()
        {
            return string.Format("Rimuovere una regola della schedulazione {0} ", Id);
        }
    }
}
