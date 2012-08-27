using System;
using CommonDomain;
using Super.Contabilita.Commands.DirezioneRegionale;

namespace Super.Contabilita.Commands.Builders.DirezioneRegionale
{
    public class UpdateDirezioneRegionaleBuilder : ICommandBuilder<UpdateDirezioneRegionale>
    {
        private string _description;

        public UpdateDirezioneRegionale Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public UpdateDirezioneRegionale Build(Guid id, Guid commitId, long version)
        {
            var cmd = new UpdateDirezioneRegionale(id, commitId, version,  _description);
            
            return cmd;
        }



        public UpdateDirezioneRegionaleBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        
    }
}