using System;
using CommonDomain.Core;

namespace Super.Programmazione.Commands.Schedulazione
{
    public class CancelSchedulazioneFromScenario : CommandBase
    {
        
        public CancelSchedulazioneFromScenario()
        {

        }

        public CancelSchedulazioneFromScenario(Guid id, Guid commitId, long version)
            : base(id, commitId, version)
        {

        }

        public override string ToDescription()
        {
            return string.Format("Cancellare schedulazione {0} dal scenario ", Id);
        }


    }
}