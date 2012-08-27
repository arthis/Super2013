using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using Super.Contabilita.Events.MeasuringUnit;
using Super.Contabilita.Events.Builders;
using BuildVO = CommonDomain.Core.Super.Domain.Builders.Build;

namespace Super.Contabilita.Domain
{
    public class MeasuringUnit : AggregateBase
    {
        private class Is_MeasuringUnit_Already_Deleted : ISpecification<MeasuringUnit>
        {
            public bool IsSatisfiedBy(MeasuringUnit i)
            {
                if (i._deleted)
                {
                    i.CommandValidationMessages.Add(new ValidationMessage("MeasuringUnit", "unità di misura gia cancellata"));
                    return false;
                }

                return true;
            }
        }

        private bool _deleted;
        private Interval _interval;

        public MeasuringUnit()
        {
        }

        public MeasuringUnit(Guid id,  string description)
        {
            var evt = Build.MeasuringUnitCreated
                .ForDescription(description);
            RaiseEvent(id, evt);

        }

        public void Apply(MeasuringUnitCreated e)
        {
            Id = e.Id;
        }

        public void Update( string description)
        {
            var evt = Build.MeasuringUnitUpdated
                          .ForDescription(description);
            RaiseEvent(evt);
        }

        public void Apply(MeasuringUnitUpdated e)
        {

        }

        public void Delete()
        {
            var isAlreadyDeleted = new Is_MeasuringUnit_Already_Deleted();

            ISpecification<MeasuringUnit> specs = isAlreadyDeleted;

            if (specs.IsSatisfiedBy(this))
            {
                var evt = Build.MeasuringUnitDeleted;

                RaiseEvent(evt);
            }
        }

        public void Apply(MeasuringUnitDeleted e)
        {
            this._deleted = true;
        }




    }
}
