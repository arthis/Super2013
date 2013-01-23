using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace CommonDomain.Core.Projections
{
    public interface IProjectionnist
    {
        void MoveNext(IProjectionAction projection);
        void Flush();
    }

    public class ThresholdProjectionner : IProjectionnist
    {
        private readonly IProjectionFlusher _projectionFlusher;
        private readonly int _threshold;

        public ThresholdProjectionner(IProjectionFlusher projectionFlusher, int threshold)
        {
            Contract.Requires<ArgumentNullException>(projectionFlusher!=null);
            Contract.Requires<ArgumentException>(threshold>0);

            _projectionFlusher = projectionFlusher;
            _threshold = threshold;
        }

        public void MoveNext(IProjectionAction projection)
        {
            throw new NotImplementedException();
        }

        public void Flush()
        {
            throw new NotImplementedException();
        }
    }
}
