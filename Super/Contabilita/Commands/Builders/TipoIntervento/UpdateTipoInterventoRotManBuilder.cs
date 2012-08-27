using System;
using CommonDomain;
using Super.Contabilita.Commands.TipoIntervento.RotabileInManutenzione;

namespace Super.Contabilita.Commands.Builders.TipoIntervento
{
    public class UpdateTipoInterventoRotManBuilder : ICommandBuilder<UpdateTipoInterventoRotMan>
    {
        private string _description;
        private string _mnemo;
        private Guid _idMeasuringUnit;


        public UpdateTipoInterventoRotMan Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public UpdateTipoInterventoRotMan Build(Guid id, Guid commitId, long version)
        {
            var cmd = new UpdateTipoInterventoRotMan(id, commitId, version, _mnemo, _idMeasuringUnit,  _description);

            return cmd;
        }



        public UpdateTipoInterventoRotManBuilder ForMnemo(string mnemo)
        {
            _mnemo = mnemo;
            return this;
        }

        public UpdateTipoInterventoRotManBuilder OfMeasuringUNit(Guid idMeasuringUnit)
        {
            _idMeasuringUnit = idMeasuringUnit;
            return this;
        }

      

        public UpdateTipoInterventoRotManBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        
    }

}