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
        public DeleteImpiantoHandler(IRepository repository)
            : base(repository)
        {
        }


        public override CommandValidation Execute(DeleteImpianto cmd, ICommandHandler<DeleteImpianto> next)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);

            var impianto= Repository.GetById<Impianto>(cmd.Id);

            if (impianto.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            impianto.Delete();

            Repository.Save(impianto, cmd.CommitId);

            return impianto.CommandValidationMessages;
        }
    }
}
