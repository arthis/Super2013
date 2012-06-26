using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Commands.Impianto;

namespace Super.Contabilita.Commands.Builders
{
    public class UpdateImpiantoBuilder : ICommandBuilder<UpdateImpianto>
    {
        Intervall _intervall;
        private string _description;

        public UpdateImpianto Build(Guid id)
        {
            return new UpdateImpianto(id, _intervall, _description);
        }



        public UpdateImpiantoBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public UpdateImpiantoBuilder ForIntervall(Intervall intervall)
        {
            _intervall = intervall;
            return this;
        }
    }
}