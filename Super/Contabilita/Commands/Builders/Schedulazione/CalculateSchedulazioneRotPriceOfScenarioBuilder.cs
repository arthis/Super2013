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
        
        private Guid _idScenario;
        private Guid _idTipoIntervento;
        private Period _period;
        private OggettoRot[] _oggetti;
        private Guid _idSchedulazione;
        private WorkPeriod _workPeriod
            ;

        public CalculateSchedulazioneRotPriceOfScenario Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CalculateSchedulazioneRotPriceOfScenario Build(Guid id, Guid commitId, long version)
        {
            var cmd = new CalculateSchedulazioneRotPriceOfScenario(id, commitId, version,
                _idScenario,
                _idSchedulazione,
                _workPeriod,
                _idTipoIntervento,
                _period,
                _oggetti);
            return cmd;
        }


        

        public CalculateSchedulazioneRotPriceOfScenarioBuilder ForScenario(Guid idScenario)
        {
            _idScenario = idScenario;
            return this;
        }

        public CalculateSchedulazioneRotPriceOfScenarioBuilder ForSchedulazione(Guid idSchedulazione)
        {
            _idSchedulazione = idSchedulazione;
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

        public CalculateInterventoRotPriceOfPlanBuilder ForWorkPeriod(WorkPeriod workPeriod)
        {
            _workPeriod = workPeriod;
            return this;
        }

       
        public CalculateInterventoRotPriceOfPlanBuilder WithOggetti(OggettoRot[] oggetti)
        {
            _oggetti = oggetti;
            return this;
        }


    }
}
