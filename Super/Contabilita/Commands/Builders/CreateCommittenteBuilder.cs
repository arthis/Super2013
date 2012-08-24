using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Commands.Committente;


namespace Super.Contabilita.Commands.Builders
{
    public class CreateCommittenteBuilder : ICommandBuilder<CreateCommittente>
    {
        private string _description;
        private string _sign;

        public CreateCommittente Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CreateCommittente Build(Guid id, Guid commitId, long version)
        {
            var cmd =  new CreateCommittente(id, commitId, version,   _description, _sign);

            return cmd;
        }

 
        public CreateCommittenteBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public CreateCommittenteBuilder ForSign(string sign)
        {
            _sign = sign;
            return this;
        }


    }
}
