using System;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using Super.Contabilita.Events.Lotto;
using Super.Contabilita.Events.Builders;

namespace Super.Contabilita.Domain
{
    public class Lotto : AggregateBase
    {
        public bool Deleted { get; set; }

        public Lotto()
        {
        }

        public Lotto(Guid id, Intervall intervall, DateTime creationDate, string description)
        {
            var evt = Build.LottoCreated
                          .ForIntervall(intervall)
                          .ForCreationDate(creationDate)
                          .ForDescription(description)
                          .Build(id);
            RaiseEvent(evt);
        }

        public void Apply(LottoCreated e)
        {
            Id = e.Id;
        }



        public void Update(Intervall intervall, string description)
        {
            var evt = Build.LottoUpdated
                          .ForIntervall(intervall)
                          .ForDescription(description)
                          .Build(Id);
            RaiseEvent(evt);
        }

        public void Apply(LottoUpdated e)
        {

        }

        public void Delete()
        {
            var isAlreadyDeleted = new Is_Lotto_Already_Deleted();

            ISpecification<Lotto> specs = isAlreadyDeleted;

            if (specs.IsSatisfiedBy(this))
            {
                var evt = Build.LottoDeleted
                               .Build(Id);
                RaiseEvent(evt);
            }
        }

        public void Apply(LottoDeleted e)
        {
            this.Deleted = true;
        }


    }
}
