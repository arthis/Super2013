using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.Builders;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.AreaIntervento;
using Super.Contabilita.Domain;

namespace Super.Contabilita.Handlers
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
                                          Build.Intervall.FromPeriod(cmd.Period).Build(),
                                          cmd.CreationDate,
                                          cmd.Description);

            Repository.Save(area, cmd.CommitId);


            return area.CommandValidationMessages;
        }

    }

 
}
