using System;
using CommonDomain;
using Super.Programmazione.Commands.Intervento;

namespace Super.Programmazione.Commands.Builders
{
    public class DeleteInterventoBuilder : ICommandBuilder<DeleteIntervento>
    {
        
        public DeleteIntervento Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public DeleteIntervento Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new DeleteIntervento(id, idCommitId, version);

            return cmd;
        }

    }
}