using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Domain;
using CommonDomain.Core.Super.Domain.Builders;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.Impianto;

namespace Super.Contabilita.Handlers.Impianto
{
    public class UpdateImpiantoHandler : CommandHandler<UpdateImpianto>
    {
        public UpdateImpiantoHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(UpdateImpianto cmd)
        {
            Contract.Requires(cmd != null);

            var impianto = EventRepository.GetById<Domain.Impianto>(cmd.Id);

            if (impianto.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            impianto.Update(BuildDomainVO.Interval.FromInterval(cmd.Interval).Build(), cmd.Description);

            EventRepository.Save(impianto, cmd.CommitId);

            return impianto.CommandValidationMessages;
        }
      
    }
}
