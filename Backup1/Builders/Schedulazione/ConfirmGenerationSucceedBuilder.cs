using System;
using CommonDomain;
using Super.Programmazione.Commands.Schedulazione;

namespace Super.Programmazione.Commands.Builders.Schedulazione
{
    public class ConfirmGenerationSucceedBuilder: IEventBuilder<ConfirmGenerationSucceed>
    {

        public ConfirmGenerationSucceed Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public ConfirmGenerationSucceed Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new ConfirmGenerationSucceed(id, idCommitId, version);

            return cmd;
        }



    }
}