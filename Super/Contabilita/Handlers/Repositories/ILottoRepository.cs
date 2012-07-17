using System;
using System.Collections.Generic;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Domain;

namespace Super.Contabilita.Handlers.Repositories
{
    public interface ILottoRepository
    {
        bool AreImpiantoAssociatedOutOfIntervall(Guid idLotto, Intervall intervall);
    }
    
}