using System;
using CommonDomain;
using Super.Contabilita.Events.Lotto;

namespace Super.Contabilita.Events.Builders
{
    public class LottoDeletedBuilder : IEventBuilder<LottoDeleted>
    {

        public LottoDeleted Build(Guid id)
        {
            var evt = new LottoDeleted(id);
            evt.CommitId= Guid.NewGuid();
            return evt;
        }

    }
}