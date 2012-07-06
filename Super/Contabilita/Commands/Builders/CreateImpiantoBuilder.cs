﻿using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Commands.Impianto;


namespace Super.Contabilita.Commands.Builders
{
    public class CreateImpiantoBuilder : ICommandBuilder<CreateImpianto>
    {
        Intervall _intervall;
        private DateTime _creationDate;
        private string _description;
        private Guid _idLotto;

        public CreateImpianto Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CreateImpianto Build(Guid id, Guid commitId, long version)
        {
            var cmd =  new CreateImpianto(id, commitId, version, _intervall, _creationDate, _description, _idLotto);

            return cmd;
        }

        public CreateImpiantoBuilder ForCreationDate(DateTime creationDate)
        {
            _creationDate = creationDate;
            return this;
        }

        public CreateImpiantoBuilder ForLotto(Guid idLotto)
        {
            _idLotto = idLotto;
            return this;
        }

        public CreateImpiantoBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public CreateImpiantoBuilder ForIntervall(Intervall intervall)
        {
            _intervall = intervall;
            return this;
        }
    }
}
