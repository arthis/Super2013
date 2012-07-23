using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using Super.Contabilita.Events.Impianto;
using Super.Contabilita.Events.Builders;
using BuildVO = CommonDomain.Core.Super.Domain.Builders.Build;

namespace Super.Contabilita.Domain
{
    public class Impianto : AggregateBase
    {
        private class Is_Impianto_Already_Deleted : ISpecification<Impianto>
        {
            public bool IsSatisfiedBy(Impianto i)
        {
            if (i._deleted)
            {
                i.CommandValidationMessages.Add(new ValidationMessage("Impianto","impianto gia cancellata"));
                return false;
            }

            return true;
        }
        }
        private class Is_Impianto_Interval_In_Lotto : ISpecification<Impianto>
        {
            private readonly Lotto _lotto;
            private readonly Interval _interval;

            public Is_Impianto_Interval_In_Lotto(Lotto lotto, Interval interval)
            {
                Contract.Requires(lotto != null);
                Contract.Requires(interval != null);

                _lotto = lotto;
                _interval = interval;
            }

            public bool IsSatisfiedBy(Impianto i)
            {
                if (!_lotto.ContainsInterval(_interval))
                {
                    i.CommandValidationMessages.Add(new ValidationMessage("Lotto", "Gli Dati del lotto sono troppe piccole per questo interval."));
                    return false;
                }

                return true;
            }
        }

        private bool _deleted;
        private Interval _interval;

        public Impianto()
        {
        }

        public Impianto(Guid id, Interval interval, Guid idLotto, DateTime creationDate, string description, Lotto lotto)
        {
            var is_Impianto_Interval_In_Lotto = new Is_Impianto_Interval_In_Lotto(lotto, interval);

            ISpecification<Impianto> specs = is_Impianto_Interval_In_Lotto;

            if (specs.IsSatisfiedBy(this))
            {
                var evt = Build.ImpiantoCreated
                    .ForInterval(interval)
                    .ForLotto(idLotto)
                    .ForCreationDate(creationDate)
                    .ForDescription(description);
                RaiseEvent(id, evt);
            }
        }

        public void Apply(ImpiantoCreated e)
        {
            Id = e.Id;
            _interval = BuildVO.Interval.FromPeriod(e.Interval).Build();
        }





        public void Update(Interval interval, string description)
        {
            var evt = Build.ImpiantoUpdated
                          .ForInterval(interval)
                          .ForDescription(description);
            RaiseEvent(evt);
        }

        public void Apply(ImpiantoUpdated e)
        {

        }

        public void Delete()
        {
            var isAlreadyDeleted = new Is_Impianto_Already_Deleted();

            ISpecification<Impianto> specs = isAlreadyDeleted;

            if (specs.IsSatisfiedBy(this))
            {
                var evt = Build.ImpiantoDeleted;

                RaiseEvent(evt);
            }
        }

        public void Apply(ImpiantoDeleted e)
        {
            this._deleted = true;
        }

     


    }
}
