using System;
using CommonDomain;
using Super.Contabilita.Events.TipoOggettoIntervento.RotabileInManutenzione;

namespace Super.Contabilita.Events.Builders.TipoOggettoIntervento.RotabileInManutenzione
{
    public class LocomotiveRotManCreatedBuilder : IEventBuilder<LocomotiveRotManCreated>
    {
        private string _description;
        private string _sign;


        public LocomotiveRotManCreated Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public LocomotiveRotManCreated Build(Guid id, Guid commitId, long version)
        {
            var cmd = new LocomotiveRotManCreated(id, commitId, version, _sign, _description);

            return cmd;
        }


        public LocomotiveRotManCreatedBuilder ForSign(string sign)
        {
            _sign = sign;
            return this;
        }

        public LocomotiveRotManCreatedBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

    }
}
