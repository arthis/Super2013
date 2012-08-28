using System;
using CommonDomain;
using Super.Contabilita.Events.TipoIntervento.RotabileInManutenzione;

namespace Super.Contabilita.Events.Builders.TipoIntervento
{
    public class TipoInterventoRotManUpdatedBuilder : IEventBuilder<TipoInterventoRotManUpdated>
    {
        private string _description;
        private string _mnemo;
        private Guid _idMeasuringUnit;


        public TipoInterventoRotManUpdated Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public TipoInterventoRotManUpdated Build(Guid id, Guid commitId, long version)
        {
            var cmd = new TipoInterventoRotManUpdated(id, commitId, version, _mnemo, _idMeasuringUnit,  _description);

            return cmd;
        }



        public TipoInterventoRotManUpdatedBuilder ForMnemo(string mnemo)
        {
            _mnemo = mnemo;
            return this;
        }

        public TipoInterventoRotManUpdatedBuilder OfMeasuringUNit(Guid idMeasuringUnit)
        {
            _idMeasuringUnit = idMeasuringUnit;
            return this;
        }

      

        public TipoInterventoRotManUpdatedBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        
    }

}