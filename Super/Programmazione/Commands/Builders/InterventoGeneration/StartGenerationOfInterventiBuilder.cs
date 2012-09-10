using System;
using CommonDomain;
using Super.Programmazione.Commands.InterventoGeneration;

namespace Super.Programmazione.Commands.Builders.InterventoGeneration
{
    public class StartGenerationOfInterventiBuilder : ICommandBuilder<StartGenerationOfInterventi>
    {
        private Guid _idSchedulazione;

        public StartGenerationOfInterventiBuilder ForSchedulazione(Guid idSchedulazione)
        {
            _idSchedulazione = idSchedulazione;
            return this;
        }


        public StartGenerationOfInterventi Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public StartGenerationOfInterventi Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new StartGenerationOfInterventi(id, idCommitId, version, _idSchedulazione);

            return cmd;
        }

    }
}