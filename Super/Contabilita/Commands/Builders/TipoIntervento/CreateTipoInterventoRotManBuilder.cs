using System;
using CommonDomain;
using Super.Contabilita.Commands.TipoIntervento.RotabileInManutenzione;

namespace Super.Contabilita.Commands.Builders.TipoIntervento
{
    public class CreateTipoInterventoRotManBuilder : ICommandBuilder<CreateTipoInterventoRotMan>
    {
        private string _description;
        private string _mnemo;
        private Guid _idMeasuringUnit;

        public CreateTipoInterventoRotMan Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CreateTipoInterventoRotMan Build(Guid id, Guid commitId, long version)
        {
            var cmd = new CreateTipoInterventoRotMan(id, commitId, version, _mnemo, _idMeasuringUnit, _description);

            return cmd;
        }



        public CreateTipoInterventoRotManBuilder ForMnemo(string mnemo)
        {
            _mnemo = mnemo;
            return this;
        }

        public CreateTipoInterventoRotManBuilder OfMeasuringUNit(Guid idMeasuringUnit)
        {
            _idMeasuringUnit = idMeasuringUnit;
            return this;
        }

     

        public CreateTipoInterventoRotManBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }


    }
}
