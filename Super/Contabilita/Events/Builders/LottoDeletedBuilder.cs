using System;
using CommonDomain;
using Super.Contabilita.Events.Lotto;

namespace Super.Contabilita.Events.Builders
{
    public class LottoDeletedBuilder : IEventBuilder<LottoDeleted>
    {

        public LottoDeleted Build(Guid id)
        {
            return new LottoDeleted(id);
        }

    }
}