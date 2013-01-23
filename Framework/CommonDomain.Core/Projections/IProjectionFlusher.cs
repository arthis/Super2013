using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonDomain.Core.Projections
{
    public interface IProjectionFlusher
    {
        void Flush(IEnumerable<IProjectionAction> projectionActions);
    }

    public class SqlProjectionFlusher : IProjectionFlusher
    {
        public void Flush(IEnumerable<IProjectionAction> projectionActions)
        {
            throw new NotImplementedException();
        }
    }
}
