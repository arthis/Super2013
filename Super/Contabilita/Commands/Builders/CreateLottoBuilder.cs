using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Commands.Lotto;

namespace Super.Contabilita.Commands.Builders
{
    public class CreateLottoBuilder : ICommandBuilder<CreateLotto>
    {
        Intervall _intervall;
        private DateTime _creationDate;
        private string _description;

        public CreateLotto Build(Guid id)
        {
             var cmd = new CreateLotto(id, _intervall, _creationDate, _description);

            cmd.CommitId = Guid.NewGuid();

            return cmd;
        }

        public CreateLottoBuilder ForCreationDate(DateTime creationDate)
        {
            _creationDate = creationDate;
            return this;
        }


        public CreateLottoBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public CreateLottoBuilder ForIntervall(Intervall intervall)
        {
            _intervall = intervall;
            return this;
        }
    }
}