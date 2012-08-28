using System;
using CommonDomain;
using Super.Contabilita.Events.TipoOggettoIntervento.Rotabile;

namespace Super.Contabilita.Events.Builders.TipoOggettoIntervento.Rotabile
{
    public class LocomotiveRotCreatedBuilder : ICommandBuilder<LocomotiveRotCreated>
    {
        private string _description;
        private string _sign;


        public LocomotiveRotCreated Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public LocomotiveRotCreated Build(Guid id, Guid commitId, long version)
        {
            var cmd = new LocomotiveRotCreated(id, commitId, version, _sign, _description);

            return cmd;
        }


        public LocomotiveRotCreatedBuilder ForSign(string sign)
        {
            _sign = sign;
            return this;
        }

        public LocomotiveRotCreatedBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

    }
}
