using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.Impianto;
using Super.Contabilita.Domain;

namespace Super.Contabilita.Handlers
{
    public class DeleteImpiantoHandler : CommandHandler<DeleteImpianto>
    {
        public DeleteImpiantoHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(DeleteImpianto cmd)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);

            var impianto= EventRepository.GetById<Impianto>(cmd.Id);

            if (impianto.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            impianto.Delete();

            EventRepository.Save(impianto, cmd.CommitId);

            return impianto.CommandValidationMessages;
        }
    }
}
