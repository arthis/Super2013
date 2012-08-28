using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Super.Domain.Builders;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.Impianto;
using Super.Contabilita.Domain;

namespace Super.Contabilita.Handlers.Impianto
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

            var existingLotto = EventRepository.GetById<Domain.Lotto>(cmd.IdLotto);
            var existingImpianto = EventRepository.GetById<Domain.Impianto>(cmd.Id);

            if (!existingImpianto.IsNull())
                throw new AlreadyCreatedAggregateRootException();

            if(existingLotto.IsNull())
                throw new AggregateRootInstanceNotFoundException();


            var impianto = new Domain.Impianto(cmd.Id,
                                          Build.Interval.FromPeriod(cmd.Interval).Build(),
                                          cmd.IdLotto,
                                          cmd.Description,
                                          existingLotto);

            EventRepository.Save(impianto, cmd.CommitId);


            return impianto.CommandValidationMessages;
        }

    }

 
}
