using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using Super.Contabilita.Events.Builders;
using Super.Contabilita.Events.TipoIntervento.Rotabile;

using BuildVO = CommonDomain.Core.Super.Domain.Builders.Build;

namespace Super.Contabilita.Domain
{
    public class TipoInterventoRot : AggregateBase
    {
        private class Is_TipoInterventoRot_Already_Deleted : ISpecification<TipoInterventoRot>
        {
            public bool IsSatisfiedBy(TipoInterventoRot i)
            {
                if (i._deleted)
                {
                    i.CommandValidationMessages.Add(new ValidationMessage("TipoInterventoRot", "tipo intervento rotabile gia cancellata"));
                    return false;
                }

                return true;
            }
        }

        private bool _deleted;
        private Interval _interval;

        public TipoInterventoRot()
        {
        }

        public TipoInterventoRot(Guid id, string description, string mnemo, Guid idMeasuringUnit, char classe, bool aitreni, bool calcoloDetrazioni)
        {
            var evt = Build.TipoInterventoRotCreated
                .ForDescription(description)
                .ForMnemo(mnemo)
                .OfMeasuringUNit(idMeasuringUnit)
                .ForClasse(classe)
                .ForAiTreni(aitreni)
                .ForCalcoloDetrazioni(calcoloDetrazioni);

            RaiseEvent(id, evt);

        }

        public void Apply(TipoInterventoRotCreated e)
        {
            Id = e.Id;
        }

        public void Update(string description, string mnemo, Guid idMeasuringUnit, char classe, bool aitreni, bool calcoloDetrazioni)
        {
            var evt = Build.TipoInterventoRotUpdated
                .ForDescription(description)
                .ForMnemo(mnemo)
                .OfMeasuringUNit(idMeasuringUnit)
                .ForClasse(classe)
                .ForAiTreni(aitreni)
                .ForCalcoloDetrazioni(calcoloDetrazioni);
            RaiseEvent(evt);
        }

        public void Apply(TipoInterventoRotUpdated e)
        {

        }

        public void Delete()
        {
            var isAlreadyDeleted = new Is_TipoInterventoRot_Already_Deleted();

            ISpecification<TipoInterventoRot> specs = isAlreadyDeleted;

            if (specs.IsSatisfiedBy(this))
            {
                var evt = Build.TipoInterventoRotDeleted;

                RaiseEvent(evt);
            }
        }

        public void Apply(TipoInterventoRotDeleted e)
        {
            this._deleted = true;
        }




    }
}
