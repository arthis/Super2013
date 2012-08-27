using System;
using CommonDomain;
using Super.Contabilita.Commands.TipoIntervento.Ambiente;

namespace Super.Contabilita.Commands.Builders.TipoIntervento
{
    public class UpdateTipoInterventoAmbBuilder : ICommandBuilder<UpdateTipoInterventoAmb>
    {
        private string _description;
        private string _mnemo;
        private Guid _idMeasuringUnit;

        public UpdateTipoInterventoAmb Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public UpdateTipoInterventoAmb Build(Guid id, Guid commitId, long version)
        {
            var cmd = new UpdateTipoInterventoAmb(id, commitId, version, _mnemo, _idMeasuringUnit, _description);

            return cmd;
        }



        public UpdateTipoInterventoAmbBuilder ForMnemo(string mnemo)
        {
            _mnemo = mnemo;
            return this;
        }

        public UpdateTipoInterventoAmbBuilder OfMeasuringUNit(Guid idMeasuringUnit)
        {
            _idMeasuringUnit = idMeasuringUnit;
            return this;
        }


        public UpdateTipoInterventoAmbBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        
    }
}