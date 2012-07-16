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
        public bool AreImpiantoAssociatedWihtinIntervall(Guid idLotto, Intervall intervall)
        {
            using (var container = Container.GetContainer())
            {
                return container.Impiantoes.Where(x => x.IdLotto == idLotto)
                    .Any(x => x.Start >= intervall.Start
                              && (
                                     !intervall.End.HasValue
                                     || intervall.End.HasValue && x.End.HasValue && intervall.End.Value > x.End.Value
                                 )
                         );

            }
        }

        
    }

    
}
