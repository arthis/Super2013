using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Core.Super.Messaging.Builders;
using Super.Contabilita.Events;
using Super.Contabilita.Events.PeriodoProgrammazione;
using Super.Contabilita.Events.Builders;

namespace Super.Contabilita.Domain
{
    public class PeriodoProgrammazione : AggregateBase
    {
        private class Is_PeriodoProgrammazione_Already_Deleted : ISpecification<PeriodoProgrammazione>
        {
            public bool IsSatisfiedBy(PeriodoProgrammazione i)
            {
                if (i._deleted)
                {
                    i.CommandValidationMessages.Add(new ValidationMessage("PeriodoProgrammazione", "periodo programmazione gia cancellata"));
                    return false;
                }

                return true;
            }
        }
        private class Is_PeriodoProgrammazione_Already_Closed : ISpecification<PeriodoProgrammazione>
        {
            public bool IsSatisfiedBy(PeriodoProgrammazione i)
            {
                if (i._deleted)
                {
                    i.CommandValidationMessages.Add(new ValidationMessage("PeriodoProgrammazione", "periodo programmazione gia chiusa"));
                    return false;
                }

                return true;
            }
        }

        private bool _deleted;
        private Interval _interval;

        public PeriodoProgrammazione()
        {
        }

        public PeriodoProgrammazione(Guid id,  string description, Interval interval)
        {
            var intervalBuilder = new MsgIntervalBuilder();
            
            interval.BuildValue(intervalBuilder);

            var evt = BuildEvt.PeriodoProgrammazioneCreated
                .ForDescription(description)
                .ForInterval(intervalBuilder.Build());

            RaiseEvent(id, evt);

        }

        public void Apply(PeriodoProgrammazioneCreated e)
        {
            Id = e.Id;
        }

        public void Update(string description, Interval interval)
        {
            var intervalBuilder = new MsgIntervalBuilder();

            interval.BuildValue(intervalBuilder);

            var evt = BuildEvt.PeriodoProgrammazioneUpdated
                          .ForDescription(description)
                          .ForInterval(intervalBuilder.Build());
            RaiseEvent(evt);
        }

        public void Apply(PeriodoProgrammazioneUpdated e)
        {

        }

        public void Delete()
        {
            var isAlreadyDeleted = new Is_PeriodoProgrammazione_Already_Deleted();

            ISpecification<PeriodoProgrammazione> specs = isAlreadyDeleted;

            if (specs.IsSatisfiedBy(this))
            {
                var evt = BuildEvt.PeriodoProgrammazioneDeleted;

                RaiseEvent(evt);
            }
        }

        public void Apply(PeriodoProgrammazioneDeleted e)
        {
            this._deleted = true;
        }

        public void Close(DateTime closingDate, Guid idUser)
        {

            var isPeriodoProgrammazioneAlreadyClosed = new Is_PeriodoProgrammazione_Already_Closed();

            ISpecification<PeriodoProgrammazione> specs = isPeriodoProgrammazioneAlreadyClosed;

            if (specs.IsSatisfiedBy(this))
            {
                var evt = BuildEvt.PeriodoProgrammazioneClosed
                    .By(idUser)
                    .When(closingDate);

                RaiseEvent(evt);
            }

        }

        public void Apply(PeriodoProgrammazioneClosed e)
        {
            this._deleted = true;
        }




    }
}
