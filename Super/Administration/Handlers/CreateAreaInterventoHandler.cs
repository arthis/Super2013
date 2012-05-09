using System;
using System.Diagnostics.Contracts;
using CommonCommands;
using CommonDomain.Persistence;
using Super.Administration.Commands.AreaIntervento;
using Super.Administration.Domain;

namespace Super.Administration.Handlers
{

    public class CreateAreaInterventoHandler : CommandHandler<CreateAreaIntervento>
    {
        public CreateAreaInterventoHandler(IRepository repository)
            : base(repository)
        {
        }


        public override void Execute(CreateAreaIntervento cmd)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);

            var commitId = Guid.NewGuid();

            var area = new AreaIntervento(cmd.Id, cmd.Start, cmd.End, cmd.CreationDate, cmd.Description);

            Repository.Save(area, commitId);
        }

    }

 
}
