using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.Builders;
using CommonDomain.Core.Super.Domain.ValueObjects;
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


        public override CommandValidation Execute(CreateAreaIntervento cmd)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);

            var existingArea = Repository.GetById<AreaIntervento>(cmd.Id);

            if (!existingArea.IsNull())
                throw new AlreadyCreatedAggregateRootException();


            var area =  new AreaIntervento(cmd.Id,
                                          Build.RollonPeriod.FromPeriod(cmd.Period).Build(),
                                          cmd.CreationDate,
                                          cmd.Description);

            Repository.Save(area, cmd.GetCommitId());


            return area.CommandValidationMessages;
        }

    }

 
}
