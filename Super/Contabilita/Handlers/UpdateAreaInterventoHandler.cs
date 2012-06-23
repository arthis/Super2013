using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.Builders;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.AreaIntervento;
using Super.Contabilita.Domain;

namespace Super.Contabilita.Handlers
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

            area.Update(Build.Intervall.FromPeriod(cmd.Period).Build(), cmd.Description);

            Repository.Save(area, cmd.CommitId);

            return area.CommandValidationMessages;
        }
      
    }
}
