using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using Super.Contabilita.Events.Lotto;
using Super.Contabilita.Events.Builders;
using BuildVO = CommonDomain.Core.Super.Domain.Builders.Build;

namespace Super.Contabilita.Domain
{
    public class Lotto : AggregateBase
    {
        private class Is_Lotto_Already_Deleted : ISpecification<Lotto>
        {
            public bool IsSatisfiedBy(Lotto l)
            {
                if (l.Deleted)
                {
                    l.CommandValidationMessages.Add(new ValidationMessage("Lotto", "lotto gia cancellato"));
                    return false;
                }

                return true;
            }
        }
       

        public bool Deleted { get; set; }
        private Intervall _intervall;

        public Lotto()
        {
        }

        public Lotto(Guid id, Intervall intervall, DateTime creationDate, string description)
        {
            var evt = Build.LottoCreated
                          .ForIntervall(intervall)
                          .ForCreationDate(creationDate)
                          .ForDescription(description);
            RaiseEvent(id, evt);
        }

        public void Apply(LottoCreated e)
        {
            Id = e.Id;
            _intervall = BuildVO.Intervall.FromPeriod(e.Intervall).Build();
        }

        public void Update(Intervall intervall, string description)
        {
            var evt = Build.LottoUpdated
                .ForIntervall(intervall)
                .ForDescription(description);

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
                var evt = Build.LottoDeleted;

                RaiseEvent(evt);
            }
        }

        public void Apply(LottoDeleted e)
        {
            this.Deleted = true;
        }

        public bool ContainsIntervall(Intervall other)
        {
            return _intervall.Contains(other);
        }

    }
}
