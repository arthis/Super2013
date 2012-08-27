using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using Super.Contabilita.Events.DirezioneRegionale;
using Super.Contabilita.Events.Builders;
using BuildVO = CommonDomain.Core.Super.Domain.Builders.Build;

namespace Super.Contabilita.Domain
{
    public class DirezioneRegionale : AggregateBase
    {
        private class Is_DirezioneRegionale_Already_Deleted : ISpecification<DirezioneRegionale>
        {
            public bool IsSatisfiedBy(DirezioneRegionale i)
            {
                if (i._deleted)
                {
                    i.CommandValidationMessages.Add(new ValidationMessage("DirezioneRegionale", "appaltatore gia cancellata"));
                    return false;
                }

                return true;
            }
        }

        private bool _deleted;
        private Interval _interval;

        public DirezioneRegionale()
        {
        }

        public DirezioneRegionale(Guid id,  string description)
        {
            var evt = Build.DirezioneRegionaleCreated
                .ForDescription(description);
            RaiseEvent(id, evt);

        }

        public void Apply(DirezioneRegionaleCreated e)
        {
            Id = e.Id;
        }

        public void Update( string description)
        {
            var evt = Build.DirezioneRegionaleUpdated
                          .ForDescription(description);
            RaiseEvent(evt);
        }

        public void Apply(DirezioneRegionaleUpdated e)
        {

        }

        public void Delete()
        {
            var isAlreadyDeleted = new Is_DirezioneRegionale_Already_Deleted();

            ISpecification<DirezioneRegionale> specs = isAlreadyDeleted;

            if (specs.IsSatisfiedBy(this))
            {
                var evt = Build.DirezioneRegionaleDeleted;

                RaiseEvent(evt);
            }
        }

        public void Apply(DirezioneRegionaleDeleted e)
        {
            this._deleted = true;
        }




    }
}
