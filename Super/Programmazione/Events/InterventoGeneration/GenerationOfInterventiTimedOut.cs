using System;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Programmazione.Events.InterventoGeneration
{
    public class GenerationOfInterventiTimedOut : Message,IEvent
    {
        public GenerationOfInterventiTimedOut()
        {
            
        }

        public GenerationOfInterventiTimedOut(Guid id, Guid idCommitId, long version)
            : base(id, idCommitId,version)
        {
            
        }

        public override string ToDescription()
        {
            return string.Format("La generazione degli interventi della schedulazione  é andata in time out.");
        }
    }
}
