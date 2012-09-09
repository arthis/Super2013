using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Programmazione.Commands.Schedulazione
{
    public class ConfirmGenerationFailed : Message, IEvent
    {
        public ConfirmGenerationFailed()
        {
            
        }

        public ConfirmGenerationFailed(Guid id, Guid idCommitId, long version)
            : base(id, idCommitId,version)
        {
            
        }

        public override string ToDescription()
        {
            return string.Format("Conferma che i interventi non sono stati generati corretamente per la schedulazione {0} ", Id);
        }
    }
}
