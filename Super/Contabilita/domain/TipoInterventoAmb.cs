using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using Super.Contabilita.Commands.TipoIntervento.Ambiente;
using Super.Contabilita.Events;
using Super.Contabilita.Events.TipoIntervento.Ambiente;
using Super.Contabilita.Events.Builders;

namespace Super.Contabilita.Domain
{
    public class TipoInterventoAmb : AggregateBase
    {
        private class Is_TipoInterventoAmb_Already_Deleted : ISpecification<TipoInterventoAmb>
        {
            public bool IsSatisfiedBy(TipoInterventoAmb i)
            {
                if (i._deleted)
                {
                    i.CommandValidationMessages.Add(new ValidationMessage("TipoInterventoAmb", "tipo intervento ambiente gia cancellata"));
                    return false;
                }

                return true;
            }
        }

        private bool _deleted;
        

        public TipoInterventoAmb()
        {
        }

        public TipoInterventoAmb(Guid id,  string description, string mnemo, Guid idMeasuringUnit)
        {
            var evt = BuildEvt.TipoInterventoAmbCreated
                .ForDescription(description)
                .ForMnemo(mnemo)
                .OfMeasuringUNit(idMeasuringUnit);
            RaiseEvent(id, evt);

        }

        public void Apply(TipoInterventoAmbCreated e)
        {
            Id = e.Id;
        }

        public void Update( string description, string mnemo, Guid idMeasuringUnit)
        {
            var evt = BuildEvt.TipoInterventoAmbUpdated
                .ForDescription(description)
                .ForMnemo(mnemo)
                .OfMeasuringUNit(idMeasuringUnit);
            RaiseEvent(evt);
        }

        public void Apply(TipoInterventoAmbUpdated e)
        {

        }

        public void Delete()
        {
            var isAlreadyDeleted = new Is_TipoInterventoAmb_Already_Deleted();

            ISpecification<TipoInterventoAmb> specs = isAlreadyDeleted;

            if (specs.IsSatisfiedBy(this))
            {
                var evt = BuildEvt.TipoInterventoAmbDeleted;

                RaiseEvent(evt);
            }
        }

        public void Apply(TipoInterventoAmbDeleted e)
        {
            this._deleted = true;
        }




    }
}
