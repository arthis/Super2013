using System;
using CommonDomain.Core;

namespace Super.Programmazione.Commands.InterventoGenerator
{
    public class GenerateInterventi : CommandBase
    {
        public Guid IdSchedulazione { get; set; }


        public GenerateInterventi()
        {
            
        }

        public GenerateInterventi(Guid id, Guid idCommitId, long version, Guid idSchedulazione)
            : base(id, idCommitId,version)
        {
            IdSchedulazione = idSchedulazione;
        }

        public override string ToDescription()
        {
            return string.Format("Generare interventi di una schedulazione  {0} ", Id);
        }
    }
}
