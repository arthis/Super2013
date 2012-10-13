using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Programmazione.Events.Schedulazione
{
    public class RuleRemovedFromSchedulazione : Message,IEvent
    {
        public RuleRemovedFromSchedulazione()
        {
            
        }

        public RuleRemovedFromSchedulazione(Guid id, Guid idCommitId, long version)
            : base(id, idCommitId,version)
        {
            
        }

        public override string ToDescription()
        {
            return string.Format("Regola {0} è stata rimossa della schedulazione ", Id);
        }
    }
}
