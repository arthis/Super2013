using System;
using CommonDomain;
using Super.Contabilita.Events.TipoIntervento.Rotabile;

namespace Super.Contabilita.Events.Builders.TipoIntervento
{
    public class TipoInterventoRotCreatedBuilder : IEventBuilder<TipoInterventoRotCreated>
    {
        private string _description;
        private string _mnemo;
        private Guid _idMeasuringUnit;
        private bool _calcoloDetrazioni;
        private bool _aiTreni;
        private char _classe;

        public TipoInterventoRotCreated Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public TipoInterventoRotCreated Build(Guid id, Guid commitId, long version)
        {
            var cmd = new TipoInterventoRotCreated(id, commitId, version, _mnemo, _idMeasuringUnit, _classe,_calcoloDetrazioni,_aiTreni ,_description);

            return cmd;
        }



        public TipoInterventoRotCreatedBuilder ForMnemo(string mnemo)
        {
            _mnemo = mnemo;
            return this;
        }

        public TipoInterventoRotCreatedBuilder OfMeasuringUNit(Guid idMeasuringUnit)
        {
            _idMeasuringUnit = idMeasuringUnit;
            return this;
        }

        public TipoInterventoRotCreatedBuilder ForCalcoloDetrazioni(bool calcoloDetrazioni)
        {
            _calcoloDetrazioni = calcoloDetrazioni;
            return this;
        }

        public TipoInterventoRotCreatedBuilder ForAiTreni(bool aiTreni)
        {
            _aiTreni = aiTreni;
            return this;
        }

        public TipoInterventoRotCreatedBuilder ForClasse(char classe)
        {
            _classe = classe;
            return this;
        }

        public TipoInterventoRotCreatedBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }


    }
}
