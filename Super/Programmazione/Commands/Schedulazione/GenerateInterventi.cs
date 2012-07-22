using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core;

namespace Super.Programmazione.Commands.Schedulazione
{
    public class GenerateInterventi : CommandBase
    {
        public GenerateInterventi()
        {
            
        }

        public GenerateInterventi(Guid id, Guid idCommitId, long version)
            : base(id, idCommitId,version)
        {
            
        }

        public override string ToDescription()
        {
            return string.Format("Generare interventi della schedulazione alla schedulazione {0} ", Id);
        }
    }
}
