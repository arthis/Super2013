using System;
using CommonDomain;
using Super.Programmazione.Events.System;

namespace Super.Programmazione.Events.Builders.System
{
    public class UserAddedToSystemBuilder :  IEventBuilder<UserAddedToSystem>
    {
        private string _lastName;
        private string _firstName;

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

        public UserAddedToSystem Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public UserAddedToSystem Build(Guid id, Guid commitId, long version)
        {
            return new UserAddedToSystem(id, commitId,version,
                                                 _firstName,
                                                 _lastName);
        }
    }
}