using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using Super.Contabilita.Events;
using Super.Contabilita.Events.DirezioneRegionale;
using Super.Contabilita.Events.Builders;

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
        

        public DirezioneRegionale()
        {
        }

        public DirezioneRegionale(Guid id,  string description)
        {
            var evt = BuildEvt.DirezioneRegionaleCreated
                .ForDescription(description);
            RaiseEvent(id, evt);

        }

        public void Apply(DirezioneRegionaleCreated e)
        {
            Id = e.Id;
        }

        public void Update( string description)
        {
            var evt = BuildEvt.DirezioneRegionaleUpdated
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
                var evt = BuildEvt.DirezioneRegionaleDeleted;

                RaiseEvent(evt);
            }
        }

        public void Apply(DirezioneRegionaleDeleted e)
        {
            this._deleted = true;
        }




    }
}
