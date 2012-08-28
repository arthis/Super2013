using System;
using CommonDomain;
using Super.Contabilita.Events.TipoIntervento.Rotabile;

namespace Super.Contabilita.Events.Builders.TipoIntervento
{
    public class TipoInterventoRotUpdatedBuilder : IEventBuilder<TipoInterventoRotUpdated>
    {
        private string _description;
        private string _mnemo;
        private Guid _idMeasuringUnit;
        private bool _calcoloDetrazioni;
        private bool _aiTreni;
        private char _classe;

        public TipoInterventoRotUpdated Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public TipoInterventoRotUpdated Build(Guid id, Guid commitId, long version)
        {
            var cmd = new TipoInterventoRotUpdated(id, commitId, version, _mnemo, _idMeasuringUnit, _calcoloDetrazioni, _aiTreni, _classe, _description);

            return cmd;
        }

        public TipoInterventoRotUpdatedBuilder ForMnemo(string mnemo)
        {
            _mnemo = mnemo;
            return this;
        }

        public TipoInterventoRotUpdatedBuilder OfMeasuringUNit(Guid idMeasuringUnit)
        {
            _idMeasuringUnit = idMeasuringUnit;
            return this;
        }

        public TipoInterventoRotUpdatedBuilder ForCalcoloDetrazioni(bool calcoloDetrazioni)
        {
            _calcoloDetrazioni = calcoloDetrazioni;
            return this;
        }

        public TipoInterventoRotUpdatedBuilder ForAiTreni(bool aiTreni)
        {
            _aiTreni = aiTreni;
            return this;
        }

        public TipoInterventoRotUpdatedBuilder ForClasse(char classe)
        {
            _classe = classe;
            return this;
        }

        public TipoInterventoRotUpdatedBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        
    }
}