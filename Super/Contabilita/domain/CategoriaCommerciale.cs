using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using Super.Contabilita.Events;
using Super.Contabilita.Events.CategoriaCommerciale;
using Super.Contabilita.Events.Builders;

namespace Super.Contabilita.Domain
{
    public class CategoriaCommerciale : AggregateBase
    {
        private class Is_CategoriaCommerciale_Already_Deleted : ISpecification<CategoriaCommerciale>
        {
            public bool IsSatisfiedBy(CategoriaCommerciale i)
            {
                if (i._deleted)
                {
                    i.CommandValidationMessages.Add(new ValidationMessage("Categoria Commerciale", "categoria commerciale gia cancellata"));
                    return false;
                }

                return true;
            }
        }

        private bool _deleted;
        

        public CategoriaCommerciale()
        {
        }

        public CategoriaCommerciale(Guid id,  string description)
        {
            var evt = BuildEvt.CategoriaCommercialeCreated
                .ForDescription(description);
            RaiseEvent(id, evt);

        }

        public void Apply(CategoriaCommercialeCreated e)
        {
            Id = e.Id;
        }

        public void Update( string description)
        {
            var evt = BuildEvt.CategoriaCommercialeUpdated
                          .ForDescription(description);
            RaiseEvent(evt);
        }

        public void Apply(CategoriaCommercialeUpdated e)
        {

        }

        public void Delete()
        {
            var isAlreadyDeleted = new Is_CategoriaCommerciale_Already_Deleted();

            ISpecification<CategoriaCommerciale> specs = isAlreadyDeleted;

            if (specs.IsSatisfiedBy(this))
            {
                var evt = BuildEvt.CategoriaCommercialeDeleted;

                RaiseEvent(evt);
            }
        }

        public void Apply(CategoriaCommercialeDeleted e)
        {
            this._deleted = true;
        }




    }
}
