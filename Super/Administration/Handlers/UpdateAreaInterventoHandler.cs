using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.ValueObjects;
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


        public override CommandValidation Execute(UpdateAreaIntervento cmd)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);

            var area = Repository.GetById<AreaIntervento>(cmd.Id);

            if (area.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            area.Update(new RangeDateUnfinished(cmd.Start, cmd.End), cmd.Description);

            Repository.Save(area, cmd.GetCommitId());

            return area.CommandValidationMessages;
        }
      
    }
}
