using System;
using CommonDomain;
using Super.Contabilita.Commands.TipoIntervento.Ambiente;

namespace Super.Contabilita.Commands.Builders.TipoIntervento
{
    public class CreateTipoInterventoAmbBuilder : ICommandBuilder<CreateTipoInterventoAmb>
    {
        private string _description;
        private string _mnemo;
        private Guid _idMeasuringUnit;

        public CreateTipoInterventoAmb Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CreateTipoInterventoAmb Build(Guid id, Guid commitId, long version)
        {
            var cmd =  new CreateTipoInterventoAmb(id, commitId, version, _mnemo, _idMeasuringUnit, _description);

            return cmd;
        }


        public CreateTipoInterventoAmbBuilder ForMnemo(string mnemo)
        {
            _mnemo = mnemo;
            return this;
        }

        public CreateTipoInterventoAmbBuilder OfMeasuringUNit(Guid idMeasuringUnit)
        {
            _idMeasuringUnit = idMeasuringUnit;
            return this;
        }

 
        public CreateTipoInterventoAmbBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }


    }
}
