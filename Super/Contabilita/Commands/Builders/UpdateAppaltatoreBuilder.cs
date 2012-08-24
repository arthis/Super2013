using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Commands.Appaltatore;

namespace Super.Contabilita.Commands.Builders
{
    public class UpdateAppaltatoreBuilder : ICommandBuilder<UpdateAppaltatore>
    {
        private string _description;

        public UpdateAppaltatore Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public UpdateAppaltatore Build(Guid id, Guid commitId, long version)
        {
            var cmd = new UpdateAppaltatore(id, commitId, version,  _description);
            
            return cmd;
        }



        public UpdateAppaltatoreBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        
    }
}