using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using Super.Contabilita.Events;
using Super.Contabilita.Events.Builders;
using Super.Contabilita.Events.TipoIntervento.RotabileInManutenzione;
using BuildVO = CommonDomain.Core.Super.Domain.Builders.Build;

namespace Super.Contabilita.Domain
{
    public class TipoInterventoRotMan : AggregateBase
    {
        private class Is_TipoInterventoRotMan_Already_Deleted : ISpecification<TipoInterventoRotMan>
        {
            public bool IsSatisfiedBy(TipoInterventoRotMan i)
            {
                if (i._deleted)
                {
                    i.CommandValidationMessages.Add(new ValidationMessage("TipoInterventoRotMan", "tipo intervento rotabile in manutenzione gia cancellata"));
                    return false;
                }

                return true;
            }
        }

        private bool _deleted;
        private Interval _interval;

        public TipoInterventoRotMan()
        {
        }

        public TipoInterventoRotMan(Guid id,  string description, string mnemo, Guid idMeasuringUnit)
        {
            var evt = Build.TipoInterventoRotManCreated
                .ForDescription(description)
                .ForMnemo(mnemo)
                .OfMeasuringUNit(idMeasuringUnit);
            RaiseEvent(id, evt);

        }

        public void Apply(TipoInterventoRotManCreated e)
        {
            Id = e.Id;
        }

        public void Update( string description, string mnemo, Guid idMeasuringUnit)
        {
            var evt = Build.TipoInterventoRotManUpdated
                .ForDescription(description)
                .ForMnemo(mnemo)
                .OfMeasuringUNit(idMeasuringUnit);
            RaiseEvent(evt);
        }

        public void Apply(TipoInterventoRotManUpdated e)
        {

        }

        public void Delete()
        {
            var isAlreadyDeleted = new Is_TipoInterventoRotMan_Already_Deleted();

            ISpecification<TipoInterventoRotMan> specs = isAlreadyDeleted;

            if (specs.IsSatisfiedBy(this))
            {
                var evt = Build.TipoInterventoRotManDeleted;

                RaiseEvent(evt);
            }
        }

        public void Apply(TipoInterventoRotManDeleted e)
        {
            this._deleted = true;
        }




    }
}
