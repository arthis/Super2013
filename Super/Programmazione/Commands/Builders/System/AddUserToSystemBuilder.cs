using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Commands.System;

namespace Super.Programmazione.Commands.Builders.System
{
    public class AddUserToSystemBuilder : ICommandBuilder<AddUserToSystem>
    {
        private string _lastName;
        private string _firstName;

        public AddUserToSystemBuilder WithLastName(string lastName)
        {
            _lastName = lastName;
            return this;
        }

        public AddUserToSystemBuilder WithFirstName(string firstName)
        {
            _firstName = firstName;
            return this;
        }

        public AddUserToSystem Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public AddUserToSystem Build(Guid id, Guid commitId, long version)
        {
            return new AddUserToSystem(id, commitId, version,
                                                _firstName,
                                                 _lastName);
        }
    }
}