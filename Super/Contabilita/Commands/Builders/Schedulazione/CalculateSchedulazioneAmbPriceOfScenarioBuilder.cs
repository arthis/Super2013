using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Commands.Schedulazione;

namespace Super.Contabilita.Commands.Builders.Schedulazione
{
    public class CalculateSchedulazioneAmbPriceOfScenarioBuilder : ICommandBuilder<CalculateSchedulazioneAmbPriceOfScenario>
    {
        
        private Guid _idScenario;
        private Guid _idTipoIntervento;
        private Period _period;
        
        private Guid _idSchedulazione;
        private WorkPeriod _workPeriod;

        private int _quantity;
        private string _description;

        public CalculateSchedulazioneAmbPriceOfScenario Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CalculateSchedulazioneAmbPriceOfScenario Build(Guid id, Guid commitId, long version)
        {
            var cmd = new CalculateSchedulazioneAmbPriceOfScenario(id, commitId, version,
                _idScenario,
                _idSchedulazione,
                _workPeriod,
                _idTipoIntervento,
                _period,
                _quantity,
                _description);
            return cmd;
        }


        

        public CalculateSchedulazioneAmbPriceOfScenarioBuilder ForScenario(Guid idScenario)
        {
            _idScenario = idScenario;
            return this;
        }

        public CalculateSchedulazioneAmbPriceOfScenarioBuilder ForSchedulazione(Guid idSchedulazione)
        {
            _idSchedulazione = idSchedulazione;
            return this;
        }

        public CalculateSchedulazioneAmbPriceOfScenarioBuilder ForTipoIntervento(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }


        public CalculateSchedulazioneAmbPriceOfScenarioBuilder ForPeriod(Period period)
        {
            _period = period;
            return this;
        }

        public CalculateSchedulazioneAmbPriceOfScenarioBuilder ForWorkPeriod(WorkPeriod workPeriod)
        {
            _workPeriod = workPeriod;
            return this;
        }


        public CalculateSchedulazioneAmbPriceOfScenarioBuilder ForQuantity(int quantity)
        {
            _quantity = quantity;
            return this;
        }

        public CalculateSchedulazioneAmbPriceOfScenarioBuilder ForDescription(string description )
        {
            _description = description;
            return this;
        }


    }
}
