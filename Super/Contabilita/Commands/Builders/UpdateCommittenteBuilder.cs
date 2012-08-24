using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Commands.Committente;

namespace Super.Contabilita.Commands.Builders
{
    public class UpdateCommittenteBuilder : ICommandBuilder<UpdateCommittente>
    {
        private string _description;
        private string _sign;

        public UpdateCommittente Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public UpdateCommittente Build(Guid id, Guid commitId, long version)
        {
            var cmd = new UpdateCommittente(id, commitId, version,  _description, _sign);
            
            return cmd;
        }



        public UpdateCommittenteBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public UpdateCommittenteBuilder ForSign(string sign)
        {
            _sign = sign;
            return this;
        }

        
    }
}