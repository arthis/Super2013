using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public interface ISpecification<TEntity>
    {
        bool IsSatisfiedBy(TEntity entity, List<string> messagiValidazione);
    }


    internal class AndSpecification<TEntity> : ISpecification<TEntity>
    {
        private ISpecification<TEntity> Spec1;
        private ISpecification<TEntity> Spec2;

        internal AndSpecification(ISpecification<TEntity> s1, ISpecification<TEntity> s2)
        {
            Spec1 = s1;
            Spec2 = s2;
        }

        public bool IsSatisfiedBy(TEntity candidate, List<string> messagiValidazione)
        {
            return Spec1.IsSatisfiedBy(candidate, messagiValidazione) && Spec2.IsSatisfiedBy(candidate, messagiValidazione);
        }
    }

    internal class OrSpecification<TEntity> : ISpecification<TEntity>
    {
        private ISpecification<TEntity> Spec1;
        private ISpecification<TEntity> Spec2;

        internal OrSpecification(ISpecification<TEntity> s1, ISpecification<TEntity> s2)
        {
            Spec1 = s1;
            Spec2 = s2;
        }

        public bool IsSatisfiedBy(TEntity candidate, List<string> messagiValidazione)
        {
            return Spec1.IsSatisfiedBy(candidate, messagiValidazione) || Spec2.IsSatisfiedBy(candidate, messagiValidazione);
        }
    }

    internal class NotSpecification<TEntity> : ISpecification<TEntity>
    {
        private ISpecification<TEntity> Wrapped;

        internal NotSpecification(ISpecification<TEntity> x)
        {
            Wrapped = x;
        }

        public bool IsSatisfiedBy(TEntity candidate, List<string> messagiValidazione)
        {
            return !Wrapped.IsSatisfiedBy(candidate, messagiValidazione);
        }
    }

    public static class ExtensionMethods
    {
        public static ISpecification<TEntity> And<TEntity>(this ISpecification<TEntity> s1, ISpecification<TEntity> s2)
        {
            return new AndSpecification<TEntity>(s1, s2);
        }

        public static ISpecification<TEntity> Or<TEntity>(this ISpecification<TEntity> s1, ISpecification<TEntity> s2)
        {
            return new OrSpecification<TEntity>(s1, s2);
        }

        public static ISpecification<TEntity> Not<TEntity>(this ISpecification<TEntity> s)
        {
            return new NotSpecification<TEntity>(s);
        }
    }
}
