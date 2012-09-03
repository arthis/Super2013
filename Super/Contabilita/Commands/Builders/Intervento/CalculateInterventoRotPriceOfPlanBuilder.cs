using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Commands.Intervento;

namespace Super.Contabilita.Commands.Builders.Intervento
{
    public class CalculateInterventoRotPriceOfPlanBuilder : ICommandBuilder<CalculateInterventoRotPriceOfPlan>
    {
        
        private Guid _idPlan;
        private Guid _idPricing;
        private Guid _idTipoIntervento;
        private Period _period;
        private OggettoRot[] _oggetti;

        public CalculateInterventoRotPriceOfPlan Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CalculateInterventoRotPriceOfPlan Build(Guid id, Guid commitId, long version)
        {
            var cmd =  new CalculateInterventoRotPriceOfPlan(id, commitId, version,
                _idPlan,
                _idPricing,
                _idTipoIntervento,
                _period,
                _oggetti);
            return cmd;
        }


        public CalculateInterventoRotPriceOfPlanBuilder ForPricing(Guid idPricing)
        {
            _idPricing = idPricing;
            return this;
        }

        public CalculateInterventoRotPriceOfPlanBuilder ForPlan(Guid idPlan)
        {
            _idPlan = idPlan;
            return this;
        }

        public CalculateInterventoRotPriceOfPlanBuilder ForTipoIntervento(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }


        public CalculateInterventoRotPriceOfPlanBuilder ForPeriod(Period period)
        {
            _period = period;
            return this;
        }

       
        public CalculateInterventoRotPriceOfPlanBuilder WithOggetti(OggettoRot[] oggetti)
        {
            _oggetti = oggetti;
            return this;
        }


    }
}
