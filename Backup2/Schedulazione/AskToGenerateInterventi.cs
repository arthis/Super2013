using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core;

namespace Super.Programmazione.Commands.Schedulazione
{
    public class AskToGenerateInterventi : CommandBase
    {
        public AskToGenerateInterventi()
        {
            
        }

        public AskToGenerateInterventi(Guid id, Guid idCommitId, long version)
            : base(id, idCommitId,version)
        {
            
        }

        public override string ToDescription()
        {
            return string.Format("Chiede di generare interventi della schedulazione  {0} ", Id);
        }
    }
}
