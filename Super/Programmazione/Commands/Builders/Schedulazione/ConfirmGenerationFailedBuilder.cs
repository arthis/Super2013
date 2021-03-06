using System;
using CommonDomain;
using Super.Programmazione.Commands.Schedulazione;

namespace Super.Programmazione.Commands.Builders.Schedulazione
{
    public class ConfirmGenerationFailedBuilder: IEventBuilder<ConfirmGenerationFailed>
    {

        public ConfirmGenerationFailed Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public ConfirmGenerationFailed Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new ConfirmGenerationFailed(id, idCommitId, version);

            return cmd;
        }



    }
}