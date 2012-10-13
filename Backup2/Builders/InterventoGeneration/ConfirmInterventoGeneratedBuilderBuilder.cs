using System;
using CommonDomain;
using Super.Programmazione.Commands.InterventoGeneration;

namespace Super.Programmazione.Commands.Builders.InterventoGeneration
{
    public class ConfirmInterventoGeneratedBuilder : ICommandBuilder<ConfirmInterventoGenerated>
    {
        private Guid _idIntervento;

        public ConfirmInterventoGeneratedBuilder ForIntervento(Guid idIntervento)
        {
            _idIntervento = idIntervento;
            return this;
        }


        public ConfirmInterventoGenerated Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public ConfirmInterventoGenerated Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new ConfirmInterventoGenerated(id, idCommitId, version, _idIntervento);

            return cmd;
        }

    }
}