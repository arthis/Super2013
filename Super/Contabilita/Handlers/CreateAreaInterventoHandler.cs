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
        public CreateImpiantoHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(CreateImpianto cmd)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);

            var existingImpianto = EventRepository.GetById<Impianto>(cmd.Id);

            if (!existingImpianto.IsNull())
                throw new AlreadyCreatedAggregateRootException();


            var impianto=  new Impianto(cmd.Id,
                                          Build.Intervall.FromPeriod(cmd.Period).Build(),
                                          cmd.IdLotto,
                                          cmd.CreationDate,
                                          cmd.Description);

            EventRepository.Save(impianto, cmd.CommitId);


            return impianto.CommandValidationMessages;
        }

    }

 
}
