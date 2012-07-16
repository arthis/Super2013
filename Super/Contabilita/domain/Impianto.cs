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
        private class Is_Impianto_Intervall_In_Lotto : ISpecification<Impianto>
        {
            private readonly Lotto _lotto;
            private readonly Intervall _intervall;

            public Is_Impianto_Intervall_In_Lotto(Lotto lotto, Intervall intervall)
            {
                Contract.Requires(lotto != null);
                Contract.Requires(intervall != null);

                _lotto = lotto;
                _intervall = intervall;
            }

            public bool IsSatisfiedBy(Impianto i)
            {
                if (!_lotto.ContainsIntervall(_intervall))
                {
                    i.CommandValidationMessages.Add(new ValidationMessage("Lotto", "Gli Dati del lotto sono troppe piccole per questo intervall."));
                    return false;
                }

                return true;
            }
        }

        private bool _deleted;
        private Intervall _intervall;

        public Impianto()
        {
        }

        public Impianto(Guid id, Intervall intervall, Guid idLotto, DateTime creationDate, string description, Lotto lotto)
        {
            var is_Impianto_Intervall_In_Lotto = new Is_Impianto_Intervall_In_Lotto(lotto, intervall);

            ISpecification<Impianto> specs = is_Impianto_Intervall_In_Lotto;

            if (specs.IsSatisfiedBy(this))
            {
                var evt = Build.ImpiantoCreated
                    .ForIntervall(intervall)
                    .ForLotto(idLotto)
                    .ForCreationDate(creationDate)
                    .ForDescription(description);
                RaiseEvent(id, evt);
            }
        }

        public void Apply(ImpiantoCreated e)
        {
            Id = e.Id;
            _intervall = BuildVO.Intervall.FromPeriod(e.Intervall).Build();
        }





        public void Update(Intervall intervall, string description)
        {
            var evt = Build.ImpiantoUpdated
                          .ForIntervall(intervall)
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
