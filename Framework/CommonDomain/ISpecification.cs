using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonDomain
{
    public interface ISpecification<TEntity> where TEntity : class, IAggregate
    {
        bool IsSatisfiedBy(TEntity entity);
    }
}
