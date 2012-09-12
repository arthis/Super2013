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
        private string _userName;
        private string _password;

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

        public AddUserToSystemBuilder ForUserName(string userName)
        {
            _userName = userName;
            return this;
        }

        public AddUserToSystemBuilder ForPassword(string password)
        {
            _password = password;
            return this;
        }

        public AddUserToSystem Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public AddUserToSystem Build(Guid id, Guid commitId, long version)
        {
            return new AddUserToSystem(id, commitId, version,
                                       _userName,
                                       _password,
                                       _firstName,
                                       _lastName);
        }
    }
}