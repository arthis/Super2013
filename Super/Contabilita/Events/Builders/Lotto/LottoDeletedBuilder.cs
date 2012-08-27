using System;
using CommonDomain;
using Super.Contabilita.Events.Lotto;

namespace Super.Contabilita.Events.Builders.Lotto
{
    public class LottoDeletedBuilder : IEventBuilder<LottoDeleted>
    {

        public LottoDeleted Build(Guid id, long version)
        {
            var evt = new LottoDeleted(id, Guid.NewGuid() ,version);
            
            return evt;
        }

    }
}