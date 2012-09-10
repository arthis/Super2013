using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;

namespace Super.Programmazione.Commands.InterventoGeneration
{
    public class ConfirmInterventoGenerated : CommandBase
    {
        public Guid IdIntervento { get; set; }

        public ConfirmInterventoGenerated()
        {
            
        }

        public ConfirmInterventoGenerated(Guid id, Guid idCommitId, long version, Guid idIntervento)
            : base(id, idCommitId,version)
        {
            Contract.Requires(idIntervento!= Guid.Empty);

            IdIntervento = idIntervento;
        }

        public override string ToDescription()
        {
            return string.Format("Confirmare la generazione del'intervento {0} per la schedulazione {1} ", IdIntervento, Id);
        }
    }
}
