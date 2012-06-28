using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Commands.Lotto;

namespace Super.Contabilita.Commands.Builders
{
    public class UpdateLottoBuilder : ICommandBuilder<UpdateLotto>
    {
        Intervall _intervall;
        private string _description;

        public UpdateLotto Build(Guid id)
        {
            var cmd = new UpdateLotto(id, _intervall, _description);

            cmd.CommitId = Guid.NewGuid();

            return cmd;
        }



        public UpdateLottoBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public UpdateLottoBuilder ForIntervall(Intervall intervall)
        {
            _intervall = intervall;
            return this;
        }

    
    }
}