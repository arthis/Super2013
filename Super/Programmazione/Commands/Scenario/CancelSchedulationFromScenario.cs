using System;
using CommonDomain.Core;

namespace Super.Programmazione.Commands.Scenario
{
    public class CancelSchedulationFromScenario : CommandBase
    {
        
        public CancelSchedulationFromScenario()
        {

        }

        public CancelSchedulationFromScenario(Guid id, Guid commitId, long version)
            : base(id, commitId, version)
        {

        }

        public override string ToDescription()
        {
            return string.Format("Cancellare schedulazione {0} dal scenario ", Id);
        }


    }
}