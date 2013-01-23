using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonDomain.Super
{
    public interface IContextCommand
    {
        Guid IdCommittente { get; }
        Guid IdLotto { get; }
        Guid IdTipoIntervento { get; }
    }
}
