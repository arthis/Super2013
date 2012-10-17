using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Super.Appaltatore.Events.Consuntivazione
{
    public interface IInterventoConsuntivato
    {
        Guid Id { get; }
    }

    public interface IInterventoRotConsuntivato : IInterventoConsuntivato
    {}
    public interface IInterventoRotManConsuntivato : IInterventoConsuntivato
    { }
    public interface IInterventoAmbConsuntivato : IInterventoConsuntivato
    { }
}
