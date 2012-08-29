using System;
using CommonDomain;
using Super.Contabilita.Events.TipoOggettoIntervento.RotabileInManutenzione;

namespace Super.Contabilita.Events.Builders.TipoOggettoIntervento.RotabileInManutenzione
{
    public class LocomotiveRotManUpdatedBuilder : IEventBuilder<LocomotiveRotManUpdated>
    {
        private string _description;
        private string _sign;


        public LocomotiveRotManUpdated Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public LocomotiveRotManUpdated Build(Guid id, Guid commitId, long version)
        {
            var cmd = new LocomotiveRotManUpdated(id, commitId, version, _sign, _description);

            return cmd;
        }


        public LocomotiveRotManUpdatedBuilder ForSign(string sign)
        {
            _sign = sign;
            return this;
        }

        public LocomotiveRotManUpdatedBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }
    }
}
