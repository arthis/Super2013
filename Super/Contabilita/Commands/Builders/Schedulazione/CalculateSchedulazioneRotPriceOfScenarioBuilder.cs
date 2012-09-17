using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Commands.Builders.Intervento;
using Super.Contabilita.Commands.Intervento;
using Super.Contabilita.Commands.Schedulazione;

namespace Super.Contabilita.Commands.Builders.Schedulazione
{
    public class CalculateSchedulazioneRotPriceOfScenarioBuilder : ICommandBuilder<CalculateSchedulazioneRotPriceOfScenario>
    {
        
        private Guid _idPlan;
        private Guid _idPricing;
        private Guid _idTipoIntervento;
        private Period _period;
        private OggettoRot[] _oggetti;

        public CalculateSchedulazioneRotPriceOfScenarioBuilder Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CalculateSchedulazioneRotPriceOfScenarioBuilder Build(Guid id, Guid commitId, long version)
        {
            var cmd = new CalculateSchedulazioneRotPriceOfScenario(id, commitId, version,
                _idPlan,
                _idPricing,
                _idTipoIntervento,
                _period,
                _oggetti);
            return cmd;
        }


        public CalculateSchedulazioneRotPriceOfScenarioBuilder ForPricing(Guid idPricing)
        {
            _idPricing = idPricing;
            return this;
        }

        public CalculateSchedulazioneRotPriceOfScenarioBuilder ForPlan(Guid idPlan)
        {
            _idPlan = idPlan;
            return this;
        }

        public CalculateSchedulazioneRotPriceOfScenarioBuilder ForTipoIntervento(Guid idTipoIntervento)
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
