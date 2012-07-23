using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Programmazione.Events.Schedulazione
{
    public class InterventiGenerated : Message,IEvent
    {
        public InterventiGenerated()
        {
            
        }

        public InterventiGenerated(Guid id, Guid idCommitId, long version)
            : base(id, idCommitId,version)
        {
            
        }

        public override string ToDescription()
        {
            return string.Format("Interventi sono stati generati della schedulazione {0}  ", Id);
        }
    }
}
