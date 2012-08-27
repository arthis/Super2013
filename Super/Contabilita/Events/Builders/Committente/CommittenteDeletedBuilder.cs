using System;
using CommonDomain;
using Super.Contabilita.Events.Committente;

namespace Super.Contabilita.Events.Builders.Committente
{
    public class CommittenteDeletedBuilder : IEventBuilder<CommittenteDeleted>
    {

        public CommittenteDeleted Build(Guid id, long version)
        {
            var evt = new CommittenteDeleted(id, Guid.NewGuid() ,version);
            
            return evt;
        }

    }


}