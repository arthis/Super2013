using System;
using CommonDomain;
using Super.Contabilita.Events.TipoIntervento.Ambiente;

namespace Super.Contabilita.Events.Builders.TipoIntervento
{
    public class TipoInterventoAmbCreatedBuilder : ICommandBuilder<TipoInterventoAmbCreated>
    {
        private string _description;
        private string _mnemo;
        private Guid _idMeasuringUnit;

        public TipoInterventoAmbCreated Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public TipoInterventoAmbCreated Build(Guid id, Guid commitId, long version)
        {
            var cmd =  new TipoInterventoAmbCreated(id, commitId, version, _mnemo, _idMeasuringUnit, _description);

            return cmd;
        }


        public TipoInterventoAmbCreatedBuilder ForMnemo(string mnemo)
        {
            _mnemo = mnemo;
            return this;
        }

        public TipoInterventoAmbCreatedBuilder OfMeasuringUNit(Guid idMeasuringUnit)
        {
            _idMeasuringUnit = idMeasuringUnit;
            return this;
        }

 
        public TipoInterventoAmbCreatedBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }


    }
}
