using System;
using CommonDomain;
using Super.Contabilita.Commands.TipoIntervento.Ambiente;

namespace Super.Contabilita.Events.Builders.TipoIntervento
{
    public class TipoInterventoAmbUpdatedBuilder : IEventBuilder<TipoInterventoAmbUpdated>
    {
        private string _description;
        private string _mnemo;
        private Guid _idMeasuringUnit;

        public TipoInterventoAmbUpdated Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public TipoInterventoAmbUpdated Build(Guid id, Guid commitId, long version)
        {
            var cmd = new TipoInterventoAmbUpdated(id, commitId, version, _mnemo, _idMeasuringUnit, _description);

            return cmd;
        }



        public TipoInterventoAmbUpdatedBuilder ForMnemo(string mnemo)
        {
            _mnemo = mnemo;
            return this;
        }

        public TipoInterventoAmbUpdatedBuilder OfMeasuringUNit(Guid idMeasuringUnit)
        {
            _idMeasuringUnit = idMeasuringUnit;
            return this;
        }


        public TipoInterventoAmbUpdatedBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        
    }
}