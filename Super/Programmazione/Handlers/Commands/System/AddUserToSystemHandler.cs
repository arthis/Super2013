using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Programmazione.Commands.System;

namespace Super.Programmazione.Handlers.Commands.System
{
    public class AddUserToSystemHandler : CommandHandler<AddUserToSystem>
    {
        public AddUserToSystemHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }

        public override CommandValidation Execute(AddUserToSystem cmd)
        {
            Contract.Requires(cmd != null);

            var user = Domain.System.AddNewUser(cmd.Id, cmd.FirstName, cmd.LastName, cmd.Password,cmd.Username);

            EventRepository.Save(user, cmd.CommitId);

            return user.CommandValidationMessages; 
        }
    }
}
