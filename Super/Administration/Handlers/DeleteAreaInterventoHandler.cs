using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using Super.Administration.Commands.AreaIntervento;
using Super.Administration.Domain;
using CommonDomain.Persistence;

namespace Super.Administration.Handlers
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
            var commitId = Guid.NewGuid();

            area.Delete();

            Repository.Save(area, commitId);

            return area.CommandValidationMessages;
        }
    }
}
