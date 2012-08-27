using System;
using CommonDomain;
using Super.Contabilita.Events.Committente;

namespace Super.Contabilita.Events.Builders.Committente
{
    public class CommittenteUpdatedBuilder : IEventBuilder<CommittenteUpdated>
    {
        private string _description;
        private string _sign;

        public CommittenteUpdated Build(Guid id, long version)
        {
            var evt = new CommittenteUpdated(id, Guid.NewGuid() ,version,  _description,_sign);
            
            return evt;
        }

        public CommittenteUpdatedBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public CommittenteUpdatedBuilder ForSign(string sign)
        {
            _sign = sign;
            return this;
        }

    }


}