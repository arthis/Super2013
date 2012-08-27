using System;
using CommonDomain;
using Super.Contabilita.Events.Committente;

namespace Super.Contabilita.Events.Builders.Committente
{
    public class CommittenteCreatedBuilder : IEventBuilder<CommittenteCreated>
    {
        private string _description;
        private string _sign;


        public CommittenteCreated Build(Guid id, long version)
        {
            var evt = new CommittenteCreated(id, Guid.NewGuid() ,version,    _description, _sign);
            
            return evt;
        }


        public CommittenteCreatedBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public CommittenteCreatedBuilder ForSign(string sign)
        {
            _sign = sign;
            return this;
        }

    }

}