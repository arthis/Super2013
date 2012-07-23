using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Domain;

namespace Super.Contabilita.Handlers.Repositories
{
    public class SqlLottoRepository : ILottoRepository
    {
        public bool AreImpiantoAssociatedOutOfInterval(Guid idLotto, Interval interval)
        {
            using (var container = Container.GetContainer())
            {
                return container.Impiantoes.Where(x => x.IdLotto == idLotto)
                    .Any(x => x.Start < interval.Start
                              || (interval.End.HasValue && x.End.HasValue && interval.End.Value < x.End.Value)
                              || (interval.End.HasValue && !x.End.HasValue)
                    );
            }
        }

        
    }

    
}
