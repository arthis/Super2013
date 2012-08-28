using System;
using CommonDomain;
using Super.Contabilita.Events.TipoIntervento.RotabileInManutenzione;

namespace Super.Contabilita.Events.Builders.TipoIntervento
{
    public class TipoInterventoRotManCreatedBuilder : IEventBuilder<TipoInterventoRotManCreated>
    {
        private string _description;
        private string _mnemo;
        private Guid _idMeasuringUnit;

        public TipoInterventoRotManCreated Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public TipoInterventoRotManCreated Build(Guid id, Guid commitId, long version)
        {
            var cmd = new TipoInterventoRotManCreated(id, commitId, version, _mnemo, _idMeasuringUnit, _description);

            return cmd;
        }



        public TipoInterventoRotManCreatedBuilder ForMnemo(string mnemo)
        {
            _mnemo = mnemo;
            return this;
        }

        public TipoInterventoRotManCreatedBuilder OfMeasuringUNit(Guid idMeasuringUnit)
        {
            _idMeasuringUnit = idMeasuringUnit;
            return this;
        }

     

        public TipoInterventoRotManCreatedBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }


    }
}
