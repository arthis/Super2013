using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using Super.Contabilita.Events.Committente;
using Super.Contabilita.Events.Builders;
using BuildVO = CommonDomain.Core.Super.Domain.Builders.Build;

namespace Super.Contabilita.Domain
{
    public class Committente : AggregateBase
    {
        private class Is_Committente_Already_Deleted : ISpecification<Committente>
        {
            public bool IsSatisfiedBy(Committente i)
            {
                if (i._deleted)
                {
                    i.CommandValidationMessages.Add(new ValidationMessage("Committente", "appaltatore gia cancellata"));
                    return false;
                }

                return true;
            }
        }

        private bool _deleted;
        

        public Committente()
        {
        }

        public Committente(Guid id,  string description,string sign)
        {
            var evt = Build.CommittenteCreated
                .ForDescription(description)
                .ForSign(sign);
                
            RaiseEvent(id, evt);

        }

        public void Apply(CommittenteCreated e)
        {
            Id = e.Id;
        }

        public void Update( string description, string sign)
        {
            var evt = Build.CommittenteUpdated
                          .ForDescription(description)
                          .ForSign(sign);
            RaiseEvent(evt);
        }

        public void Apply(CommittenteUpdated e)
        {

        }

        public void Delete()
        {
            var isAlreadyDeleted = new Is_Committente_Already_Deleted();

            ISpecification<Committente> specs = isAlreadyDeleted;

            if (specs.IsSatisfiedBy(this))
            {
                var evt = Build.CommittenteDeleted;

                RaiseEvent(evt);
            }
        }

        public void Apply(CommittenteDeleted e)
        {
            this._deleted = true;
        }




    }
}
