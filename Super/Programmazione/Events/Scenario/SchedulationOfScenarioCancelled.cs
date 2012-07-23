using System;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Programmazione.Events.Scenario
{
    public class SchedulationOfScenarioCancelled : Message , IEvent
    {
        
        public SchedulationOfScenarioCancelled()
        {

        }

        public SchedulationOfScenarioCancelled(Guid id, Guid commitId, long version)
            : base(id, commitId, version)
        {

        }

        public override string ToDescription()
        {
            return string.Format("Schedulazione {0} dal scenario é stata cancellata", Id);
        }


    }
}