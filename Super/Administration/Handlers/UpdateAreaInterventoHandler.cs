using System;
using CommonCommands;
using System.Diagnostics.Contracts;
using CommonDomain.Persistence;
using Super.Administration.Commands.AreaIntervento;
using Super.Administration.Domain;

namespace Super.Administration.Handlers
{
    public class UpdateAreaInterventoHandler : CommandHandler<UpdateAreaIntervento>
    {
        public UpdateAreaInterventoHandler(IRepository repository)
            : base(repository)
        {
        }


        public override void Execute(UpdateAreaIntervento cmd)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);

            var area = Repository.GetById<AreaIntervento>(cmd.Id);
            var commitId = Guid.NewGuid();

            area.Update(cmd.Start, cmd.End, cmd.Description);

            Repository.Save(area, commitId);
        }
      
    }
}
