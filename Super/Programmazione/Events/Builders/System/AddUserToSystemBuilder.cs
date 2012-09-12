using System;
using CommonDomain;
using Super.Programmazione.Events.System;

namespace Super.Programmazione.Events.Builders.System
{
    public class UserAddedToSystemBuilder :  IEventBuilder<UserAddedToSystem>
    {
        private string _lastName;
        private string _firstName;
        private string _username;
        private string _password;

        public UserAddedToSystemBuilder WithLastName(string lastName)
        {
            _lastName = lastName;
            return this;
        }

        public UserAddedToSystemBuilder WithFirstName(string firstName)
        {
            _firstName = firstName;
            return this;
        }

        public UserAddedToSystemBuilder ForUserName(string username)
        {
            _username = username;
            return this;
        }

        public UserAddedToSystemBuilder ForPassword(string password)
        {
            _password = password;
            return this;
        }

        public UserAddedToSystem Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public UserAddedToSystem Build(Guid id, Guid commitId, long version)
        {
            return new UserAddedToSystem(id, commitId, version,
                                         _username,
                                         _password,
                                         _firstName,
                                         _lastName);
        }

        
    }
}