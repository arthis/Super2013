using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.Builders;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.Impianto;
using Super.Contabilita.Domain;

namespace Super.Contabilita.Handlers
{

    public class CreateImpiantoHandler : CommandHandler<CreateImpianto>
    {
        public CreateImpiantoHandler(IRepository repository)
            : base(repository)
        {
        }


        public override CommandValidation Execute(CreateImpianto cmd, ICommandHandler<CreateImpianto> next)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);

            var existingImpianto = Repository.GetById<Impianto>(cmd.Id);

            if (!existingImpianto.IsNull())
                throw new AlreadyCreatedAggregateRootException();


            var impianto=  new Impianto(cmd.Id,
                                          Build.Intervall.FromPeriod(cmd.Period).Build(),
                                          cmd.CreationDate,
                                          cmd.Description);

            Repository.Save(impianto, cmd.CommitId);


            return impianto.CommandValidationMessages;
        }

    }

 
}
