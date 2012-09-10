using System;
using CommonDomain.Core;

namespace Super.Programmazione.Commands.InterventoGeneration
{
    public class TimeOutTheGenerationOfInterventi : CommandBase
    {
        public TimeOutTheGenerationOfInterventi()
        {
            
        }

        public TimeOutTheGenerationOfInterventi(Guid id, Guid idCommitId, long version)
            : base(id, idCommitId,version)
        {
            
        }

        public override string ToDescription()
        {
            return string.Format("Indicare alla generazione degli intervento che un intervento é andato in timeout  ");
        }
    }

}
