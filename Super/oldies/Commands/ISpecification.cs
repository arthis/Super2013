using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commands
{
    public interface ISpecification<TEntity>
    {
        bool IsSatisfiedBy(TEntity entity, ValidationResult validationResult);
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

        public bool IsSatisfiedBy(TEntity candidate, ValidationResult validationResult)
        {
            return Spec1.IsSatisfiedBy(candidate, validationResult) && Spec2.IsSatisfiedBy(candidate, validationResult);
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

        public bool IsSatisfiedBy(TEntity candidate, ValidationResult validationResult)
        {
            return Spec1.IsSatisfiedBy(candidate, validationResult) || Spec2.IsSatisfiedBy(candidate, validationResult);
        }
    }

    internal class NotSpecification<TEntity> : ISpecification<TEntity>
    {
        private ISpecification<TEntity> Wrapped;

        internal NotSpecification(ISpecification<TEntity> x)
        {
            Wrapped = x;
        }

        public bool IsSatisfiedBy(TEntity candidate, ValidationResult validationResult)
        {
            return !Wrapped.IsSatisfiedBy(candidate, validationResult);
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

    public class ValidationResult
    {
        private List<string> _MessagiValidazione;

        public bool IsValid { get; set; }
        public List<string> MessagiValidazione 
        {
            get
            {
                if (_MessagiValidazione == null)
                    _MessagiValidazione = new List<string>();

                return _MessagiValidazione;
            }
        }
    }
}
