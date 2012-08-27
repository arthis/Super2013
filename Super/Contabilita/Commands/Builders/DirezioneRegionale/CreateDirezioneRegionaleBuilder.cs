using System;
using CommonDomain;
using Super.Contabilita.Commands.DirezioneRegionale;

namespace Super.Contabilita.Commands.Builders.DirezioneRegionale
{
    public class CreateDirezioneRegionaleBuilder : ICommandBuilder<CreateDirezioneRegionale>
    {
        private string _description;

        public CreateDirezioneRegionale Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CreateDirezioneRegionale Build(Guid id, Guid commitId, long version)
        {
            var cmd =  new CreateDirezioneRegionale(id, commitId, version,   _description);

            return cmd;
        }

 
        public CreateDirezioneRegionaleBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }


    }
}
