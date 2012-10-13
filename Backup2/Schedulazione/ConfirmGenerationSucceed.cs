using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Programmazione.Commands.Schedulazione
{
    public class ConfirmGenerationSucceed : Message, IEvent
    {
        public ConfirmGenerationSucceed()
        {
            
        }

        public ConfirmGenerationSucceed(Guid id, Guid idCommitId, long version)
            : base(id, idCommitId,version)
        {
            
        }

        public override string ToDescription()
        {
            return string.Format("Conferma che i interventi sono stati generati correttamente interventi per la schedulazione {0} ", Id);
        }
    }
}
