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
        private Interval _interval;

        public Lotto()
        {
        }

        public Lotto(Guid id, Interval interval, DateTime creationDate, string description)
        {
            var evt = Build.LottoCreated
                          .ForInterval(interval)
                          .ForCreationDate(creationDate)
                          .ForDescription(description);
            RaiseEvent(id, evt);
        }

        public void Apply(LottoCreated e)
        {
            Id = e.Id;
            _interval = BuildVO.Interval.FromPeriod(e.Interval).Build();
        }

        public void Update(Interval interval, string description)
        {
            var evt = Build.LottoUpdated
                .ForInterval(interval)
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

        public bool ContainsInterval(Interval other)
        {
            return _interval.Contains(other);
        }

    }
}
