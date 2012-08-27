using System;
using CommonDomain;
using Super.Contabilita.Commands.DirezioneRegionale;

namespace Super.Contabilita.Commands.Builders.DirezioneRegionale
{
    public class DeleteDirezioneRegionaleBuilder : ICommandBuilder<DeleteDirezioneRegionale>
    {

        public DeleteDirezioneRegionale Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public DeleteDirezioneRegionale Build(Guid id, Guid commitId, long version)
        {
            var cmd = new DeleteDirezioneRegionale(id,commitId,version);

            return cmd;
        }


    }
}