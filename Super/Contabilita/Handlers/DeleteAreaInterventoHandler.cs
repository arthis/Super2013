using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.AreaIntervento;
using Super.Contabilita.Domain;

namespace Super.Contabilita.Handlers
{
    public class DeleteAreaInterventoHandler : CommandHandler<DeleteAreaIntervento>
    {
        public DeleteAreaInterventoHandler(IRepository repository)
            : base(repository)
        {
        }


        public override CommandValidation Execute(DeleteAreaIntervento cmd)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);

            var area = Repository.GetById<AreaIntervento>(cmd.Id);

            if (area.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            area.Delete();

            Repository.Save(area, cmd.CommitId);

            return area.CommandValidationMessages;
        }
    }
}
